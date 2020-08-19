using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ERP_Demo_WinForm.User_Folder
{
    public partial class Login_Form : Module.TemplateForm.Template_Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private List<ProtoKey.UserConfig> userConfigs;
        private ProtoKey.UserConfig UserConfig;
        readonly string userConfigFile = "UserConfig.dat";

        private void Login_Form_Load(object sender, EventArgs e)
        {
        }

        private void Login_Form_Shown(object sender, EventArgs e)
        {
            userConfigs = new List<ProtoKey.UserConfig>();
            UserConfig = new ProtoKey.UserConfig();
            RememberMe_CheckBox.Checked = Properties.Settings.Default.RememberMe_CheckBox;
            RememberPassword_CheckBox.Checked = Properties.Settings.Default.RememberPassword_CheckBox;

            if (File.Exists(userConfigFile))
            {
                userConfigs = (List<ProtoKey.UserConfig>)new Tool_Folder.ChangeHelper().FileToObject(userConfigFile);

                if (userConfigs.Count > 0)
                {
                    UserConfig = userConfigs[0];

                    foreach (var item in userConfigs)
                    {
                        UserID_ComboBox.Items.Add(item.UserID);
                    }
                }
            }
            UserID_ComboBox.Text = Properties.Settings.Default.LastLoginUser;
        }



        private void SaveUserConfig()
        {
            UserConfig.RememberPassword = RememberPassword_CheckBox.Checked;

            if (RememberMe_CheckBox.Checked)
            {
                Properties.Settings.Default.LastLoginUser = UserID_ComboBox.Text;
                Properties.Settings.Default.Save();

                if (RememberPassword_CheckBox.Checked)
                {
                    UserConfig.Password = new Tool_Folder.DesHelper().Encrypt(Password_TextBox.Text);
                }
                else
                {
                    UserConfig.Password = string.Empty;
                }

                bool isAdd = true;

                for (int i = 0; i < userConfigs.Count; i++)
                {
                    if (UserID_ComboBox.Text == userConfigs[i].UserID)
                    {
                        userConfigs[i] = UserConfig;
                        isAdd = false;
                        break;
                    }
                }

                if (isAdd)
                {
                    userConfigs.Add(UserConfig);
                }

                new Tool_Folder.ChangeHelper().ObjectToFile(userConfigs, userConfigFile);
            }
        }

        private void SignUp_Label_Click(object sender, EventArgs e)
        {
            User_Folder.SignUp_Form signUp_Form = new SignUp_Form();
            signUp_Form.ShowDialog();
            signUp_Form.Close();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SaveUserConfig();
        }

        private void UserID_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void RememberPassword_CheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RememberMe_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RememberMe_CheckBox = RememberMe_CheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void UserID_ComboBox_TextChanged(object sender, EventArgs e)
        {
            bool isEx = false;
            foreach (var item in userConfigs)
            {
                if (UserID_ComboBox.Text == item.UserID)
                {
                    UserConfig = item;

                    if (UserConfig.RememberPassword)
                    {
                        Password_TextBox.Text = new Tool_Folder.DesHelper().Decrypt(UserConfig.Password);
                    }
                    isEx = true;
                    break;
                }
            }
            if (!isEx)
            {
                Password_TextBox.Clear();
                RememberPassword_CheckBox.Checked = false;
                UserConfig = new ProtoKey.UserConfig
                {
                    UserID = UserID_ComboBox.Text
                };
            }
        }

        private void Password_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
