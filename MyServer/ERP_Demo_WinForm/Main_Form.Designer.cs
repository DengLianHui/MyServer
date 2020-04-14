namespace ERP_Demo_WinForm
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.OK_Button = new System.Windows.Forms.Button();
            this.Preview_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(1227, 613);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(75, 23);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "button1";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Preview_TextBox
            // 
            this.Preview_TextBox.Location = new System.Drawing.Point(1202, 586);
            this.Preview_TextBox.Name = "Preview_TextBox";
            this.Preview_TextBox.Size = new System.Drawing.Size(100, 21);
            this.Preview_TextBox.TabIndex = 1;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1503, 685);
            this.Controls.Add(this.Preview_TextBox);
            this.Controls.Add(this.OK_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_Form";
            this.Text = "ERP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.TextBox Preview_TextBox;
    }
}

