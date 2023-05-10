using BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;
using BusinessLogicLayer.Anemic.DTO.MessagesDTOs;
using BusinessLogicLayer.Anemic.Mappers.AccountMappers;
using BusinessLogicLayer.Anemic.Mappers.MessagePublisherMappers;
using DataAccessLayer.Models.Messages;

namespace BusinessLogicLayer.Anemic.Mappers.MessagesMappers;

public static class EmailMessageMapper
{
    public static EmailMessageDTO AsDto(this EmailMessage message)
        => new EmailMessageDTO(message.Title, message.Body, message.CreationTime, message.Publisher.AsDto(), message.Id, message.Account.AsDto(), message.State, message.Email);
}