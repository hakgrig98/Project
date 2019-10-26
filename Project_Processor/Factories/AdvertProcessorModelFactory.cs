using System;
using System.Collections.Generic;
using System.Text;
using Project_Processor.Models;

namespace Project_Processor.Factories
{
    public class AdvertProcessorModelFactory : IAdvertProcessorModelFactory
    {
        public IAdvertProcessorModel Create(int number, DateTime createdDate, string text, int rating, IList<IUserProcessorModel> users)
        {
            return new AdvertProcessorModel
            {
                CreatedDate = createdDate,
                Number = number,
                Rating = rating,
                Text = text,
                Users = users
            };
        }
    }
}
