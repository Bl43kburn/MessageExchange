using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;

namespace BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;

public record EmailMessagePublisherDTO(string email, Guid id, IReadOnlyCollection<BasePublisherAccountDTO> accounts) : BaseMessagePublisherDTO(accounts, id);