using Core.Mappy.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Mappy.Interfaces
{
    public interface IMapper
    {
        void CreateMap<TSource, TDestination>();

        void CreateMap<TSource, TDestination>(
            Action<MapperConfiguration<TSource, TDestination>> configure);

        TDestination Map<TDestination>(object source);

    }

}
