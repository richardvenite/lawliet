using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace lawliet
{
    public class ProviderTokenAccess : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var username = "master";
            var password = "123456";

            if (username != context.UserName && password != context.UserName)
            {
                context.SetError("invalid_grant", "Uset not found or invalid.");
                return;
            }

            var identityUser = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identityUser);
        }
    }
}