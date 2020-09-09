using System;
using System.ComponentModel.DataAnnotations;

namespace TipSoGo.Models
{
    public class Bulletin
    {
        [Required]
        public int BulletinIdx { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Contents { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int NumComments { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string CreatedDate { get; set; }
    }
}