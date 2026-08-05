using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Application.Exceptions
{
    public sealed record ValidationError
   (
        string PropertyName,
        string ErrorMessage
    );
}
