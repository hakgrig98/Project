using System;
using System.Collections.Generic;
using System.Text;
using Project_DAL.Entities;
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

        public string AddAdvert(int number, DateTime createdDate, string text, int userId, int rating)
        {
            string responseText = "Ok";

            try
            {
                var advert = new Advert
                {
                    CreatedDate = createdDate,
                    Number = number,
                    Rating = rating,
                    Text = text,
                };

                if (userId == -1)//userId=-1 means all users
                {
                    foreach (var user in _unitOfWork.UserRepository.FetchAll())
                    {
                        _unitOfWork.AdvertUserRepository.Add(new AdvertUser
                        {
                            Advert = advert,
                            User = user
                        });
                    }
                }
                else
                {
                    _unitOfWork.AdvertUserRepository.Add(new AdvertUser
                    {
                        Advert = advert,
                        UserId = userId
                    });
                }
            }
            catch (Exception ex)
            {
                //TODO:Needs to log exception
                responseText = "Something happend with adding advert to database";
            }
           
            return responseText;
        }

        public IList<IAdvertProcessorModel> GetAdverts()
        {
            var advertModels = new List<IAdvertProcessorModel>();

            foreach (var advert in _unitOfWork.AdvertRepository.FetchAll())
            {
                var users = new List<IUserProcessorModel>();
                foreach (var advertuser in advert.AdvertUser)
                {
                    users.Add(_userProcessorModelFactory.Create(advertuser.User.Name, advertuser.User.Id));
                }

                advertModels.Add(_advertProcessorModelFactory.Create(advert.Id, advert.CreatedDate, advert.Text, advert.Rating, users));
            }

            return advertModels;
        }

        public IList<IUserProcessorModel> GetUsers()
        {
            var userModels = new List<IUserProcessorModel>();

            foreach (var user in _unitOfWork.UserRepository.FetchAll())
            {
                userModels.Add(_userProcessorModelFactory.Create(user.Name,user.Id));
            }

            return userModels;
        }
    }
}
