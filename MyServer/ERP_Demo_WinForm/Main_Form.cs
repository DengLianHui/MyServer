using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Demo_WinForm
{
    public partial class Main_Form : Module.TemplateForm.Template_Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        SqlHelper sqlHelper = new SqlHelper("System.Data.SqlClient", "Server=129.28.131.104;Database=db_eki_cs;User Id=sa; Password=qq531332041^&;");

        private void OK_Button_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource= sqlHelper.GetDataSet("SELECT * FROM t_user").Tables[0].DefaultView;
        }
        
        private void Main_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
