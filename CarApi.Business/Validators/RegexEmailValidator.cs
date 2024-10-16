using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CarApi.Domain.Models.Validators;

namespace CarApi.Business.Validators
{
    public class RegexEmailValidator : IEmailValidator
    {
        private readonly string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        public bool Validate(string email)
        {
            return Regex.IsMatch(email, EmailPattern);
        }
    }
}
