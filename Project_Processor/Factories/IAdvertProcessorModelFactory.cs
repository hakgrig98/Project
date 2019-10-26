using Project_Processor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Processor.Factories
{
    public interface IAdvertProcessorModelFactory
    {
        IAdvertProcessorModel Create(int number, DateTime createdDate, string text, int rating, IList<IUserProcessorModel> users);
    }
}
