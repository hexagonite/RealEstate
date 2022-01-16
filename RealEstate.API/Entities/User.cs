using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RealEstate.API.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string EmailAddress { get; set; }
        public int UserTypeId { get; set; }

        [ForeignKey("UserTypeId")]
        public virtual UserType UserType { get; set; }
    }
}
