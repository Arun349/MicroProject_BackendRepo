using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Mobile
    {
        [Key]
        public int MobileId { get; set; }
        [Required]
        public string? Mobile_ModelName { get; set; }
        [Required]
        public string? problemDescription { get; set; }


        public User user { get; set; }
        
    }
}
