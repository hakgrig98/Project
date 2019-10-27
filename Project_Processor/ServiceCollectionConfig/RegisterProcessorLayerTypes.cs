using Microsoft.Extensions.DependencyInjection;
using Project_Processor.Factories;
using Project_Processor.Processors;
using Project_DAL.ServiceCollectionConfig;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Project_Processor.ServiceCollectionConfig
{
    public static class RegisterProcessorLayerTypes
    {
        public static void RegisterProcessorLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.RegisterDataAccessLayer(configuration);

            serviceCollection.AddScoped<IAdvertProcessorModelFactory, AdvertProcessorModelFactory>();
            serviceCollection.AddScoped<IUserProcessorModelFactory, UserProcessorModelFactory>();
            serviceCollection.AddScoped<IDataProcessor, DataProcessor>();
        }
    }
}
