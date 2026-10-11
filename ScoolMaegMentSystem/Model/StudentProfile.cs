using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoolMaegMentSystem.Model
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string ParentPhone { get; set; }
        [Required]
        [Phone]
        public string EmergencyContact { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }

    }
}
