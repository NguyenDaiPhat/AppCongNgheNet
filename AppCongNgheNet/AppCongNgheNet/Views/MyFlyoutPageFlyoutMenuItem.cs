﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCongNgheNet.Views
{

    public class MyFlyoutPageFlyoutMenuItem
    {
        public MyFlyoutPageFlyoutMenuItem()
        {
            TargetType = typeof(MyFlyoutPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
        public string IconSource { get; set; }
    }
}