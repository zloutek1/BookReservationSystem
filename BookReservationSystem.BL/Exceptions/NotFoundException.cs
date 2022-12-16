using System.Runtime.Serialization;

namespace BookReservationSystem.BL.Exceptions;

public class NotFoundException: ServiceException
{
    public NotFoundException()
    {
    }

    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public NotFoundException(string? message) : base(message)
    {
    }

    public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}