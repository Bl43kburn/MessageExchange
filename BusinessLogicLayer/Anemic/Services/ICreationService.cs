using BusinessLogicLayer.Anemic.DTO;
using BusinessLogicLayer.Anemic.DTO.AccountsDTOs;
using BusinessLogicLayer.Anemic.DTO.EmployeeDTOs;
using BusinessLogicLayer.Anemic.DTO.MessagePublisherDTOs;
using BusinessLogicLayer.Anemic.DTO.MessagesDTOs;
using DataAccessLayer.Models.Accounts;
using DataAccessLayer.Models.MessagePublisher;

namespace BusinessLogicLayer.Anemic.Services;

public interface ICreationService
{
    PublisherAccountDTO CreatePublisherAccount(string login, string password);
    
    EmployeeDTO CreateEmployee(string fullName, int age, string accountLogin, string accountPassword);

    MasterDTO CreateMaster(string fullName, int age, string accountLogin, string accountPassword);

    EmailMessagePublisherDTO CreateEmailPublisher(string email);

    MessengerMessagePublisherDTO CreateMessagePublisher(string userId);
    
    PhoneMessagePublisherDTO CreatePhonePublisher(string phoneNumber);

    EmailMessageDTO CreateEmailMessage(Guid account, Guid publisher, string title, string body, DateTime creationDate);

    MessengerMessageDTO CreateMessengerMessage(Guid account, Guid publisher, string title, string body, DateTime creationDate);

    PhoneMessageDTO CreateSmsMessage(Guid account, Guid publisher, string title, string body, DateTime creationDate);

    ReportDTO CreateReport(Guid sessionId, DateTime durationStart, DateTime durationEnd, DateTime creationDate);
}