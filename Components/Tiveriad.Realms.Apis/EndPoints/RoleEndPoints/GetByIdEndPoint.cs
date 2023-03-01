using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using Tiveriad.Realms.Apis.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Tiveriad.Realms.Applications.Queries.RoleQueries;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Apis.EndPoints.RoleEndPoints;
public class GetByIdEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public GetByIdEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("/api/modules/{moduleId}/roles/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RoleReaderModel>> HandleAsync([Required][FromRoute] string id, [Required][FromRoute] string moduleId, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(moduleId))
            return BadRequest($"Feature id or Module id is mandatory");
        var result = await _mediator.Send(new GetRoleByIdRequest(id,moduleId), cancellationToken);
        if (result == null)
            return NoContent();
        var data = _mapper.Map<Role, RoleReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}