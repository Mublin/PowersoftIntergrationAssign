using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Rewrite;
using Todo.model;

var builder = WebApplication.CreateBuilder(args);
string ReactApp = "MyReactApp";

builder.Services.AddSingleton<ITask>(new InMemoryTaskService());
builder.Services.AddCors(options =>
{
    options.AddPolicy(ReactApp, policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:5173");
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyHeader();
    });
});
var app = builder.Build();
//app.UseCors(ReactApp);

app.UseRewriter(new RewriteOptions().AddRedirect("tasks/(.*)", "todos/$1"));

app.Use(async (context, next) =>
{
    Console.WriteLine($"[{context.Request.Path}, {context.Request.Method}, {context.Request.Host}, {DateTime.UtcNow}] : started");
    await next();
    Console.WriteLine($"[{context.Request.Path}, {context.Request.Method}, {context.Request.Host}, {DateTime.UtcNow}] : ended");
});


var todos = new List<TodoModel>();
app.MapGet("/todos", (ITask service) => service.GetTodos());
app.MapGet("/todos/{id}", Results<Ok<TodoModel>, NotFound>  (int id, ITask service) =>
{
    var targetTodo = service.GetTodoById(id);
    return targetTodo == null ? TypedResults.NotFound() : TypedResults.Ok(targetTodo);
});

app.MapPost("/todos", (TodoModel task, ITask service) =>
{
    service.AddTodo(task);
    return TypedResults.Created("todos/{id}", task);
})
.AddEndpointFilter(async (context, next) => {
    var taskArgument = context.GetArgument<TodoModel>(0);
    var errors = new Dictionary<string, string[]>();
    if (taskArgument.dueDate < DateTime.UtcNow)
    {
        errors.Add(nameof(taskArgument.dueDate), ["Cannot be a past date"]) ;
    }
    if (taskArgument.isCompleted)
    {
        errors.Add(nameof(taskArgument.isCompleted), ["Cannot add completed tasks"]);
    }
    if (errors.Count > 0)
    {
        return Results.ValidationProblem(errors);
    }
    return await next(context);
});

app.MapPut("/todos/{id}", Results<Ok<TodoModel>, NotFound>  (TodoModel task, ITask service) =>
{
    int index = service.GetTodoIndex(task.Id);
    if (index == -1)
    {
        return TypedResults.NotFound();
    }
    todos[index] = new TodoModel(task.Id, task.Name, task.dueDate, task.isCompleted);
    return TypedResults.Ok(todos[index]);
});

app.MapDelete("/todos/{id}", (int id, ITask service) =>
{
    service.DeleteTodoById(id);
    return TypedResults.NoContent();
});
app.UseCors("MyReactApp");
app.Run();
interface ITask
{
    TodoModel? GetTodoById(int id);
    int GetTodoIndex(int id);
    List<TodoModel> GetTodos();
    void DeleteTodoById(int id);
    TodoModel AddTodo(TodoModel task);
}

class InMemoryTaskService : ITask
{
    private readonly List<TodoModel> _todos = [];
    public TodoModel ? GetTodoById (int id)
    {
        return _todos.SingleOrDefault(t=> t.Id == id);
    }
    public int GetTodoIndex (int id)
    {
        return _todos.FindIndex(t=> t.Id==id);
    }
    public List<TodoModel> GetTodos()
    { 
        return _todos;
    }
    public void DeleteTodoById(int id)
    {
        _todos.RemoveAll(t => t.Id == id);
    }
    public TodoModel AddTodo (TodoModel task)
    {
        _todos.Add(task);
        return task;
    }
}
