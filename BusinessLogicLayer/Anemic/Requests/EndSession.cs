using MediatR;

namespace BusinessLogicLayer.Anemic.Requests;

public record EndSession(Guid sessionId) : IRequest;