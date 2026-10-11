using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoolMaegMentSystem.Model
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public int CourceId { get; set; }
        [ForeignKey("CourceId")]
        public Course Course { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Range(0,10)]
        public double? Grade { get; set; }
    }
}
