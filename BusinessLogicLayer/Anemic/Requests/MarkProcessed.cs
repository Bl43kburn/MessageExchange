using MediatR;

namespace BusinessLogicLayer.Anemic.Requests;

public record MarkProcessed(Guid sessionId, Guid messageId) : IRequest;