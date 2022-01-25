using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RealEstate.API.Entities
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int RoomAmount { get; set; }
        public decimal Size { get; set; }
        public DateTime UploadedAt { get; set; }
        public virtual Address Address { get; set; }

        [ForeignKey("PropertyTypeId")]
        public virtual PropertyType PropertyType { get; set; }
        public int PropertyTypeId { get; set; }

        //public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    }
}
