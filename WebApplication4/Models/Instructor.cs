using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ARank { get; set; }
        public int DepartmentID { get; set; }

        public Department Department { get; set; }
    }
}
