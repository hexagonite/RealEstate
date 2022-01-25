using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstate.API.Entities
{
    public class PropertyType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
