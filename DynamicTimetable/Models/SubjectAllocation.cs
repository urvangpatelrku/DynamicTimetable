using System.ComponentModel.DataAnnotations;

namespace DynamicTimetable.Models
{
    public class SubjectAllocation
    {
        public string SubjectName { get; set; }

        [Required]
        public int Hours { get; set; }
    }
}
