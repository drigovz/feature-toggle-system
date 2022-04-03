using FeatureToggle.Application.Core.FeatureFlags.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FeatureToggle.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FeatureFlagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureFlagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FeatureFlagCreateCommand request)
            => Ok(await _mediator.Send(request));
    }
}
