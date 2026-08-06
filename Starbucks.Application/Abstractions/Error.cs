using System;
using System.Collections.Generic;
using System.Text;

namespace Starbucks.Application.Abstractions
{
    public record Error
    (
        string Code,
        string Message
    );
}
