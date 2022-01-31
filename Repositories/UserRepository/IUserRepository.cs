using ProiectASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Repositories.UserRepository
{
   public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetByIdWithRoles(int id);
        Task<User> GetUserByEmail(string email);
    }
}
