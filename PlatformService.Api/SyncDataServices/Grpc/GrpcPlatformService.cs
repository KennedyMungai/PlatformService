using AutoMapper;
using PlatformService.Api.Data;

namespace PlatformService.Api.SyncDataServices.Grpc;


public class GrpcPlatformService : GrpcPlatform.GrpcPlatformBase
{
    private readonly IPlatformRepo _repository;
    private readonly IMapper _mapper;

    public GrpcPlatformService(IPlatformRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

}