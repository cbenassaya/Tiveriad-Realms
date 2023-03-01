using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Tiveriad.Realms.Applications.Commands.RoleCommands;

namespace Tiveriad.Realms.Apis.EndPoints.RoleEndPoints;
public class DeleteEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public DeleteEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpDelete("/api/modules/{moduleId}/roles/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> HandleAsync([Required][FromRoute] string id,[Required][FromRoute] string moduleId,  CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(moduleId))
            return BadRequest($"Feature id or Module id is mandatory");
        var result = await _mediator.Send(new DeleteRoleByIdRequest(id,moduleId), cancellationToken);
        //<-- END CUSTOM CODE-->
        return Ok(result);
    }
}