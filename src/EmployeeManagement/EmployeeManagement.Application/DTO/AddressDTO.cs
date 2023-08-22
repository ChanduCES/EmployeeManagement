namespace EmployeeManagement.Application.DTO
{
    public record AddressDTO
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
