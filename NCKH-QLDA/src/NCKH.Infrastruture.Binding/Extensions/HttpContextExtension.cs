using Microsoft.AspNetCore.Http;
using NCKH.Infrastruture.Binding.Helpers;
using NCKH.Infrastruture.Binding.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace NCKH.Infrastruture.Binding.Extensions
{
    public static class HttpContextExtension
    {
        public static BriefUser GetCurrentUser(this HttpContext context)
        {
            var userId = GetUserId(context);
            if (string.IsNullOrEmpty(userId))
                return new BriefUser
                {
                    IdAcount = string.Empty,
                    MaGiangVien = string.Empty,
                    FullName = string.Empty,
                  //Avatar = string.Empty,
                    Email = string.Empty,
                    IdBoMon = string.Empty,
                    PhoneNumber = string.Empty,
                    UserName = string.Empty,
                    Type = 0,
                    Languages = new List<string> { "vi-VN" }
                };

            var userInfoString = context.GetCurrentUserString();
            if (string.IsNullOrEmpty(userInfoString))
                return new BriefUser
                {
                    IdAcount = string.Empty,
                    MaGiangVien = string.Empty,
                    FullName = string.Empty,
                    //Avatar = string.Empty,
                    Email = string.Empty,
                    IdBoMon = string.Empty,
                    PhoneNumber = string.Empty,
                    UserName = string.Empty,
                    Type = 0,
                    Languages = new List<string> { "vi-VN" }
                };

            var userInfoStringDecrypted = EncryptionHelper.Decrypt(userInfoString, userId);
            var briefUser = JsonConvert.DeserializeObject<BriefUser>(userInfoStringDecrypted);
            return briefUser;
        }

        public static string GetUserId(this HttpContext context)
        {
            var payloadObject = ParseAccessToken(context);
            return payloadObject == null ? string.Empty : (string)payloadObject.Where(x => x.Type == "sub").Select(x => x.Value).SingleOrDefault();
        }

        public static string GetClientId(this HttpContext context)
        {
            var payloadObject = ParseAccessToken(context);
            return payloadObject == null ? string.Empty : (string)payloadObject.Where(x => x.Type == "client_id").Select(x => x.Value).SingleOrDefault();
        }

        private static string GetCurrentUserString(this HttpContext context)
        {
            var payloadObject = ParseAccessToken(context);
            return payloadObject == null ? string.Empty : (string)payloadObject.Where(x => x.Type == "ui").Select(x => x.Value).SingleOrDefault();
        }

        private static List<Claim> ParseAccessToken(HttpContext context)
        {
            if (context != null && (context.User.Identity is ClaimsIdentity identity))
            {
                var claims = identity.Claims.ToList();
                return claims;
            }
            return null;
        }
    }
}
