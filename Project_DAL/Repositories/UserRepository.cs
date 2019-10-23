using flip_flop_dal;
using Project_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context) 
            : base(context)
        {
        }
    }
}
