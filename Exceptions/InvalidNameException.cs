namespace SSO.Exceptions;

public class InvalidNameException : BehaviorException
{
    public InvalidNameException() : base(
        ErrorConstants.BadRequestStatus,
        ErrorConstants.InvalidNameCode,
        ErrorConstants.InvalidNameMessage)
    {
    }
}