using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class FinalService
    {
        [Key]
        public int FinalServiceId { get; set; }
        [Required]

        public User user { get; set; }
        public RepairShop repairShop { get; set; }
        public FinalAppointment finalappointment { get; set; }

    }
}
