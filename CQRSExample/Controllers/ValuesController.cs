using CQRSExample.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRSExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesService valuesService;

        public ValuesController(IValuesService valuesService)
        {
            this.valuesService = valuesService;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<List<string>>> Get()
        {
            return await this.valuesService.Values();
        }

        // /api/values/create/1/test
        [HttpGet]
        [Route("create/{itemId:int}/{value}")]
        public async Task Create(int itemId, string value)
        {
            await this.valuesService.Insert(itemId, value);
        }
    }
}