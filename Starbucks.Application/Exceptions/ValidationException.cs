using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationError> Errors { get; }

        public ValidationException(IEnumerable<ValidationError> errors)
        {
            Errors = errors;
        }
    }
}
