using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTuto.Dtos.Get;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTuto.Controllers;

public class PersonTypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonTypeDto>>> Get()
    {
        var peopleType = await _unitOfWork.PeopleTypes.GetAllAsync();
        /* return Ok(peopleType); */
        return _mapper.Map<List<PersonTypeDto>>(peopleType);
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
    public async Task<ActionResult<PersonTypeDto>> Get(int id)
    {
        var personType = await _unitOfWork.PeopleTypes.GetByIdAsync(id);
        if (personType == null)
        {
            return NotFound();
        }

        return _mapper.Map<PersonTypeDto>(personType);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persontype>> Post(PersonTypeDto personTypeDto)
    {
        var personType = _mapper.Map<Persontype>(personTypeDto);

        this._unitOfWork.PeopleTypes.Add(personType);
        await _unitOfWork.SaveAsync();

        if (personType == null)
        {
            return BadRequest();
        }
        personTypeDto.Id = personType.Id;
        return CreatedAtAction(nameof(Post), new { id = personTypeDto.Id }, personTypeDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonTypeDto>> Put(int id, [FromBody] PersonTypeDto personTypeDto)
    {
        var persontype = _mapper.Map<Persontype>(personTypeDto);

        if (persontype.Id == 0)
        {
            persontype.Id = id;
        }

        if (persontype.Id != id)
        {
            return BadRequest();
        }
        if (persontype == null)
        {
            return NotFound();
        }

        personTypeDto.Id = persontype.Id;
        _unitOfWork.PeopleTypes.Update(persontype);
        await _unitOfWork.SaveAsync();
        return personTypeDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var persontype = await _unitOfWork.PeopleTypes.GetByIdAsync(id);
        if (persontype == null)
        {
            return NotFound();
        }
        _unitOfWork.PeopleTypes.Remove(persontype);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}