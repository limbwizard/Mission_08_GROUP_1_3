using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission_08_GROUP_1_3.Models
{
    public class ToDo
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskDesc {  get; set; }
        public string? DueDate { get; set; }
        [Required]
        public string Quadrant { get; set; }
        public bool? Completed { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
    }
}
