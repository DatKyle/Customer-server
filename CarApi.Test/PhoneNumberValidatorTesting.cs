using CarApi.Business.Customer;
using CarApi.Business.Validators;
using CarApi.Models;

namespace CarApi.Test
{
    public class CustomerValidatorTesting
    {
        CustomerModel CUSTOMER_VALID = new()
        {
            Name = "Kyle Burns",
            Address = "1 Freeburn Causeway",
            Country = "UK",
            PostalCode = "CV4",
            Phone = "07772225555"
        };

        CustomerModel CUSTOMER_WITH_VALID_EMAIL = new()
        {
            Name = "Kyle Burns",
            Address = "1 Freeburn Causeway",
            Country = "UK",
            PostalCode = "CV4",
            Phone = "07772225555",
            Email = "t@e.st"
        };

        CustomerModel CUSTOMER_WITH_INVALID_PHONE = new()
        {
            Name = "Kyle Burns",
            Address = "1 Freeburn Causeway",
            Country = "UK",
            PostalCode = "CV4",
            Phone = "0777"
        };

        CustomerModel CUSTOMER_WITH_INVALID_EMAIL = new()
        {
            Name = "Kyle Burns",
            Address = "1 Freeburn Causeway",
            Country = "UK",
            PostalCode = "CV4",
            Phone = "07772225555",
            Email = "t.e.st"
        };

        static CustomerModel CUSTOMER_WITH_BLANK_NAME = new()
        {
            Name = "",
            Address = "1 Freeburn Causeway",
            Country = "UK",
            PostalCode = "CV4",
            Phone = "07772225555"
        };

        CustomerModel CUSTOMER_WITH_BLANK_ADDRESS = new()
        {
            Name = "Kyle Burns",
            Address = "",
            Country = "UK",
            PostalCode = "CV4",
            Phone = "07772225555"
        };

        CustomerModel CUSTOMER_WITH_BLANK_COUNTRY = new()
        {
            Name = "Kyle Burns",
            Address = "1 Freeburn Causeway",
            Country = "",
            PostalCode = "CV4",
            Phone = "07772225555"
        };

        CustomerModel CUSTOMER_WITH_BLANK_POSTALCODE = new()
        {
            Name = "Kyle Burns",
            Address = "1 Freeburn Causeway",
            Country = "UK",
            PostalCode = "",
            Phone = "07772225555"
        };

        [Fact]
        public void ShouldValidateValidCustomer()
        {
            CustomerValidator validator = new CustomerValidator(new RegexEmailValidator(), new RegexPhoneValidator());
            bool result = validator.Validate(CUSTOMER_VALID);
            Assert.True(result);
        }

        [Fact]
        public void ShouldValidateCustomerWithValidEmails()
        {
            CustomerValidator validator = new CustomerValidator(new RegexEmailValidator(), new RegexPhoneValidator());
            bool result = validator.Validate(CUSTOMER_WITH_VALID_EMAIL);
            Assert.True(result);
        }

        [Fact]
        public void ShouldValidateCustomerWithInvalidPhone()
        {
            CustomerValidator validator = new CustomerValidator(new RegexEmailValidator(), new RegexPhoneValidator());
            Assert.Throws<ArgumentException>(() => validator.Validate(CUSTOMER_WITH_INVALID_PHONE));
        }

        [Fact]
        public void ShouldValidateCustomerWithInvalidEmails()
        {
            CustomerValidator validator = new CustomerValidator(new RegexEmailValidator(), new RegexPhoneValidator());
            Assert.Throws<ArgumentException>(() => validator.Validate(CUSTOMER_WITH_INVALID_EMAIL));
        }

        [Fact]
        public void ShouldValidateCustomerWithMissingNameFields()
        {
            CustomerValidator validator = new CustomerValidator(new RegexEmailValidator(), new RegexPhoneValidator());
            Assert.Throws<ArgumentException>(() => validator.Validate(CUSTOMER_WITH_BLANK_NAME));
        }

        [Fact]
        public void ShouldValidateCustomerWithMissingAddressFields()
        {
            CustomerValidator validator = new CustomerValidator(new RegexEmailValidator(), new RegexPhoneValidator());
            Assert.Throws<ArgumentException>(() => validator.Validate(CUSTOMER_WITH_BLANK_ADDRESS));
        }

        [Fact]
        public void ShouldValidateCustomerWithMissingPostalCodeFields()
        {
            CustomerValidator validator = new CustomerValidator(new RegexEmailValidator(), new RegexPhoneValidator());
            Assert.Throws<ArgumentException>(() => validator.Validate(CUSTOMER_WITH_BLANK_POSTALCODE));
        }

        [Fact]
        public void ShouldValidateCustomerWithMissingCountryFields()
        {
            CustomerValidator validator = new CustomerValidator(new RegexEmailValidator(), new RegexPhoneValidator());
            Assert.Throws<ArgumentException>(() => validator.Validate(CUSTOMER_WITH_BLANK_COUNTRY));
        }
    }
}