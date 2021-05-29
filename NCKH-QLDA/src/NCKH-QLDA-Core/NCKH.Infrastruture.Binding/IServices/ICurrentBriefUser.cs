using Microsoft.AspNetCore.Http;
using NCKH.Infrastruture.Binding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NCKH.Infrastruture.Binding.IServices
{
    public interface ICurrentBriefUser
    {
        BriefUser CurrentLoginBriefUser(HttpContext context);
    }
}
