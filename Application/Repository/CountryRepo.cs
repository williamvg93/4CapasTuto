using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class CountryRepo : GenericRepository<Country>, ICountry
{
    private readonly ApiTutoContext _context;

    public CountryRepo(ApiTutoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Country>> GetCountryStates()
    {
        return await _context.Countries
        .Include(s => s.States)
        .ToListAsync();
    }
    public async Task<IEnumerable<Country>> GetCountryStatesCities()
    {
        return await _context.Countries
        .Include(s => s.States)
        .ThenInclude(c => c.Cities)
        .ToListAsync();
    }
}