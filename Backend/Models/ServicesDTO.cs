namespace Backend.Models
{
    public class ServicesDTO
    {
        public int ServiceId { get; set; }
        public string? Repair_Status { get; set; }
        public int UserId { get; set; }

        public int RepairShopId { get; set; }
        public int MobileId { get; set; }
        public int AppointmentId { get; set; }
    }
}
