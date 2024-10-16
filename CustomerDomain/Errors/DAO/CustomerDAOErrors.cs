using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApi.Domain.Errors.DAO
{
    public class RecordExists : Exception
    {
        public RecordExists(string? message) : base(message) { }
    }

    public class RecordDoesNotExists : Exception {
        public RecordDoesNotExists(string? message) : base(message) { }
    }
}
