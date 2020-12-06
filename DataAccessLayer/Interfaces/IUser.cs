using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUser
    {
        Task<User> Adduser(string username, string password, string email);

        Task<List<User>> GetAllUsers();

        Task<User> GetUser(long Id);

        Task<User> UpdateUser(long Id);

        Task<User> DeleteUser(long Id);
        Task<User> FindUserByEmail(string email);
    }
}
