using System;

namespace RealEstate.API.DTOs
{
    public class PropertyStatisticsQueryDto
    {
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public string PropertyType { get; set; }
    }
}
