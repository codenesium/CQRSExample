using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSExample.Services
{
    public interface IValuesService
    {
        Task Insert(int itemId, string value);

        Task<List<string>> Values();
    }
}