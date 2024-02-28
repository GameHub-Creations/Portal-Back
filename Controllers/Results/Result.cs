using SSO.Controllers.ResponseModels;

namespace SSO.Controllers.Results;

public struct Result
{
    public bool IsSucceeded { get; set; }

    private List<Error> _errors;

    private IResponse? _response;

    public Result()
    {
        IsSucceeded = false;
    }

    public static Result Success(IResponse? response = null)
    {
        return new Result
        {
            IsSucceeded = true,
            _response = response
        };
    }

    public IResponse? Response()
    {
        return _response;
    }
}