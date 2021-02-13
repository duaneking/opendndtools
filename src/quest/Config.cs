using IdentityServer4.Models;
using System.Collections.Generic;

namespace quest
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope> { new ApiScope("api", "Quest API") };

        public static IEnumerable<Client> Clients => new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // No interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api" }
                }
            };

        public static IEnumerable<IdentityResource> IdentityResources = new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        };
    }
}
