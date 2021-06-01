using Microsoft.AspNetCore.Mvc;
using NCKH.Infrastruture.Binding.Models;

namespace NCKH.Infrastruture.Binding
{
    public class CoreApiControllerBase : ControllerBase
    {
        public BriefUser CurrentUser
        {
            get
            {
                CurrentBriefUser _currentBriefUser = new CurrentBriefUser();
                var currentUser = _currentBriefUser.CurrentLoginBriefUser(HttpContext);
                //var currentUser = HttpContext.GetCurrentUser();
                //if (currentUser == null)
                //{
                //    HttpContext.Response.Redirect("/error/permission");
                //}
                return currentUser;
            }
        }
    }
}
