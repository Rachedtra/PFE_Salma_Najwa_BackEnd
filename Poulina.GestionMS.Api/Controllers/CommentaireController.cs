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
    public class CommentaireController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentaireController(IMediator mediator)
        {
            _mediator = mediator;


        }
        // GET: api/Emp
        [HttpGet]
        public async Task<ActionResult<Commentaire>> GETAll()
        {
            var x = new GetAllQuery<Commentaire>();
            var result = await _mediator.Send(x);
            return Ok(result);
        }

        // GET: api/Emp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commentaire>> Get(Guid id)
        {
            var k = new GetQueryByID<Commentaire>(id);
            var result = await _mediator.Send(k);
            return Ok(result);
        }

        // POST: api/Emp
        [HttpPost]
        public async Task<ActionResult<Commentaire>> PostAsync(Commentaire entity)
        {
            var k = new AddGeneric<Commentaire>(entity);
            var result = await _mediator.Send(k);
            return Ok(result);
        }

        // PUT: api/Emp/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Commentaire>> Put([FromBody] Commentaire etu)
        {
            var k = new PutGeneric<Commentaire>(etu);
            var result = await _mediator.Send(k);
            return Ok(result);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Commentaire>> Delete(Guid id)
        {
            var k = new DeleteGeneric<Commentaire>(id);
            var result = await _mediator.Send(k);
            return Ok(result);
        }
    }
}