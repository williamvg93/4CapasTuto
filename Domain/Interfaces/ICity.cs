using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

public interface ICity : IGenericRepository<City>
{
    Task<IEnumerable<City>> GetPersonByCity(int id);
    Task<IEnumerable<City>> GetCustomersForEachCity();
}