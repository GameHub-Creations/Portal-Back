namespace SSO.Exceptions;

public class PasswordTooLongException: BehaviorException
{
    public PasswordTooLongException() : base(ErrorConstants.BadRequestStatus, ErrorConstants.PasswordIsTooLongCode,
        ErrorConstants.PasswordIsTooLongMessage)
    {
    }
}