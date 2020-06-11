using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPatternSample.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> ListAll();

        T Add(T entity);
    }
}
