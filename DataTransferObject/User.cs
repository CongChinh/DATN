using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataTransferObject
{
    public class User
    {
        [Key]
        public Int64 Id { get; set; }
        [Required(ErrorMessage = "Username name is required")]
        [StringLength(40)]
        public String Username { get; set; }
        [Required(ErrorMessage = "Password name is required")]
        [StringLength(50)]
        public String Password { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Address { get; set; }
        [Required(ErrorMessage = "Email name is required")]
        [StringLength(50)]
        public String Email { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

    }
}
