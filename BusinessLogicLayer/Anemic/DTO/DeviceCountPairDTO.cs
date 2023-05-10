using BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;

namespace BusinessLogicLayer.Anemic.DTO;

public record DeviceCountPairDTO(BaseMessagePublisherDTO publisher, int messages);