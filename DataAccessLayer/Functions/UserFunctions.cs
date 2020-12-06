 using DataAccessLayer.DataContext;
using DataAccessLayer.Interfaces;
using DataTransferObject;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Functions
{
    public class UserFunctions : IUser
    {
        public async Task<User> Adduser(string username, string password, string email)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));


            User newUser = new User
            {
                Username = username,
                Password = hashed,
                Email = email,
            };
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                await context.Users.AddAsync(newUser);
                await context.SaveChangesAsync();
            }
            return newUser;
        }

        public Task<User> DeleteUser(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindUserByEmail(string email)
        {
            var user = new User();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                user = await context.Users.Where(db => db.Email == email).FirstOrDefaultAsync();
            }
            return user;
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
