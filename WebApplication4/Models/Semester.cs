using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }
        public string SemesterName { get; set; } = "";
        public int SemesterNo { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
