﻿using System;
using System.Collections.Generic;
using System.Text;
using Project_Processor.Models;

namespace Project_Processor.Factories
{
    public class UserProcessorModelFactory : IUserProcessorModelFactory
    {
        public IUserProcessorModel Create(string name, int id)
        {
            return new UserProcessorModel
            {
                Name = name,
                Id=id
            };
        }
    }
}
