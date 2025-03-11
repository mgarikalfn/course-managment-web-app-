using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Offering
    {
        [Key]
        public int OfferingID { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }

        public Course? Course { get; set; }
        public Instructor? Instructor { get; set; }

    }
}
