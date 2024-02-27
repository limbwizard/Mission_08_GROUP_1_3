using System.ComponentModel.DataAnnotations;

namespace Mission_08_GROUP_1_3.Models
{
    public class TaskList
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Task {  get; set; }
        public string? DueDate { get; set; }
        [Required]
        public string Quadrant { get; set; }
        public bool? Completed { get; set; }
    }
}
