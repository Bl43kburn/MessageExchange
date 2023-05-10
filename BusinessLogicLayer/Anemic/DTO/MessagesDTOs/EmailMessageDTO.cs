using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;

namespace BusinessLogicLayer.Anemic.DTO.MessagesDTOs;

public record EmailMessageDTO(string title, string body, DateTime creationTime, BaseMessagePublisherDTO publisher, Guid id, BasePublisherAccountDTO account, string state, string email)
    : BaseMessageDTO(title, body, creationTime, publisher, id, account, state); 