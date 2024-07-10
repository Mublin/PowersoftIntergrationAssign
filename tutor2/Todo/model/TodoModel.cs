namespace Todo.model;

public record TodoModel(int Id, string Name, DateTime dueDate, bool isCompleted);
