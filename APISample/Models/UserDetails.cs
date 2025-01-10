using System.ComponentModel.DataAnnotations;

namespace APISample.Models
{
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; } 
    }
}
