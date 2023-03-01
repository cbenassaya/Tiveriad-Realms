using AutoMapper;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Realms.Apis.Contracts;

namespace Tiveriad.Realms.Apis.Mappings;
public class FeatureProfile : Profile
{
    public FeatureProfile()
    {
        CreateMap<Feature, FeatureReaderModel>();
        CreateMap<FeatureWriterModel, Feature>();
    }
}