using System.Text.RegularExpressions;
using CarApi.Domain.Models.Validators;
using CarApi.Models;

namespace CarApi.Business.Customer
{
    public class CustomerValidator : ICustomerValidator
    {        
        private readonly IEmailValidator _emailValidator;
        private readonly IPhoneValidator _phoneValidator;

        public CustomerValidator(IEmailValidator emailValidator, IPhoneValidator phoneValidator)
        {
            _emailValidator = emailValidator;
            _phoneValidator = phoneValidator;
        }

        public bool Validate(CustomerModel customer)
        {

            ThrowIfStringValueEmpty(customer.Name, nameof(customer.Name));
            ThrowIfStringValueEmpty(customer.Address, nameof(customer.Address));
            ThrowIfStringValueEmpty(customer.Country, nameof(customer.Country));
            ThrowIfStringValueEmpty(customer.PostalCode, nameof(customer.PostalCode));

            if (!_phoneValidator.Validate(customer.Phone))
                throw new ArgumentException($"Invalid phone number: {customer.Phone}");

            if (customer.Email != null && !_emailValidator.Validate(customer.Email))
                throw new ArgumentException($"Invalid email number: {customer.Email}");

            return true;
        }

        private void ThrowIfStringValueEmpty(string value, string fieldname)
        {
            if (value == null || value == "")
                throw new ArgumentException($"{fieldname} is required");
        }
    }
}
