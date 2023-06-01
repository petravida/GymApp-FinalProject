using System.Security.Claims;
using System.Threading.Tasks;
using GYM4URepository;
using GYM4URepositpry;
using Microsoft.Owin.Security.OAuth;

namespace GYM4UService
{
    public class MyAuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (TestRepository _repo = new TestRepository())
            {
                var user = _repo.IsActiveUser();
                if (user == null)
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                //identity.AddClaim(new Claim(ClaimTypes.Role, user.Id));
                //identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                //identity.AddClaim(new Claim("Email", user.UserEmailID));

                context.Validated(identity);
            }
        }
    }
}
