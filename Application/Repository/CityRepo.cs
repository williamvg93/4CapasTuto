using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class CityRepo : GenericRepository<City>, ICity
{
    private readonly ApiTutoContext _context;

    public CityRepo(ApiTutoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<City>> GetPersonByCity(int id)
    {
        return await _context.Cities
        .Include(c => c.Customers).Where(c => c.Id == id)
        .ToListAsync();
    }

    public async Task<IEnumerable<City>> GetCustomersForEachCity()
    {
        return await _context.Cities
        .Include(c => c.Customers)
        .ToListAsync();
    }
}