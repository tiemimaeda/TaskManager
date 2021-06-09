using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApp.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {

    }
}
