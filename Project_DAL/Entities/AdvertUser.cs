using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DAL.Entities
{
    public class AdvertUser
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int AdvertId { get; set; }
        public virtual Advert Advert { get; set; }
    }
}
