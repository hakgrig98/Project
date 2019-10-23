using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_DAL.Entities
{
    public class Advert
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public ICollection<AdvertUser> AdvertUser { get; set; }
    }
}
