using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;

namespace BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;

public record BaseMessagePublisherDTO(IReadOnlyCollection<BasePublisherAccountDTO> accounts, Guid id);