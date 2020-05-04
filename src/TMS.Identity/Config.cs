// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace TMS.Identity
{
    public static class Config
    {
        
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("teamrole", new [] { "teamrole" })
            };
        
        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("tmsapi", 
                    "Team Management System API", 
                    new [] { "teamrole" })
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            { 
                new Client
                {
                    ClientId = "tmsui",
                    ClientName = "Team Management System",
                    AllowedGrantTypes = GrantTypes.Hybrid, 
                    ClientSecrets = { new Secret("108B7B4F-BEFC-4DD2-82E1-7F025F0F75D0".Sha256()) },
                    RedirectUris = { "https://localhost:6001/signin-oidc" }, 
                    PostLogoutRedirectUris = { "https://localhost:6001/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    RequireConsent = false,
                    AllowedScopes = { "openid", "profile", "email", "tmsapi", "teamrole" }
                }
            };
    }
}