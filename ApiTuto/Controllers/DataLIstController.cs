using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTuto.Dtos.Querys;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace ApiTuto.Controllers;

public class DataListController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DataListController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet("CountryStateCity")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CountryCityDto>>> CountryStateCity()
    {
        var dataList = await _unitOfWork.Countries.GetCountryStatesCities();
        return _mapper.Map<List<CountryCityDto>>(dataList);
    }

    [HttpGet("CityCustomers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CityCustomerDto>>> CityCustomers()
    {
        var cities = await _unitOfWork.Cities.GetCustomersForEachCity();
        return _mapper.Map<List<CityCustomerDto>>(cities);
    }

    [HttpGet("CityCustomersById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CityCustomerDto>>> CityCustomersById(int id)
    {
        var dataList = await _unitOfWork.Cities.GetPersonByCity(id);
        if (dataList == null)
        {
            return NotFound();
        }
        return _mapper.Map<List<CityCustomerDto>>(dataList);
    }

    [HttpGet("CustomerTypePerson")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CustomerTypePerDto>>> CustomerTypePerson()
    {
        var customer = await _unitOfWork.PeopleTypes.GetCustomerPersonType();

        return _mapper.Map<List<CustomerTypePerDto>>(customer);
    }
}
