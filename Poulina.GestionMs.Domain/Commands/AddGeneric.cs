using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionMs.Domain.Commands
{
  public class AddGeneric<T> : IRequest<string> where T : class
    {
        public AddGeneric(T obj)
        {

            Obj = obj;
        }
        public T Obj { get; }
    }
}
