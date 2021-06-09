using SimpleWebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApp.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
    }
}
