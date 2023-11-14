using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

public interface ICountry : IGenericRepository<Country>
{
    Task<IEnumerable<Country>> GetCountryStates();
    Task<IEnumerable<Country>> GetCountryStatesCities();
}