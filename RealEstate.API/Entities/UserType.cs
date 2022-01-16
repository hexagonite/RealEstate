using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstate.API.Entities
{
    public class UserType : BaseEntity
    {
        public string Name { get; set; }
    }
}
