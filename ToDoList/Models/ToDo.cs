using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDo
    {

        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public bool IsDone { get; set; }
    }
}
