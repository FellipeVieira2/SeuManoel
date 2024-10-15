using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeuManoel.Application.Embalar.Commands;

namespace SeuManoel.Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeuManoelController : ControllerBase
    {

        private readonly ISender _sender;

        public SeuManoelController( ISender sender)
        {
            _sender = sender;
        }   

        [HttpPost]
        public async Task<IActionResult> EmbalarAsync(EmbalarCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(result);
        }
    }
}
