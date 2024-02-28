namespace SSO.Exceptions;

public class InvalidEmailFormatException : BehaviorException
{
    public InvalidEmailFormatException() : base(ErrorConstants.BadRequestStatus, ErrorConstants.InvalidEmailCode,
        ErrorConstants.InvalidEmailMessage)
    {
    }
}