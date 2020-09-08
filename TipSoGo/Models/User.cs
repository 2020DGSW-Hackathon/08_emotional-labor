using System.ComponentModel.DataAnnotations;

namespace TipSoGo.Models
{
    public class User
    {
        [Required]
        public int UserIdx { get; set; }
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserType { get; set; }
    }
}