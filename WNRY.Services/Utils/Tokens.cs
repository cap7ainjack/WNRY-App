using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WNRY.Models.IdentityModels;
using WNRY.Models.ViewModels;
using WNRY.Services.Identity;

namespace WNRY.Services.Utils
{
    public class Tokens
    {
        public static async Task<TokenVM> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            TokenVM response = new TokenVM()
            {
                // id = identity.Claims.Single(c => c.Type == "id").Value,
                Auth_token = await jwtFactory.GenerateEncodedToken(userName, identity),
                Expires_in = (int)jwtOptions.ValidFor.TotalSeconds
            };

            return response;
        }
    }
}