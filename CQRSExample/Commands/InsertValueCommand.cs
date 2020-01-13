using CQRSExample.Infrastructure;
using MediatR;

namespace CQRSExample.Commands
{
    // Command to insert a new record
    public class InsertValueCommand : IRequest, IQuery
    {
        public InsertValueCommand(int id, string newValue)
        {
            Id = id;
            NewValue = newValue;
        }

        public int Id { get; set; }

        public string NewValue { get; set; }
    }
}