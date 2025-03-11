using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public int CreditHour { get; set; }
        public int DepartmentID { get; set; }

        public Department Department { get; set; } // There Department table PK as FK

    }
}
