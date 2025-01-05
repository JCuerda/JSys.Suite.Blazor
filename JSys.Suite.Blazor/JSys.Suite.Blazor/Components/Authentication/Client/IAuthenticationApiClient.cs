using JSys.Suite.Blazor.Components.Authentication.Client.Response;
using JSys.Suite.Blazor.Shared;
using Microsoft.AspNetCore.Identity.Data;
using Refit;
using LoginRequest = JSys.Suite.Blazor.Components.Authentication.Client.Request.LoginRequest;

namespace JSys.Suite.Blazor.Components.Authentication.Client;

public interface IAuthenticationApiClient
{
	[Post("/auth/login")]
	public Task<Result<AuthenticationResponse, AuthenticationFailureResponse>> Login(LoginRequest loginRequest);
	
	[Post("/auth/register")]
	public Task<RegisterRequest> Register(RegisterRequest registerRequest);
}