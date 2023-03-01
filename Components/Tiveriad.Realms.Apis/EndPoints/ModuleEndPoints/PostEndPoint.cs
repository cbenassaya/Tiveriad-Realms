using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using Tiveriad.Realms.Apis.Contracts;
using System.Threading;
using Tiveriad.Realms.Applications.Commands.ModuleCommands;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Apis.EndPoints.ModuleEndPoints;
public class PostEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public PostEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/modules")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ModuleReaderModel>> HandleAsync([FromBody] ModuleWriterModel model, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        var entity = _mapper.Map<ModuleWriterModel, Module>(model);
        var result = await _mediator.Send(new SaveModuleRequest(entity), cancellationToken);
        var data = _mapper.Map<Module, ModuleReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}