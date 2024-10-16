using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarApi.Models;

namespace CarApi.Domain.Models.Validators
{
    public interface ICustomerValidator
    {

        public bool Validate(CustomerModel customer);

    }
}
