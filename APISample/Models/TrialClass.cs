using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISample.Models
{
    public class TrialClass
    {
        [Key]
        public int Pk_Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Contact { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
    }
}
