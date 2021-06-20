using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NCKH.Infrastruture.Binding.Extensions;
using NCKH.Infrastruture.Binding.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCKH.Infrastruture.Binding.Models
{
    public class CurrentBriefUser : ControllerBase, ICurrentBriefUser
    {
        public BriefUser CurrentLoginBriefUser(HttpContext context)
        {
            if (context == null)
            {
                return new BriefUser
                {
                    IdAcount = string.Empty,
                    MaGiangVien = string.Empty,
                    FullName = string.Empty,
                    Email = string.Empty,
                    IdBoMon = string.Empty,
                    PhoneNumber = string.Empty,
                    UserName = string.Empty,
                    Type = 0,
                    Languages = new List<string> { "vi-VN" }
                };
            }
            return context.GetCurrentUser();
        }
    }
}
