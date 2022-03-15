using Blazored.LocalStorage;
using BlazorServer.Models;
using BlazorServer.Pages;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorServer.Providers
{
    public class MiAuthenticationState : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorage;

        public MiAuthenticationState(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //Si existe una variable llamada token en localstorage
            var token = await localStorage.GetItemAsync<LoginModel>("token");

            if (token == null || string.IsNullOrEmpty(token.Usuario))
            {
                // Claim principal es el usuario auntenticado (Son los datos que conforman la identidad de un usuario)
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            var usuarioAutenticado = SignIn(token);
            return new AuthenticationState(usuarioAutenticado);

        }

        public ClaimsPrincipal SignIn(LoginModel token)
        {
            var claims = new List<Claim>() // Lista d Claims
            {
                new Claim(ClaimTypes.Name, token.Usuario),
                new Claim(ClaimTypes.Email, token.Usuario)
            };

            var identity = new ClaimsIdentity(claims, "mitienda");

            // Un claim Principal siempre llevara como parametro un claim Identity
            var principal = new ClaimsPrincipal(identity);

            //Notificación
            var authState = Task.FromResult(new AuthenticationState(principal));
            NotifyAuthenticationStateChanged(authState);

            return principal;
        }

        public void SignOut()
        {
            var usuarioAnonimo = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(usuarioAnonimo));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
