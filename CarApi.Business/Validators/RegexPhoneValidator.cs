using System.Text.RegularExpressions;
using CarApi.Domain.Models.Validators;

namespace CarApi.Business.Validators
{
    public class RegexPhoneValidator : IPhoneValidator
    {
        private readonly string phoneNumberPattern = @"^\+?(\d{1,3})?[-.\s]?(\(?\d{2,4}\)?)[-.\s]?\d{3,4}[-.\s]?\d{4,4}(\s?(ext|x|extension)\s?\d{1,5})?$";
        public bool Validate(string phone)
        {
            return Regex.IsMatch(phone, phoneNumberPattern);
        }
    }
}
