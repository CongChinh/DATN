using DataAccessLayer.Functions;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.UserBLL
{
    public class UserBLL
    {
        private IUser _user = new UserFunctions();
        public async Task<Boolean> CreateNewUser(string username, string password, string email)
        {
            
            var result = await _user.FindUserByEmail(email);
            if(result == null)
            {
                await _user.Adduser(username, password, email);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Boolean> Login(string email)
        {
            var user = await _user.FindUserByEmail(email);
            if (user.Email == email)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
