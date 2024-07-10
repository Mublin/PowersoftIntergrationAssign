namespace TodoBackend.Services;
using TodoBackend.Models;
using TodoBackend.Data;

interface ITask
{
    IEnumerable<Todo> GetTodos();
    Todo ? GetTodoById(int id);
    Todo CreateTodo(string name);
    string CompleteTodo (int id);
    void DeleteTodo(int id);
    Todo ? UpdateTodo(int id, string name);
}
public class TaskService : ITask
{
    private readonly TodoContext _context;
    public TaskService(TodoContext context)
    {
        _context = context;
    }

    string ITask.CompleteTodo(int id)
    {
        Todo ? task = _context.Todos.SingleOrDefault(x=> x.Id == id);
        if (task is Todo)
        {
            if (task.IsCompleted == true)
            {
                return "updated already";
            } else
            {
                task.IsCompleted = true;
                task.TimeFullfilled= DateTime.Now;
                _context.SaveChanges();
                return "true";
            }
            
        }
        return "false";
    }

    Todo ITask.CreateTodo(string name)
    {
        Console.WriteLine(name);
        Todo task = new()
        {
            Name = name,
            TimeUploaded = DateTime.Now,
            IsCompleted = false
        };
        _context.Add(task);
        _context.SaveChanges();
        return task;
    }

    void ITask.DeleteTodo(int id)
    {
        var task = _context.Todos.Where(t=> t.Id == id).FirstOrDefault();
        if (task is Todo)
        {
            _context.Remove(task);
            _context.SaveChanges();
        }
    }

    Todo? ITask.GetTodoById(int id)
    {
        var task = _context.Todos.Where(p=> p.Id == id).FirstOrDefault();
        return task;
    }

    IEnumerable<Todo> ITask.GetTodos()
    {
        var tasks = _context.Todos.ToList();
        return tasks;
    }

    Todo ? ITask.UpdateTodo(int id, string name)
    {
        var task = _context.Todos.Where(p=> p.Id == id).FirstOrDefault();
        if(task is Todo) 
        {
            task.Name = name;
            task.TimeUpdated = DateTime.Now;
            _context.SaveChanges();
        }
        return task;
    }
}
