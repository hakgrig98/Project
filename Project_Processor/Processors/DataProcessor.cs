using System;
using System.Collections.Generic;
using System.Text;
using Project_DAL.UnitOfWork;
using Project_Processor.Factories;
using Project_Processor.Models;

namespace Project_Processor.Processors
{
    public class DataProcessor : IDataProcessor
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdvertProcessorModelFactory _advertProcessorModelFactory;
        private readonly IUserProcessorModelFactory _userProcessorModelFactory;
        public DataProcessor(IUnitOfWork unitOfWork, IAdvertProcessorModelFactory advertProcessorModelFactory
            , IUserProcessorModelFactory userProcessorModelFactory)
        {
            _unitOfWork = unitOfWork;
            _advertProcessorModelFactory = advertProcessorModelFactory;
            _userProcessorModelFactory = userProcessorModelFactory;
        }
        public IList<IAdvertProcessorModel> GetAdverts()
        {
            var advertModels = new List<IAdvertProcessorModel>();

            foreach (var advert in _unitOfWork.AdvertRepository.FetchAll())
            {
                var users = new List<IUserProcessorModel>();
                foreach(var advertuser in advert.AdvertUser)
                {
                    users.Add(_userProcessorModelFactory.Create(advertuser.User.Name));
                }

                advertModels.Add(_advertProcessorModelFactory.Create(advert.Id, advert.CreatedDate, advert.Text, advert.Rating, users));
            }

            return advertModels;
        }
    }
}
