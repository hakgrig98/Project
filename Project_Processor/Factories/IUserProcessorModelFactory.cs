using Project_Processor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Processor.Factories
{
    public interface IUserProcessorModelFactory
    {
        IUserProcessorModel Create(string name);
    }
}
