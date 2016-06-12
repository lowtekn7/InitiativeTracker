using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker.Domain.Abstract
{
    public interface IDefaultRepository<T>
    {
        IEnumerable<T> items { get; }
        T Get(int id);
        T Save(T item);
        void Remove(int id);
    }
}
