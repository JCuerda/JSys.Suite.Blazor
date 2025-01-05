namespace JSys.Suite.Blazor.Components.Authentication.Client.Request;

public class RegistrationRequest
{
	public required int EmployeeId { get; init; }
    
	public required string Username { get; init; }
    
	public required string Password { get; init; }
    
	public required string RePassword { get; init; }
}