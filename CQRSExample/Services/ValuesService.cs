using CQRSExample.Commands;
using CQRSExample.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSExample.Services
{
    /// <summary>
    /// In a lot of examples mediator is used directly from the controller. I prefer
    /// to make a service layer and keep the controller as thin as possible. In a small
    /// application using the mediator from the controller isn't an issue but as an app grows
    /// you may need to do other things that don't belong in a a command handler and then your controller
    /// starts growing warts.
    /// </summary>
    public class ValuesService : IValuesService
    {
        private readonly IMediator mediator;

        public ValuesService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // This method will return all items by calling the read side
        public async Task<List<string>> Values()
        {
            return await this.mediator.Send(new ValuesRequest());
        }

        // This method will insert a record using the write side
        public async Task Insert(int itemId, string value)
        {
            await this.mediator.Send(new InsertValueRequest()
            {
                Id = itemId,
                NewValue = value
            });
        }
    }
}