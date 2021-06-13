using IdentityServer4.Models;
using System.Collections.Generic;

namespace Au.Authentication
{
    public class Config
    {
        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource("role",new []{ "role", "admin", "user" } )
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("GHM_NailSpa_Api", "GHM NailSpa API managerment resources.")
                {
                    ApiSecrets = new List<Secret>
                    {
                        new Secret("GHMSOFT".Sha256())
                    },
                    Scopes = new List<string>
                    {
                        "GHM_NailSpa"
                    },
                    UserClaims = { "role", "admin", "user"}
                },
                new ApiResource("GHM_Core_Api", "GHM Core API managerment resources.")
                {
                    ApiSecrets = new List<Secret>
                    {
                        new Secret("GHMSOFT".Sha256())
                    },
                    Scopes = new List<string>
                    {
                        "GHM_Core"
                    },
                    UserClaims = { "role", "admin", "user"}
                }

            };

        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("GHM_NailSpa", "GHM NailSpa API managerment resources.",new List<string> { "role", "admin", "user"}),
                new ApiScope("GHM_Core", "GHM Core API managerment resources.",new List<string> { "role", "admin", "user"})
       
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
               new Client
                { 
                     ClientId = "GHMSOFTCLIENT",
                     ClientName = "GHMSOFT_CLIENT",
                     Enabled = true,
                     AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                     AccessTokenType = AccessTokenType.Reference,
                     AccessTokenLifetime = 86400,  //thời gian token 86400
                     IdentityTokenLifetime = 86400,
                     AuthorizationCodeLifetime = 86400,
                     UpdateAccessTokenClaimsOnRefresh = true,
                     SlidingRefreshTokenLifetime = 86400,
                     AbsoluteRefreshTokenLifetime = 86400,
                     AllowOfflineAccess = true,
                     RefreshTokenExpiration = TokenExpiration.Absolute,
                     RefreshTokenUsage = TokenUsage.OneTimeOnly,
                     AlwaysSendClientClaims = true,
                     RequireClientSecret = true,

                    ClientSecrets =
                    {
                        new Secret("GHMSOFT".Sha256())
                    },
                    AllowedScopes = {
                       "GHM_Gateway",
                       "GHM_NailSpa" ,
                       "GHM_Notification" ,
                       "GHM_FileManagement",
                       "GHM_Website",
                       "GHM_Core",
                       "GHM_FireBase",
                       "GHM_OnJob",
                       "openid" ,
                       "profile" ,
                       "email" ,
                       "role",
                       "offline_access"
                   },
            
            //RedirectUris = new List<string>
            //{
            //    "https://localhost:3000",
            //},

            AllowedCorsOrigins = new List<string>
                    {
                        "https://localhost:3000",
                        "http://localhost:8001",
                        "http://localhost:8002",
                        "http://localhost:8009",
                        "http://103.48.193.200",
                        "https://103.48.193.200",
                        "https://quanlydoan.live",
                        "http://nailspa.vj-soft.com",
                        "https://quanlydoan.live",
                        "https://nailspa.vj-soft.com",
                        "http://spa.ghmsoft.vn",
                        "https://spa.ghmsoft.vn",
                        "http://quanlyspa.ghmsoft.vn",
                        "https://quanlyspa.ghmsoft.vn",
                        "http://quanlyspa.jadespa.vn",
                        "https://quanlyspa.jadespa.vn",
                        "http://nailspa-dev.vj-soft.com",
                        "https://nailspa-dev.vj-soft.com",
                        "http://192.168.1.160:3000"
                    },

                    //PostLogoutRedirectUris = new List<string>
                    //{
                    //    "https://localhost:3000",
                    //},
                }
            };
        }


    }
}
