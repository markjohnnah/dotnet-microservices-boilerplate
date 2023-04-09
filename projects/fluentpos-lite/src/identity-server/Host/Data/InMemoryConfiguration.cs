﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace FluentPOS.Lite.IDS.Data;

public static class InMemoryConfiguration
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResources.Phone(),
            new IdentityResources.Address(),
            new(Constants.StandardScopes.Roles, new List<string> {"role"})
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new(Constants.StandardScopes.CatalogApi),
            new(Constants.StandardScopes.CartApi)
        };

    public static IList<ApiResource> ApiResources =>
        new List<ApiResource>
        {
            new(Constants.StandardScopes.CatalogApi),
            new(Constants.StandardScopes.CartApi)
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                ClientId = "client",

                AllowedGrantTypes = { GrantType.ResourceOwnerPassword },

                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    Constants.StandardScopes.CatalogApi,
                    Constants.StandardScopes.CartApi
                }
            }
        };
}
