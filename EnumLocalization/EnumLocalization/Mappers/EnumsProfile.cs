using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace EnumLocalization.Mappers
{
    public class EnumsProfile : Profile
    {
        public EnumsProfile()
        {
            CreateMap<Enum, string>()
                .ConvertUsing<EnumToStringConverter>();
        }
    }

    public class EnumToStringConverter : ITypeConverter<Enum, string>
    {
        public string Convert(Enum source, string destination, ResolutionContext context)
        {
            return source.ToDisplayString();
        }
    }
}