using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Processor.Models
{
    public class AdvertProcessorModel : IAdvertProcessorModel
    {
        public int Number { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Text { get; set; }

        public int Rating { get; set; }

        public IList<IUserProcessorModel> Users { get; set; }
    }
}
