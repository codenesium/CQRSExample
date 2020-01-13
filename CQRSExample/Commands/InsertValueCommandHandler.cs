using CQRSExample.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSExample.Commands
{
    // inserts an item using the write side repository
    public class InsertValueCommandHandler : AsyncRequestHandler<InsertValueCommand>
    {
        private readonly IWriteRepository repository;

        public InsertValueCommandHandler(IWriteRepository repository)
        {
            this.repository = repository;
        }

        protected override Task Handle(InsertValueCommand request, CancellationToken cancellationToken)
        {
            this.repository.Insert(request.Id, request.NewValue);
            return Task.CompletedTask;
        }
    }
}