using System;
using System.Collections.Generic;
using System.Text;

namespace NCKH.Infrastruture.Binding.ModelBinders
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class DefaultFromBodyAttribute : Attribute
    {
    }
}
