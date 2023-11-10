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

public class StateController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StateController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<StateDto>>> Get()
    {
        var states = await _unitOfWork.States.GetAllAsync();
        return Ok(states);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StateDto>> Get(int id)
    {
        var state = await _unitOfWork.States.GetByIdAsync(id);
        if (state == null)
        {
            return NotFound();
        }
        return _mapper.Map<StateDto>(state);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<State>> Post(StatePDto statePDto)
    {
        var state = _mapper.Map<State>(statePDto);

        this._unitOfWork.States.Add(state);
        await _unitOfWork.SaveAsync();

        if (state == null)
        {
            return BadRequest();
        }
        statePDto.Id = state.Id;
        return CreatedAtAction(nameof(Post), new { id = statePDto.Id }, statePDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StatePDto>> Put(int id, [FromBody] StatePDto statePDto)
    {
        var state = _mapper.Map<State>(statePDto);

        if (state.Id == 0)
        {
            state.Id = id;
        }
        if (state.Id != id)
        {
            return BadRequest();
        }
        if (state == null)
        {
            return NotFound();
        }

        statePDto.Id = state.Id;
        _unitOfWork.States.Update(state);
        await _unitOfWork.SaveAsync();
        return statePDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var state = await _unitOfWork.States.GetByIdAsync(id);
        if (state == null)
        {
            return NotFound();
        }
        _unitOfWork.States.Remove(state);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

}
