using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoolMaegMentSystem.Model
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [Range(1,6)]
        public int CreditHours { get; set; }

        public int TeatcherId { get; set; }
        [ForeignKey("TeatcherId")]
        public Teacher Teacher { get; set; }

        public ICollection<Enrollment> enrollments { get; set; } = new List<Enrollment>();
    }
}
