using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ERP_Demo_WinForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if ((Process.GetProcessesByName(Application.ProductName).Length < 2))
            {
                if (new User_Folder.Login_Form().ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Main_Form());
                }
            }
        }
    }
}
