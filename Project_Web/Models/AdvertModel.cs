using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Web.Models
{
    public class AdvertModel
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [Range(0, 10)]
        public int Rating { get; set; }
    }
}
