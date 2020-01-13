using CQRSExample.Commands;
using CQRSExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ValuesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> Get()
        {
            return await this.mediator.Send(new ValuesRequest());
        }

        [HttpGet]
        [Route("create/{itemId:int}/{value}")]
        public async Task Create(int itemId, string value)
        {
            await this.mediator.Send(new InsertValueCommand(itemId, value));
        }
    }
}