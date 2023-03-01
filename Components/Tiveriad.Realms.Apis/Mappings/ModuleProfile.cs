using AutoMapper;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Realms.Apis.Contracts;

namespace Tiveriad.Realms.Apis.Mappings;
public class ModuleProfile : Profile
{
    public ModuleProfile()
    {
        CreateMap<Module, ModuleReaderModel>();
        CreateMap<Module, ModuleReduceModel>();
        CreateMap<ModuleWriterModel, Module>();
    }
}