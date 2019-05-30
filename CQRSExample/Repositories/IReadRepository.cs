using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSExample.Repositories
{
    public interface IReadRepository
    {
        Task<List<string>> Values();
    }
}