using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module.TemplateForm
{
    public partial class Template_Form : Form
    {
        public Template_Form()
        {
            InitializeComponent();

            string stylePath = Application.StartupPath + "/Skins";

            if (System.IO.Directory.Exists(stylePath))
            {
                vs = System.IO.Directory.GetFiles(stylePath, "*.ssk");
                skinEngine1.SkinFile = vs[10];
            }
        }

        private readonly string[] vs = null;

        private int styleIndex = 0;

        public void SetFormStyle(int styleIndex)
        {
            if (styleIndex >= 0 && styleIndex < vs.Length)
            {
                skinEngine1.SkinFile = vs[styleIndex];
            }
        }

        private void Template_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                if (vs!=null)
                {
                    styleIndex++;

                    if (styleIndex > vs.Length) styleIndex = 0;

                    SetFormStyle(styleIndex);
                }
            }
        }
    }
}
