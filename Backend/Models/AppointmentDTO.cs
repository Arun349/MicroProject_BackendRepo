using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class AppointmentDTO
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public string? AppointmentStatus { get; set; }
        [Required]
        public string? Date { get; set; }

        public int UserId { get; set; }
        public int MobileId { get; set; }
        public int RepairShopId { get; set; }
        //public int ServicesId { get; set; }
    }
}
