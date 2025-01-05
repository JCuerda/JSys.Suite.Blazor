namespace JSys.Suite.Blazor.Components.Authentication.Client.Response;

public sealed record ErrorResponse(string Code, int ErrorType, string Message);

public class AuthenticationFailureResponse
{
	public IEnumerable<ErrorResponse> Errors { get; init; } = [];

	public bool HasErrors { get; init; } = true;
}