using BusinessLogicLayer.Anemic.DTO.MessagesDTOs;
using BusinessLogicLayer.Anemic.Mappers.AccountMappers;
using BusinessLogicLayer.Anemic.Mappers.MessagePublisherMappers;
using DataAccessLayer.Models.Messages;

namespace BusinessLogicLayer.Anemic.Mappers.MessagesMappers;

public static class BaseMessageMapper
{
    public static BaseMessageDTO AsDto(this Message message)
        => new BaseMessageDTO(message.Title, message.Body, message.CreationTime, message.Publisher.AsDto(), message.Id, message.Account.AsDto(), message.State);
}