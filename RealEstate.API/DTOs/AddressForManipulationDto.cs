namespace RealEstate.API.DTOs
{
    public abstract class AddressForManipulationDto
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string StateOrProvince { get; set; }
        public string City { get; set; }
    }
}
