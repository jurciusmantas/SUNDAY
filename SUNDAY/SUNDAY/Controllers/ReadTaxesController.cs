using Microsoft.AspNetCore.Mvc;
using SUNDAY.Model.Services.ReadTaxes;
using System;
using System.Threading.Tasks;

namespace SUNDAY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadTaxesController : ControllerBase
    {
        private readonly IReadTaxesService _service;

        public ReadTaxesController(IReadTaxesService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTax(string municipality, DateTime date)
        {
            var taxes = await Task.Run(() => _service.GetTaxAsync(municipality, date));
            return CreatedAtAction(nameof(GetTax), taxes);
        }
    }
}
