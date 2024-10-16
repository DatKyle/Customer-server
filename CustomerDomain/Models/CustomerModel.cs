namespace CarApi.Models
{
    public record CustomerModel
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public string? City { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }

        public CustomerModel() { }

        public CustomerModel(string name, string address, string postalCode, string country, string phone, string? email)
        {
            Name = name;
            Address = address;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Email = email;
        }
    }
}
