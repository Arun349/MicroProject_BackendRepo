using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Services
    {
        [Key]
        public int ServiceId { get; set; }
        public string? Repair_Status { get; set; }
        public User? user { get; set; }

        public RepairShop? repairShop { get; set; }

        public Mobile mobile { get; set; }

        public Appointment? appointment { get; set; }
       
    }
}
