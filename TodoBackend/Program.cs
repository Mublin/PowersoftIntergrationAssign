using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using TodoBackend.Services;
using TodoBackend.Models;
using TodoBackend.Data;
using Microsoft.AspNetCore.Http.HttpResults;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Todo"));
});

builder.Services.AddScoped<ITask, TaskService>();

builder.Services.AddCors(options => 
{
    options.AddPolicy("ReactApp", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin();
        policyBuilder.AllowAnyMethod();
        policyBuilder.AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseRewriter(new RewriteOptions().AddRedirect("api/task/(.*)", "api/todo/$1"));


app.MapGet("/api/todos", (ITask service) =>
{
    var todos = service.GetTodos();
    return TypedResults.Ok(todos);
});




app.MapPost("/api/todos", (Todo task, ITask service) =>
{
    Todo todo = service.CreateTodo(task.Name);
    return TypedResults.Created($"api/todos/{todo.Id}", todo);
});

app.MapPut("/api/todos/updatetodo", Results<Ok<Todo>, NotFound, NoContent> (Todo request, ITask service) =>
{
    string answer = service.CompleteTodo(request.Id);
    Todo? task = service.GetTodoById(request.Id);

    switch (answer)
    {
        case "true":
            if (task is Todo)
            {
                return TypedResults.Ok(task); 
            }
            return TypedResults.NotFound();
        case "false":
            return TypedResults.NotFound();
        case "updated already":
            return TypedResults.Ok(task);
        default:
            return TypedResults.NoContent();

    }
});

app.MapPut("/api/todos/updatename", Results<Ok<Todo>, NotFound>  (Todo request, ITask service) =>
{
    Todo ? task = service.UpdateTodo(request.Id, request.Name);
    if (task is Todo)
    {
        return TypedResults.Ok(task);
    }
    return TypedResults.NotFound();
});


app.MapGet("/api/todos/{id}", Results<Ok<Todo>, NotFound> (int id, ITask service) =>
{
    Todo? task = service.GetTodoById(id);
    return task is Todo ? TypedResults.Ok(task) : TypedResults.NotFound();
});


app.MapDelete("/api/todos/{id}", (int id, ITask service) =>
{
    service.DeleteTodo(id);
    return TypedResults.NoContent(); 
});


app.UseCors("ReactApp");
app.Run();
