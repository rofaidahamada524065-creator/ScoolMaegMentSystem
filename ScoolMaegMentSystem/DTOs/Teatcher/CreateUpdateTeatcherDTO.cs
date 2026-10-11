using System.ComponentModel.DataAnnotations;

namespace ScoolMaegMentSystem.DTOs.Teatcher
{
    public class CreateUpdateTeatcherDTO
    {

       
        public string FullName { get; set; }
    
        public string Email { get; set; }
     
        public string Phone { get; set; }
      
        public DateTime HireDate { get; set; }
    }
}
