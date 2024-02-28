namespace SSO.Exceptions;

public class InvalidPasswordException: BehaviorException
{
    public InvalidPasswordException() : base(ErrorConstants.BadRequestStatus, ErrorConstants.InvalidPasswordCode,
        ErrorConstants.InvalidPasswordMessage)
    {
    }
}