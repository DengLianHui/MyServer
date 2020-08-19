using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

namespace ERP_Demo_WinForm
{
    public partial class Main_Form : Module.TemplateForm.Template_Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        readonly SqlHelper sqlHelper = new SqlHelper("System.Data.SqlClient", "Server=129.28.131.104;Database=db_eki_cs;User Id=sa; Password=dlh445566^&;");

        private void OK_Button_Click(object sender, EventArgs e)
        {
            //DbParameter sqlParameter = new SqlParameter("@var1", SqlDbType.VarChar) { Value = "123" };

            //Tool_Folder.SQLCommandStruct sc = new Tool_Folder.SQLCommandStruct();
            //sc.DbParameter = sqlParameter;

            //byte[] vs = Tool_Folder.ChangeHelper.ObjectToBytes(sc);

            //Tool_Folder.SQLCommandStruct sqlParameter1 = (Tool_Folder.SQLCommandStruct)Tool_Folder.ChangeHelper.BytesToObject(vs);


            //return;





            dataGridView1.DataSource = sqlHelper.GetDataSet("SELECT * FROM t_user WHERE user_name = @var1", new SqlParameter[]{
                  new SqlParameter("@var1",SqlDbType.VarChar){Value="邓联辉"},
             }).Tables[0].DefaultView;
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {



        }
    }
}
