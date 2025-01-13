using System.ComponentModel.DataAnnotations;

namespace APISample.Models.Auth
{
    public class HostDetails
    {
        [Key]
        public int Host_Id { get; set; }
        public string Ipaddress { get; set; } = null!;
        public int AccessCount { get; set; } = 1;
        public bool isActive { get; set; } = true;
        public DateTime ActivityTime { get; set; } = DateTime.Now;
    }
}
