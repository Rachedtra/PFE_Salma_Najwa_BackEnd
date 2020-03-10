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
   public class AddHandler<T> : IRequestHandler<AddGeneric<T>, string> where T : class
    {
        private readonly IRepository<T> repository;
        public AddHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }
       

        public Task<string> Handle(AddGeneric<T> request, CancellationToken cancellationToken)
        {
            var result = repository.Add(request.Obj);
            return Task.FromResult(result);
        }
    }
}