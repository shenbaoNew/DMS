namespace DMS.Forms
{
    partial class frmUserChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNewPwd2 = new DevComponents.Editors.LabelTextBox();
            this.txtNewPwd1 = new DevComponents.Editors.LabelTextBox();
            this.txtOldPwd = new DevComponents.Editors.LabelTextBox();
            this.txtUserID = new DevComponents.Editors.LabelTextBox();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.lab = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNewPwd2
            // 
            this.txtNewPwd2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPwd2.BackColor = System.Drawing.SystemColors.Window;
            this.txtNewPwd2.Caption.BackColor = System.Drawing.Color.Transparent;
            this.txtNewPwd2.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPwd2.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNewPwd2.Caption.Text = "确认新密码：";
            this.txtNewPwd2.Caption.Width = 90;
            this.txtNewPwd2.Location = new System.Drawing.Point(21, 194);
            this.txtNewPwd2.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewPwd2.Name = "txtNewPwd2";
            this.txtNewPwd2.PasswordChar = '*';
            this.txtNewPwd2.Size = new System.Drawing.Size(405, 23);
            this.txtNewPwd2.TabIndex = 40;
            this.txtNewPwd2.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.txtNewPwd2.TextChanged += new System.EventHandler(this.txtNewPwd2_TextChanged);
            // 
            // txtNewPwd1
            // 
            this.txtNewPwd1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPwd1.BackColor = System.Drawing.SystemColors.Window;
            this.txtNewPwd1.Caption.BackColor = System.Drawing.Color.Transparent;
            this.txtNewPwd1.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNewPwd1.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNewPwd1.Caption.Text = "新密码：";
            this.txtNewPwd1.Caption.Width = 90;
            this.txtNewPwd1.Location = new System.Drawing.Point(21, 157);
            this.txtNewPwd1.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewPwd1.Name = "txtNewPwd1";
            this.txtNewPwd1.PasswordChar = '*';
            this.txtNewPwd1.Size = new System.Drawing.Size(405, 23);
            this.txtNewPwd1.TabIndex = 39;
            this.txtNewPwd1.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldPwd.BackColor = System.Drawing.SystemColors.Window;
            this.txtOldPwd.Caption.BackColor = System.Drawing.Color.Transparent;
            this.txtOldPwd.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldPwd.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOldPwd.Caption.Text = "旧密码：";
            this.txtOldPwd.Caption.Width = 90;
            this.txtOldPwd.Location = new System.Drawing.Point(21, 121);
            this.txtOldPwd.Margin = new System.Windows.Forms.Padding(2);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(405, 23);
            this.txtOldPwd.TabIndex = 38;
            this.txtOldPwd.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            // 
            // txtUserID
            // 
            this.txtUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserID.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserID.Caption.BackColor = System.Drawing.Color.Transparent;
            this.txtUserID.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserID.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserID.Caption.Text = "用户名：";
            this.txtUserID.Caption.Width = 90;
            this.txtUserID.Location = new System.Drawing.Point(21, 84);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.Size = new System.Drawing.Size(405, 23);
            this.txtUserID.TabIndex = 37;
            this.txtUserID.TabStop = false;
            this.txtUserID.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CallBasePaintBackground = true;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(351, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "取 消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.CallBasePaintBackground = true;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(249, 242);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 41;
            this.btnOK.Text = "确 定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lab
            // 
            this.lab.BackColor = System.Drawing.Color.Transparent;
            this.lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab.ForeColor = System.Drawing.SystemColors.Window;
            this.lab.Location = new System.Drawing.Point(111, 21);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(197, 31);
            this.lab.TabIndex = 43;
            this.lab.Text = "修改密码";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::DMS.Properties.Resources.adminuser;
            this.pictureBox1.Location = new System.Drawing.Point(12, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 67);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // frmUserChangePassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::DMS.Properties.Resources.background;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(461, 287);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtNewPwd2);
            this.Controls.Add(this.txtNewPwd1);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.txtUserID);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmUserChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改个人密码";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.Editors.LabelTextBox txtNewPwd2;
        private DevComponents.Editors.LabelTextBox txtNewPwd1;
        private DevComponents.Editors.LabelTextBox txtOldPwd;
        private DevComponents.Editors.LabelTextBox txtUserID;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}