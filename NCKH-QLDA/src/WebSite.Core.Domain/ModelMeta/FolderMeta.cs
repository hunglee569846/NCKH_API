using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite.Core.Domain.ModelMeta
{
    public class FolderMeta
    {
        public string NamePath { get; set; }
        public int Level { get; set; }
        public int ChildCount { get; set; }
        public string Description { get; set; }
    }
}
