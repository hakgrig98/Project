using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AdvertUser> AdvertUser { get; set; }
    }
}
