namespace ERP_Demo_WinForm.User_Folder
{
    partial class Login_Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Password_TextBox = new System.Windows.Forms.TextBox();
            this.UserID_ComboBox = new System.Windows.Forms.ComboBox();
            this.OK_Button = new System.Windows.Forms.Button();
            this.SignUp_Label = new System.Windows.Forms.Label();
            this.HeadThumb_PictureBox = new System.Windows.Forms.PictureBox();
            this.RememberPassword_CheckBox = new System.Windows.Forms.CheckBox();
            this.RememberMe_CheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.HeadThumb_PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.Location = new System.Drawing.Point(41, 149);
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.PasswordChar = '*';
            this.Password_TextBox.Size = new System.Drawing.Size(231, 21);
            this.Password_TextBox.TabIndex = 1;
            this.Password_TextBox.TextChanged += new System.EventHandler(this.Password_TextBox_TextChanged);
            this.Password_TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_TextBox_KeyDown);
            // 
            // UserID_ComboBox
            // 
            this.UserID_ComboBox.FormattingEnabled = true;
            this.UserID_ComboBox.Location = new System.Drawing.Point(41, 105);
            this.UserID_ComboBox.Name = "UserID_ComboBox";
            this.UserID_ComboBox.Size = new System.Drawing.Size(231, 20);
            this.UserID_ComboBox.TabIndex = 0;
            this.UserID_ComboBox.SelectedIndexChanged += new System.EventHandler(this.UserID_ComboBox_SelectedIndexChanged);
            this.UserID_ComboBox.TextChanged += new System.EventHandler(this.UserID_ComboBox_TextChanged);
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(298, 105);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(135, 65);
            this.OK_Button.TabIndex = 4;
            this.OK_Button.Text = "登录";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // SignUp_Label
            // 
            this.SignUp_Label.AutoSize = true;
            this.SignUp_Label.Location = new System.Drawing.Point(296, 200);
            this.SignUp_Label.Name = "SignUp_Label";
            this.SignUp_Label.Size = new System.Drawing.Size(53, 12);
            this.SignUp_Label.TabIndex = 6;
            this.SignUp_Label.Text = "注册账号";
            this.SignUp_Label.Click += new System.EventHandler(this.SignUp_Label_Click);
            // 
            // HeadThumb_PictureBox
            // 
            this.HeadThumb_PictureBox.Location = new System.Drawing.Point(184, 12);
            this.HeadThumb_PictureBox.Name = "HeadThumb_PictureBox";
            this.HeadThumb_PictureBox.Size = new System.Drawing.Size(100, 75);
            this.HeadThumb_PictureBox.TabIndex = 7;
            this.HeadThumb_PictureBox.TabStop = false;
            // 
            // RememberPassword_CheckBox
            // 
            this.RememberPassword_CheckBox.AutoSize = true;
            this.RememberPassword_CheckBox.Checked = global::ERP_Demo_WinForm.Properties.Settings.Default.RememberPassword_CheckBox;
            this.RememberPassword_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RememberPassword_CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ERP_Demo_WinForm.Properties.Settings.Default, "RememberPassword_CheckBox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RememberPassword_CheckBox.Location = new System.Drawing.Point(170, 199);
            this.RememberPassword_CheckBox.Name = "RememberPassword_CheckBox";
            this.RememberPassword_CheckBox.Size = new System.Drawing.Size(72, 16);
            this.RememberPassword_CheckBox.TabIndex = 3;
            this.RememberPassword_CheckBox.Text = "记住密码";
            this.RememberPassword_CheckBox.UseVisualStyleBackColor = true;
            this.RememberPassword_CheckBox.CheckedChanged += new System.EventHandler(this.RememberPassword_CheckBox_CheckedChanged);
            // 
            // RememberMe_CheckBox
            // 
            this.RememberMe_CheckBox.AutoSize = true;
            this.RememberMe_CheckBox.Checked = global::ERP_Demo_WinForm.Properties.Settings.Default.RememberMe_CheckBox;
            this.RememberMe_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RememberMe_CheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ERP_Demo_WinForm.Properties.Settings.Default, "RememberMe_CheckBox", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.RememberMe_CheckBox.Location = new System.Drawing.Point(54, 199);
            this.RememberMe_CheckBox.Name = "RememberMe_CheckBox";
            this.RememberMe_CheckBox.Size = new System.Drawing.Size(72, 16);
            this.RememberMe_CheckBox.TabIndex = 2;
            this.RememberMe_CheckBox.Text = "记住账号";
            this.RememberMe_CheckBox.UseVisualStyleBackColor = true;
            this.RememberMe_CheckBox.CheckedChanged += new System.EventHandler(this.RememberMe_CheckBox_CheckedChanged);
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(469, 227);
            this.Controls.Add(this.HeadThumb_PictureBox);
            this.Controls.Add(this.SignUp_Label);
            this.Controls.Add(this.RememberPassword_CheckBox);
            this.Controls.Add(this.RememberMe_CheckBox);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.UserID_ComboBox);
            this.Controls.Add(this.Password_TextBox);
            this.Name = "Login_Form";
            this.Text = " 登录";
            this.Load += new System.EventHandler(this.Login_Form_Load);
            this.Shown += new System.EventHandler(this.Login_Form_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.HeadThumb_PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Password_TextBox;
        private System.Windows.Forms.ComboBox UserID_ComboBox;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.CheckBox RememberMe_CheckBox;
        private System.Windows.Forms.CheckBox RememberPassword_CheckBox;
        private System.Windows.Forms.Label SignUp_Label;
        private System.Windows.Forms.PictureBox HeadThumb_PictureBox;
    }
}
