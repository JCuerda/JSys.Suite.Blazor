using System.Text.Json;
using JSys.Suite.Blazor.Components.Authentication.Model;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace JSys.Suite.Blazor.Components.Authentication;

public partial class Authentication : ComponentBase
{
	[Parameter]
	public User? User { get; set; }
	
	Variant variant = Variant.Flat;
	private bool popup = false;

	protected override void OnInitialized() => User ??= new User();

	void Login(User user)
	{
		Console.WriteLine(JsonSerializer.Serialize(user));
	}
}