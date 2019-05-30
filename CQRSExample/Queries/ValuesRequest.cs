using CQRSExample.Infrastructure;
using MediatR;
using System.Collections.Generic;

namespace CQRSExample.Queries
{
    // query to return all of the items
    public class ValuesRequest : IRequest<List<string>>, ICommand
    {
    }
}