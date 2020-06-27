using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poulina.GestionMs.Domain.Commands;
using Poulina.GestionMs.Domain.Models;
using Poulina.GestionMs.Domain.Queries;

namespace Poulina.GestionMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SousCategorieController: ControllerBase
    { 
       private readonly IMediator _mediator;

    public SousCategorieController(IMediator mediator)
    {
        _mediator = mediator;


    }
    // GET: api/Emp
    [HttpGet]
    public async Task<ActionResult<sous_categorie>> GETAll()
    {
        var x = new GetAllQuery<sous_categorie>();
        var result = await _mediator.Send(x);
        return Ok(result);
    }

    // GET: api/Emp/5
    [HttpGet("{id}")]
    public async Task<ActionResult<sous_categorie>> Get(Guid id)
    {
        var k = new GetQueryByID<sous_categorie>(id);
        var result = await _mediator.Send(k);
        return Ok(result);
    }

    // POST: api/Emp
    [HttpPost]
    public async Task<ActionResult<sous_categorie>> PostAsync(sous_categorie entity)
    {
        var k = new AddGeneric<sous_categorie>(entity);
        var result = await _mediator.Send(k);
        return Ok(result);
    }

    // PUT: api/Emp/5
    [HttpPut]
    public async Task<ActionResult<sous_categorie>> Put([FromBody] sous_categorie etu)
    {
        var k = new PutGeneric<sous_categorie>(etu);
        var result = await _mediator.Send(k);
        return Ok(result);

    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<sous_categorie>> Delete(Guid id)
    {
        var k = new DeleteGeneric<sous_categorie>(id);
        var result = await _mediator.Send(k);
        return Ok(result);
    }
}
}