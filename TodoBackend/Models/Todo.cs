using System.ComponentModel.DataAnnotations;

namespace TodoBackend.Models;

public class Todo 
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Required]
    public DateTime TimeUploaded { get; set; }
    public DateTime? TimeUpdated { get; set; }

    public DateTime? TimeFullfilled { get; set; }
    public bool IsCompleted { get; set; }



};
