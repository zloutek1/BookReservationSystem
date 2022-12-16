using System.Runtime.Serialization;

namespace BookReservationSystem.BL.Exceptions;

public class ServiceException: Exception
{
    public ServiceException()
    {
    }

    protected ServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public ServiceException(string? message) : base(message)
    {
    }

    public ServiceException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}