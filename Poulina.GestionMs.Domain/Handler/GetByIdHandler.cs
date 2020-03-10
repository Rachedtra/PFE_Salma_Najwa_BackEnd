using MediatR;
using Poulina.GestionMs.Domain.Interface;
using Poulina.GestionMs.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poulina.GestionMs.Domain.Handler
{

    public class GetByIdHandler<T> : IRequestHandler<GetQueryByID<T>, T> where T : class
    {
        private readonly IRepository<T> repository;
        public GetByIdHandler(IRepository<T> Repository)
        {
            repository = Repository;
        }

        public Task<T> Handle(GetQueryByID<T> request, CancellationToken cancellationToken)
        {
            var result = repository.GetById(request.Id);
            return Task.FromResult(result);
        }
    }
}