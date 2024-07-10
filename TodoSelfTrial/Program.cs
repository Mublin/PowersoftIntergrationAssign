using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Rewrite;
using TodoSelfTrial.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITask>(new ServiceProviders());

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactApp", policy =>
    {
        policy.AllowAnyMethod();
        policy.WithOrigins("http://localhost:5173", "http://localhost:5005/");
        policy.AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseRewriter(new RewriteOptions().AddRedirect("/taskks/(.*)", "/todos/$1"));

app.MapGet("/todos", (ITask service) =>
{
    List<Todo> todos = service.GetTodo();
    return TypedResults.Ok(todos);

});



app.MapPost("/todos", (Todo todo, ITask service) =>
{
    service.AddTodos(todo);
    return TypedResults.Created($"/todos/{todo.Id}", todo);
}).AddEndpointFilter(async (context, next) => {
    var taskArgument = context.GetArgument<Todo>(0);
    var errorHandle = new Dictionary<string, string[]>();

    return await next(context);
});





app.MapGet("/todos/{id}", Results<Ok<Todo>, NotFound> (int Id, ITask service) =>
{
    Todo? todoGetting = service.GetTodoById(Id);
    if (todoGetting == null)
    {
        return TypedResults.NotFound();
    }
    return TypedResults.Ok(todoGetting);
});
app.MapDelete("/todos/{id}", (int Id, ITask service) =>
{
    service.RemoveTodos(Id);
    return TypedResults.NoContent();

});
app.MapPut("/todos", Results<NoContent, Ok<Todo>> (Todo todo, ITask service) =>
{
    int todoGetting = service.GetIndex(todo.Id);
    if (todoGetting == -1)
    {
        return TypedResults.NoContent();
    }
    service.UpdateTodo(todoGetting, todo);
    return TypedResults.Ok(todo);
});
app.UseCors("ReactApp");
app.Run();
