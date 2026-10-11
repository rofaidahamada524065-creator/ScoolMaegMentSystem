using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ScoolMaegMentSystem.Model
{
    [Index(nameof(Email),IsUnique =true)]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public StudentProfile StudentProfile { get; set; }

        public ICollection<Enrollment> enrollments { get; set; } = new List<Enrollment>();
    }
}
