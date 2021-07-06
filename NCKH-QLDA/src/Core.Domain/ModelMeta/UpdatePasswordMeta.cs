using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.ModelMeta
{
    public class UpdatePasswordMeta
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public bool IsResetPassword { get; set; }

        public UpdatePasswordMeta()
        {
            IsResetPassword = false;
        }
    }
}
