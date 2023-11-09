using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTuto.Dtos;
using AutoMapper;
using Domain.Entities;

namespace ApiTuto.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<City, CityDto>()
        .ReverseMap();

        CreateMap<Country, CountryDto>()
        .ReverseMap();
    }
}
