using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class UserRole
    {
        public Int64 UserId { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
