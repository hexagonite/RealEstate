using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RealEstate.API.Entities
{
    public class Image
    {
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public int PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
    }
}
