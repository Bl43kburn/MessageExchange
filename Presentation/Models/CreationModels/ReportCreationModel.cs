namespace Presentation.Models.CreationModels;

public record ReportCreationModel(Guid sessionId, DateTime durationStart, DateTime durationEnd, DateTime creationDate);