﻿using System;
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
    public class DemandeInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DemandeInfoController(IMediator mediator)
        {
            _mediator = mediator;


        }
        // GET: api/Emp
        [HttpGet]
        public async Task<ActionResult<Demande_information>> GETAll()
        {
            var x = new GetAllQuery<Demande_information>();
            var result = await _mediator.Send(x);
            return Ok(result);
        }

        // GET: api/Emp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Demande_information>> Get(Guid id)
        {
            var k = new GetQueryByID<Demande_information>(id);
            var result = await _mediator.Send(k);
            return Ok(result);
        }

        // POST: api/Emp
        [HttpPost]
        public async Task<ActionResult<Demande_information>> PostAsync(Demande_information entity)
        {
            var k = new AddGeneric<Demande_information>(entity);
            var result = await _mediator.Send(k);
            return Ok(result);
        }

        // PUT: api/Emp/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Demande_information>> Put([FromBody] Demande_information etu)
        {
            var k = new PutGeneric<Demande_information>(etu);
            var result = await _mediator.Send(k);
            return Ok(result);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Demande_information>> Delete(Guid id)
        {
            var k = new DeleteGeneric<Demande_information>(id);
            var result = await _mediator.Send(k);
            return Ok(result);
        }
    }
}