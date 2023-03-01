using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using Tiveriad.Realms.Apis.Contracts;
using System.Threading;
using Tiveriad.Realms.Applications.Commands.RoleCommands;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Apis.EndPoints.RoleEndPoints;
public class PostEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public PostEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/modules/{moduleId}/roles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RoleReaderModel>> HandleAsync([FromBody] RoleWriterModel model,[Required][FromRoute] string moduleId,  CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(moduleId))
            return BadRequest($"Module id is mandatory");
        var entity = _mapper.Map<RoleWriterModel, Role>(model);
        var result = await _mediator.Send(new SaveRoleRequest(entity,moduleId), cancellationToken);
        var data = _mapper.Map<Role, RoleReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}