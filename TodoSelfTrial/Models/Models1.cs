namespace TodoSelfTrial.Models;
using TodoSelfTrial;
public record Todo(string Name, int Id, bool IsCompleted, DateTime DueDate);
public interface ITask
{
    public int GetIndex(int Id);

    public void AddTodos(Todo task);
    public void RemoveTodos(int Id);
    public Todo? GetTodoById(int Id);
    public List<Todo> GetTodo();
    public void UpdateTodo(int index, Todo task);

}

public class ServiceProviders : ITask
{
    private readonly List<Todo> todos = new List<Todo>();

    public void AddTodos(Todo task)
    {
        todos.Add(task);
    }

    public int GetIndex(int Id)
    {
        return todos.FindIndex(t => t.Id == Id);
    }

    public List<Todo> GetTodo()
    {
        return todos;
    }

    public Todo? GetTodoById(int Id)
    {
        return todos.SingleOrDefault(t => t.Id == Id);
    }

    public void RemoveTodos(int Id)
    {
        todos.RemoveAll(t => t.Id == Id);
    }

    public void UpdateTodo(int index, Todo todo)
    {
        todos[index] = new Todo(Name: todo.Name, Id: todo.Id, IsCompleted: todo.IsCompleted, DueDate: todo.DueDate);
    }
}
public class Models1
{
}
