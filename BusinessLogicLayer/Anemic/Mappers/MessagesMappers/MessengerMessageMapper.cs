using BusinessLogicLayer.Anemic.DTO.MessagesDTOs;
using BusinessLogicLayer.Anemic.Mappers.AccountMappers;
using BusinessLogicLayer.Anemic.Mappers.MessagePublisherMappers;
using DataAccessLayer.Models.Messages;

namespace BusinessLogicLayer.Anemic.Mappers.MessagesMappers;

public static class MessengerMessageMapper
{
    public static MessengerMessageDTO AsDto(this MessengerMessage message)
        => new MessengerMessageDTO(message.Title, message.Body, message.CreationTime, message.Publisher.AsDto(), message.Id, message.Account.AsDto(), message.State, message.UserId);
}