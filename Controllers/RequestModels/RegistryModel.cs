using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using SSO.Exceptions;

namespace SSO.Controllers.RequestModels;

public class RegistryModel
{
    [Required] public string Email { get; }
    [Required] public string Password { get; }
    [Required] public string Name { get; }

    //NameRules
    private const int NameMaxLength = 27;
    private const string NameRegex = @"^[a-zA-Z0-9!#$%&'*+—\/=?^_`{|}~]+$";

    //EmailRules
    private const int EmailMaxLength = 65;
    private const string EmailRegex =
        @"^(?=[a-zA-Z])[a-zA-Z0-9!#$%&'*+—\/=?^_`{|}~]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";
    
    //PasswordRules
    private const string PasswordRegex = @"^(?![0-9]+$)[a-zA-Z0-9!#$%&'*+—\/=?^_`{|}~]+$";
    private const int PasswordMaxLenght = 129;
    


    public RegistryModel(string email, string password, string name)
    {
        if (name.Length > NameMaxLength)
        {
            throw new NameIsTooLongException();
        }

        if (!Regex.IsMatch(name, NameRegex))
        {
            throw new InvalidNameException();
        }

        Name = name;

        if (email.Length > EmailMaxLength)
        {
            throw new EmailIsTooLongException();
        }

        if (!Regex.IsMatch(email, EmailRegex))
        {
            throw new InvalidEmailFormatException();
        }

        Email = email;
        
        if (password.Length > PasswordMaxLenght)
        {
            throw new PasswordTooLongException();
        }

        if (!Regex.IsMatch(password, PasswordRegex))
        {
            throw new InvalidPasswordException();
        }

        Password = password;
    }
}