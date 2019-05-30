using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSExample.Infrastructure
{
    public class ValueObject
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

    /// <summary>
    /// This is a simple class to simulate how a database would function for the example
    /// </summary>
    public class DataStore : IDataStore
    {
        private readonly List<ValueObject> values = new List<ValueObject>();

        public async Task<List<ValueObject>> SelectAll()
        {
            await Task.CompletedTask;
            return this.values;
        }

        public async Task Insert(ValueObject value)
        {
            this.values.Add(value);
            await Task.CompletedTask;
        }
    }
}