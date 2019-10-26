using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Processor.Models
{
    public interface IAdvertProcessorModel
    {
        int Number { get; }
        DateTime CreatedDate { get; }
        string Text { get; }
        int Rating { get; }
        IList<IUserProcessorModel> Users { get; }
    }
}
