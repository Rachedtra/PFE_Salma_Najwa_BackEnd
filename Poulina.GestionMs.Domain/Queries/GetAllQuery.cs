using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionMs.Domain.Queries
{
    public class GetAllQuery<T> : IRequest<IEnumerable<T>> where T : class
    {
    }
}
