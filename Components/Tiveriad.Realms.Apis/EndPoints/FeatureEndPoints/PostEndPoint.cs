using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using Tiveriad.Realms.Apis.Contracts;
using System.Threading;
using Tiveriad.Realms.Applications.Commands.FeatureCommands;
using Tiveriad.Realms.Core.Entities;

namespace Tiveriad.Realms.Apis.EndPoints.FeatureEndPoints;
public class PostEndPoint : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public PostEndPoint(IMapper mapper, IMediator mediator)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("/api/modules/{moduleId}/features")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FeatureReaderModel>> HandleAsync([FromBody] FeatureWriterModel model,[Required][FromRoute] string moduleId, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (string.IsNullOrEmpty(moduleId))
            return BadRequest($"Module id is mandatory");
        var entity = _mapper.Map<FeatureWriterModel, Feature>(model);
        var result = await _mediator.Send(new SaveFeatureRequest(entity, moduleId), cancellationToken);
        var data = _mapper.Map<Feature, FeatureReaderModel>(result);
        //<-- END CUSTOM CODE-->
        return Ok(data);
    }
}