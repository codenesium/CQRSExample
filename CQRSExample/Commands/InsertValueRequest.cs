using CQRSExample.Infrastructure;
using MediatR;

namespace CQRSExample.Commands
{
    // Command to insert a new record
    public class InsertValueRequest : IRequest, IQuery
    {
        public int Id { get; set; }

        public string NewValue { get; set; }
    }
}