namespace SSO.Exceptions;

public static class ErrorConstants
{
    public const int ConflictStatus = 409;
    public const int BadRequestStatus = 400;

    public const string InvalidNameCode = "InvalidName";
    public const string InvalidNameMessage = "The Name does not match the conditions";
    
    public const string UserAlreadyExistsCode = "UserAlreadyExist";
    public const string UserAlreadyExistsMessage = "The user with current email already exist";
    
    public const string InvalidCredentialsCode = "InvalidCredentials";
    public const string InvalidCredentialsMessage = "Invalid email or password";

    public const string PasswordIsTooLongCode = "PasswordIsTooLong";
    public const string PasswordIsTooLongMessage = "The Password is longer than 128 characters";

    public const string InvalidPasswordCode = "InvalidPassword";
    public const string InvalidPasswordMessage = "The Password does not match the conditions";
    
    public const string TokenIsExpiredCode = "TokenIsExpired";
    public const string TokenIsExpiredMessage = "Token is expired";

    public const string InvalidEmailCode = "InvalidEmail";
    public const string InvalidEmailMessage = "The Email does not match the conditions";

    public const string NameIsTooLongCode = "NameIsTooLong";
    public const string NameIsTooLongMessage = "The Name is longer than 26 characters";

    public const string EmailIsTooLongCode = "EmailIsTooLong";
    public const string EmailIsTooLongMessage = "The Email is longer than 64 characters";
}