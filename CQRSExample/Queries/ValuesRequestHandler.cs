using CQRSExample.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSExample.Queries
{
    // returns all of the items using the read side repository
    public class ValuesRequestHandler : IRequestHandler<ValuesRequest, List<string>>
    {
        private readonly IReadRepository repository;

        public ValuesRequestHandler(IReadRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<string>> Handle(ValuesRequest request, CancellationToken cancellationToken)
        {
            return await this.repository.Values();
        }
    }
}