using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public string? AppointmentStatus { get; set; }
        [Required]
        public string? Date {  get; set; }

        public User user { get; set; }
        

        public RepairShop repairShop { get; set; }
        

        public Mobile mobile { get; set; }
        //public Services services { get; set; }
        

    }
}
