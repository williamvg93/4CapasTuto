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

    public async Task<IEnumerable<City>> GetPersonByCity()
    {
        /* return await _context.Cities
        .Include(p => p.Customers)
        .ToListAsync(); */
        /*         var data = (from ci in _context.Cities
                            join cus in _context.Customers
                            on ci.Id equals cus.IdCityFk
                            where ci.Name == "bucaramanga"
                            select new City
                            {
                            }).ToListAsync();
         */
        return await _context.Cities
        .Include(c => c.Customers).Where(c => c.Name == "Bucaramanga")
        .ToListAsync();
        /*         return await _context.Cities
                .Include(c => c.Customers)
                .ToListAsync(); */
    }
}