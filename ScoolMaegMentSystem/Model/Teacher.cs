using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace ScoolMaegMentSystem.Model
{
    [Index(nameof(Email), IsUnique = true)]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public ICollection<Course> courses { get; set; } = new List<Course>();
    }
}
