using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class StateRepo : GenericRepository<State>, IState
{
    private readonly ApiTutoContext _context;

    public StateRepo(ApiTutoContext context) : base(context)
    {
        _context = context;
    }
}