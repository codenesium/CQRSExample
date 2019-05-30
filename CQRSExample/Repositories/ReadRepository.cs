using CQRSExample.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSExample.Repositories
{
    /// <summary>
    /// The read side repository could be calling Elastic or some other data store. It could
    /// be calling a datastore that's replicated from the write side for performance reasons.
    /// </summary>
    public class ReadRepository : IReadRepository
    {
        private readonly IDataStore dataStore;

        public ReadRepository(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        /// <summary>
        /// This read repository only returns a list of strings without Id. This is different than the write side.
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> Values()
        {
            var items = await this.dataStore.SelectAll();
            return items.Select(x => x.Value).ToList();
        }
    }
}