using Project_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAdvertRepository AdvertRepository { get; }
        IUserRepository UserRepository { get; }
        IAdvertUserRepository AdvertUserRepository { get; }
        void Save();
    }
}
