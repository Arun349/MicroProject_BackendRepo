using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class FinalAppointment
    {
        [Key]
       public int FinalAppointmentId { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string? MobileModel { get; set;}
        [Required]
        public string? ProblemDescription { get; set; }

        [Required]
        public string? AppointmentStatus { get; set; }
        [Required]
        public string? RepairStatus { get; set; }

        
        public User user { get; set; }

        public RepairShop repairShop { get; set; }





    }
}
