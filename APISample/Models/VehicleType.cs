using System.ComponentModel.DataAnnotations;

namespace APISample.Models
{
    public class VehicleType
    {
        [Key]
        public int Pk_VehicleTypeId { get; set; }
        [Required]
        public string VehicleCategory { get; set; } = null!;
        public string? Remark { get; set; }
        public bool IaActive { get; set; }
        [Required]
        public DateTime CreateOn { get; set; }= DateTime.Now;

    }
}
