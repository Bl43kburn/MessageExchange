using BusinessLogicLayer.Anemic.DTO;
using BusinessLogicLayer.Anemic.Mappers.MessagePublisherMappers;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Anemic.Mappers;

public static class DeviceCountPairMapper
{
    public static DeviceCountPairDTO AsDto(this DeviceCountPair pair)
        => new DeviceCountPairDTO(pair.Publisher.AsDto(), pair.Messages);
}