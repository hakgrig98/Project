using Project_Processor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Processor.Processors
{
    public interface IDataProcessor
    {
        IList<IAdvertProcessorModel> GetAdverts();
    }
}
