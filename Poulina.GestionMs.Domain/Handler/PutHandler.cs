using MediatR;
using Poulina.GestionMs.Domain.Commands;
using Poulina.GestionMs.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poulina.GestionMs.Domain.Handler
{
    public class PutHandler<T> : IRequestHandler<PutGeneric<T>, string> where T : class
    {
        private readonly IRepository<T> repository;
        public PutHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }



        public Task<string> Handle(PutGeneric<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Update(request.Obj);
            return Task.FromResult(result);
        }
    }
}