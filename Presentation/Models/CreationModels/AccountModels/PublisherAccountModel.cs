namespace Presentation.Models.CreationModels.AccountModels;

public record PublisherAccountModel(string login, string password) : BasePublisherAccountModel(login, password);