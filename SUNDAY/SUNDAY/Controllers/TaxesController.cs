using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUNDAY.Model.Services.Taxes;
using System;
using System.Threading.Tasks;

namespace SUNDAY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxesController : ControllerBase
    {
        private readonly ITaxesService _service;

        public TaxesController(ITaxesService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTax(string municipalityName, DateTime date)
        {
            var tax = await Task.Run(() => _service.GetTax(municipalityName, date));
            if (tax == null)
                return NotFound();

            return Ok(tax);
        }
    }
}
