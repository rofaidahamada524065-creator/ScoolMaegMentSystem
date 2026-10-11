using ScoolMaegMentSystem.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoolMaegMentSystem.DTOs.Enrollment
{
    public class EnrollmentDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
       
        public int CourceId { get; set; }
    
        public DateTime EnrollmentDate { get; set; }
   
        public double? Grade { get; set; }
    }
}
