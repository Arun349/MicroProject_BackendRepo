using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class FinalServiceDTO
    {

        [Key]
        public int FinalServiceId { get; set; }
        [Required]

        public int UserId { get; set; }
        public int RepairShopId { get; set; }
        public int FinalAppointmentId { get; set; }
    }
}
