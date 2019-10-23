using System;
using System.Collections.Generic;
using System.Text;
using Project_DAL.Repositories;

namespace Project_DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext dbContext;
        private bool disposed = false;

        public IAdvertRepository AdvertRepository { get; }

        public IUserRepository UserRepository { get; }

        public IAdvertUserRepository AdvertUserRepository { get; }

        public UnitOfWork(IAdvertRepository advertRepository, IUserRepository userRepository,
            IAdvertUserRepository advertUserRepository, ProjectContext context)
        {
            this.AdvertRepository = advertRepository;
            this.UserRepository = userRepository;
            this.AdvertUserRepository = advertUserRepository;
            this.dbContext = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }
    }
}
