using System.Threading.Tasks;

namespace CQRSExample.Repositories
{
    public interface IWriteRepository
    {
        Task Insert(int id, string newValue);
    }
}