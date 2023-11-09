using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiTutoContext _context;
    private ICity _cities;
    private ICountry _countries;
    private ICustomer _customers;
    private IPersonType _peopleType;
    private IState _states;

    public UnitOfWork(ApiTutoContext context)
    {
        _context = context;
    }

    public ICity Cities
    {
        get
        {
            if (_cities == null)
            {
                _cities = new CityRepo(_context);
            }
            return _cities;
        }
    }
    public ICountry Countries
    {
        get
        {
            if (_countries == null)
            {
                _countries = new CountryRepo(_context);
            }
            return _countries;
        }
    }
    public ICustomer Customers
    {
        get
        {
            if (_customers == null)
            {
                _customers = new CustomerRepo(_context);
            }
            return _customers;
        }
    }
    public IPersonType PeopleTypes
    {
        get
        {
            if (_peopleType == null)
            {
                _peopleType = new PersonTypeRepo(_context);
            }
            return _peopleType;
        }
    }
    public IState States
    {
        get
        {
            if (_states == null)
            {
                _states = new StateRepo(_context);
            }
            return _states;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}
