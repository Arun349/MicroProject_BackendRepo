using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class RepairShop
    {
        [Key]
        public int ShopId { get; set; }
        [Required]
        public string? ShopName { get; set; }
        [Required]
        public string? Email { get; set;}
        [Required]
        public int ShopContactNo { get; set; }
        [Required]
        public string? ShopAddress { get; set; }
        [Required]
        public int LicenseNo { get; set; }
        [Required]
        public string? Password {  get; set; }


    }
}
