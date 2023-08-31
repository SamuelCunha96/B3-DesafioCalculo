using B3.DesafioCalculo.Business.Features.Calculo.Commands.CalculoCDB;
using B3.DesafioCalculo.Shared.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace B3.DesafioCalculo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvestimentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("calcular-cdb")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CalculoInvestimentoCDBCommandVM))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponseDTO<object>))]

        public async Task<IActionResult> CalcularCdbAsync([FromBody] CalculoInvestimentoCDBCommand command) 
        {
            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }
    }
}
