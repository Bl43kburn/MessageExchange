using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;

namespace BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;

public record PhoneMessagePublisherDTO(IReadOnlyCollection<BasePublisherAccountDTO> accounts, Guid id, string phoneNumber) : BaseMessagePublisherDTO(accounts, id);