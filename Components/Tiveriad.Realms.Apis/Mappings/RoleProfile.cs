using AutoMapper;
using Tiveriad.Realms.Core.Entities;
using Tiveriad.Realms.Apis.Contracts;

namespace Tiveriad.Realms.Apis.Mappings;
public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleReaderModel>();
        CreateMap<RoleWriterModel, Role>();
    }
}