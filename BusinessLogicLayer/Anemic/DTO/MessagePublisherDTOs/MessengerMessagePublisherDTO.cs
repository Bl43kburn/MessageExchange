using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;

namespace BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;

public record MessengerMessagePublisherDTO(IReadOnlyCollection<BasePublisherAccountDTO> accounts, Guid id, string userId) : BaseMessagePublisherDTO(accounts, id);