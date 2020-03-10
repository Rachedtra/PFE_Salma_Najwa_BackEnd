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
    public class CategorieController : ControllerBase

    {
        private readonly IMediator _mediator;

        public CategorieController(IMediator mediator)
        {
            _mediator = mediator;


        }
        // GET: api/Emp
        [HttpGet]
        public async Task<ActionResult<Categorie>> GETAll()
        {
            var x = new GetAllQuery<Categorie>();
            var result = await _mediator.Send(x);
            return Ok(result);
        }

        // GET: api/Emp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie>> Get(Guid id)
        {
            var k = new GetQueryByID<Categorie>(id);
            var result = await _mediator.Send(k);
            return Ok(result);
        }

        // POST: api/Emp
        [HttpPost]
        public async Task<ActionResult<Categorie>> PostAsync(Categorie entity)
        {
            var k = new AddGeneric<Categorie>(entity);
            var result = await _mediator.Send(k);
            return Ok(result);
        }

        // PUT: api/Emp/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Categorie>> Put([FromBody] Categorie etu)
        {
            var k = new PutGeneric<Categorie>(etu);
            var result = await _mediator.Send(k);
            return Ok(result);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categorie>> Delete(Guid id)
        {
            var k = new DeleteGeneric<Categorie>(id);
            var result = await _mediator.Send(k);
            return Ok(result);
        }
    }
}