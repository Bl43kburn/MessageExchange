namespace Presentation.Models.CreationModels.MessageModels;

public record MessageModel(string title, string body, DateTime creationDate, Guid account, Guid publisher);