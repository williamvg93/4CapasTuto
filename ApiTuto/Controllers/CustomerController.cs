using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTuto.Dtos.Get;
using ApiTuto.Dtos.Post;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTuto.Controllers;

public class CustomerController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
    {
        var costumers = await _unitOfWork.Customers.GetAllAsync();
        /* return Ok(costumers); */
        return _mapper.Map<List<CustomerDto>>(costumers);
    }

    /* [HttpGet("CountryStatesCities")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<StateCountryDto>>> CountryState()
    {
        var countries = await _unitOfWork.Countries.GetStateCountry();
        return _mapper.Map<List<StateCountryDto>>(countries);
    } */

    /* [HttpGet("CountryStatesCities")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CountryDto>>> CountryStatesCities()
    {
        var countries = await _unitOfWork.Countries.GetCountryStatesCities();
        return _mapper.Map<List<CountryDto>>(countries);
    } */

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerDto>> Get(int id)
    {
        var country = await _unitOfWork.Customers.GetByIdAsync(id);
        if (country == null)
        {
            return NotFound();
        }

        return _mapper.Map<CustomerDto>(country);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Customer>> Post(CustomerPDto customerPDto)
    {
        var customer = _mapper.Map<Customer>(customerPDto);

        this._unitOfWork.Customers.Add(customer);
        await _unitOfWork.SaveAsync();

        if (customer == null)
        {
            return BadRequest();
        }
        customerPDto.Id = customer.Id;
        return CreatedAtAction(nameof(Post), new { id = customerPDto.Id }, customerPDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CustomerPDto>> Put(int id, [FromBody] CustomerPDto customerPDto)
    {
        var customer = _mapper.Map<Customer>(customerPDto);

        if (customer.Id == 0)
        {
            customer.Id = id;
        }
        if (customer.Id != id)
        {
            return BadRequest();
        }
        if (customer == null)
        {
            return NotFound();
        }

        customerPDto.Id = customer.Id;
        _unitOfWork.Customers.Update(customer);
        await _unitOfWork.SaveAsync();
        return customerPDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        _unitOfWork.Customers.Remove(customer);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}