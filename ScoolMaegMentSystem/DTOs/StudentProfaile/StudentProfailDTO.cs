using System.ComponentModel.DataAnnotations;

namespace ScoolMaegMentSystem.DTOs.StudentProfaile
{
    public class StudentProfailDTO
    {
        public int Id { get; set; }
     
        public string Address { get; set; }
       
        public string ParentPhone { get; set; }
       
        public string EmergencyContact { get; set; }
        public int StudentId { get; set; }
    }
}
