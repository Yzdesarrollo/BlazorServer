using Blazored.LocalStorage;
using BlazorServer.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorServer.Providers
{
    public class AuthProvider
    {
        private readonly AuthenticationStateProvider authenticationState;
        private readonly ILocalStorageService localStorage;

        public AuthProvider(AuthenticationStateProvider authenticationState,
            ILocalStorageService localStorage)
        {
            this.authenticationState = authenticationState;
            this.localStorage = localStorage;
        }

        public async Task<bool> Login(LoginModel model)
        {
            await localStorage.SetItemAsync<LoginModel>("token", model);
            ((MiAuthenticationState)authenticationState).SignIn(model);
            return true;
        }

        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("token");
            ((MiAuthenticationState)authenticationState).SignOut();
        }
    }
}
