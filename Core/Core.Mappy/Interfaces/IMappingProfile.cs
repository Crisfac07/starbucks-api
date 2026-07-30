using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Mappy.Interfaces
{
    public interface IMappingProfile
    {
        void Configure(IMapper mapper);
    }
}
