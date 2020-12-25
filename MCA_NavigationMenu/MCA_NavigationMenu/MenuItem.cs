using System;
using System.Collections.Generic;
using System.Text;

namespace MCA_NavigationMenu
{
    public class MenuItem
    {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public int? ParentID { get; set; }
        public bool IsHidden { get; set; }
        public string LinkUrl { get; set; }

    }
}
