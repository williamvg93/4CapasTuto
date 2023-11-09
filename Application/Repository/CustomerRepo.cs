using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class CustomerRepo : GenericRepository<Customer>, ICustomer
{
    private readonly ApiTutoContext _context;

    public CustomerRepo(ApiTutoContext context) : base(context)
    {
        _context = context;
    }
}
