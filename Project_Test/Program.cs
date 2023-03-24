﻿using Form_List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Search_Dropdown_Test
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Infragistics.Win.AppStyling.StyleManager.Load(Application.StartupPath + @"\LightGreen.isl"); // infragistics 테마 설정
            Application.Run(new MainFrame());
        }
    }
}
