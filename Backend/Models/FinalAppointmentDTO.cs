using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class FinalAppointmentDTO
    {

        [Key]
        public int FinalAppointmentId { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string? MobileModel { get; set; }
        [Required]
        public string? ProblemDescription { get; set; }

        [Required]
        public string? AppointmentStatus { get; set; }
        [Required]
        public string? RepairStatus { get; set; }

        public int UserId { get; set; }
        public int RepairShopId { get; set; }
    }
}
