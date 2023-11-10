using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTuto.Dtos.Get;
using ApiTuto.Dtos.Post;
using ApiTuto.Dtos.Querys;
using AutoMapper;
using Domain.Entities;

namespace ApiTuto.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<City, CityDto>()
        .ReverseMap();
        CreateMap<City, CityPDto>()
        .ReverseMap();
        CreateMap<City, CityCustomerDto>()
        .ReverseMap();

        CreateMap<Country, CountryDto>()
        .ReverseMap();
        CreateMap<Country, CountryCityDto>()
        .ReverseMap();

        CreateMap<State, StateDto>()
        .ReverseMap();
        CreateMap<State, StatePDto>()
        .ReverseMap();
        CreateMap<State, StateListCitiesDto>()
        .ReverseMap();

        CreateMap<Persontype, PersonTypeDto>()
        .ReverseMap();

        CreateMap<Customer, CustomerDto>()
        .ReverseMap();
        CreateMap<Customer, CustomerPDto>()
        .ReverseMap();
    }
}
