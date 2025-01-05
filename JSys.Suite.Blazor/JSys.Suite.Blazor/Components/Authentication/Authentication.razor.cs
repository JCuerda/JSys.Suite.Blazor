using System.Diagnostics;
using System.Text.Json;
using JSys.Suite.Blazor.Components.Authentication.Client;
using JSys.Suite.Blazor.Components.Authentication.Client.Response;
using Microsoft.AspNetCore.Components;
using Radzen;
using Refit;
using LoginRequest = JSys.Suite.Blazor.Components.Authentication.Client.Request.LoginRequest;

namespace JSys.Suite.Blazor.Components.Authentication;

public partial class Authentication : ComponentBase
{
	[Inject] public required IAuthenticationApiClient AuthenticationApiClient { get; init; }

	[Parameter]
	public LoginRequest? Request { get; set; }
	
	[Parameter]
	public AuthenticationFailureResponse? AuthenticationFailureResponse { get; set; }
	
	// Variant variant = Variant.Flat;
	private bool popup = false;

	protected override void OnInitialized() => Request ??= new LoginRequest();

	private async Task Login(LoginRequest request)
	{
		try
		{
			var response = await AuthenticationApiClient.Login(request);
			Console.WriteLine(response);
		}
		catch (ApiException ex)
		{
			AuthenticationFailureResponse = await ex.GetContentAsAsync<AuthenticationFailureResponse>();
		}
	}
}