using Blazored.LocalStorage;
using Bookmazon.Client.ViewModels;
using Bookmazon.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Bookmazon.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {

        private readonly ILoginViewModel _loginViewModel;
        private readonly ILocalStorageService _localStorageService;

        public CustomAuthStateProvider(ILoginViewModel loginviewmodel,  ILocalStorageService localStorageService)
        {
            _loginViewModel = loginviewmodel;
            _localStorageService = localStorageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            User? currentUser = await GetUserByJWTAsync();

            if (currentUser != null && currentUser.Email != null)
            {
                string userName;
                if(currentUser.CompanyName != null)
                {
                    userName = currentUser.CompanyName;
                }
                else if(currentUser.LastName != null && currentUser.FirstName != null)
                {
                    userName = currentUser.LastName + " " + currentUser.FirstName;
                }
                else if(currentUser.LastName != null)
                {
                    userName = currentUser.LastName;
                }
                else if(currentUser.FirstName != null)
                {
                    userName = currentUser.FirstName;
                }
                else
                {
                    userName = currentUser.Email;
                }
                //create a claims
                Claim[] getClaims()
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, userName));
                    claims.Add(new Claim(ClaimTypes.Email, currentUser.Email));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, Convert.ToString(currentUser.UserID)));
                    foreach (var role in currentUser.Roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.RoleName == null ? "" : role.RoleName.ToString()));
                    }
                    return claims.ToArray();
                }
                
                //create claimsIdentity
                var claimsIdentity = new ClaimsIdentity(getClaims(), "serverAuth");

                //create claimsPrincipal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                return new AuthenticationState(claimsPrincipal);
            }
            else
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async Task<User?> GetUserByJWTAsync()
        {
            //pulling the token from localStorage
            var jwtToken = await _localStorageService.GetItemAsStringAsync("jwt_token");
            if (jwtToken == null) return null;

            var test = await _loginViewModel.GetUserByJWTAsync(jwtToken);
            return test;
        }
    }
}
