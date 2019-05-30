using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSExample.Infrastructure
{
    public interface IDataStore
    {
        Task Insert(ValueObject value);

        Task<List<ValueObject>> SelectAll();
    }
}