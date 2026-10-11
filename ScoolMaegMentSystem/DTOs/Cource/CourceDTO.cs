using System.ComponentModel.DataAnnotations;

namespace ScoolMaegMentSystem.DTOs.Cource
{
    public class CourceDTO
    {
        public int Id { get; set; }
       
        public string Title { get; set; }
    
        public int CreditHours { get; set; }

        public int TeatcherId { get; set; }
     
    }
}
