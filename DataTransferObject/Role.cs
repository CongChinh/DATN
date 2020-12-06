using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataTransferObject
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String NormalizedName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
