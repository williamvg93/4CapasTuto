using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class PersonTypeRepo : GenericRepository<Persontype>, IPersonType
{
    private readonly ApiTutoContext _context;

    public PersonTypeRepo(ApiTutoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Persontype>> GetCustomerPersonType()
    {
        return await _context.Persontypes
        .Include(c => c.Customers)
        .Where(c => c.Name == "Employee")
        .ToListAsync();
    }

}