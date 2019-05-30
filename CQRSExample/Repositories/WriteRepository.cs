using CQRSExample.Infrastructure;
using System.Threading.Tasks;

namespace CQRSExample.Repositories
{
    public class WriteRepository : IWriteRepository
    {
        private readonly IDataStore dataStore;

        public WriteRepository(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public async Task Insert(int id, string newValue)
        {
            await this.dataStore.Insert(new ValueObject()
            {
                Id = id,
                Value = newValue
            });
        }
    }
}