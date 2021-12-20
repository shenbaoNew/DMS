namespace DMS.Forms {
    partial class frmSetDBServer {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtPwd = new DevComponents.Editors.LabelTextBox();
            this.txtUser = new DevComponents.Editors.LabelTextBox();
            this.txtDB = new DevComponents.Editors.LabelTextBox();
            this.txtServer = new DevComponents.Editors.LabelTextBox();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.lab = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPort = new DevComponents.Editors.LabelTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPwd
            // 
            this.txtPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPwd.BackColor = System.Drawing.SystemColors.Window;
            this.txtPwd.Caption.BackColor = System.Drawing.Color.Transparent;
            this.txtPwd.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwd.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPwd.Caption.Text = "密码：";
            this.txtPwd.Caption.Width = 90;
            this.txtPwd.Location = new System.Drawing.Point(21, 218);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(2);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(410, 20);
            this.txtPwd.SpecialChars = new char[0];
            this.txtPwd.SpecialCharsStyle = DevComponents.DotNetBar.eSpecialCharsStyle.Invalid;
            this.txtPwd.TabIndex = 41;
            this.txtPwd.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.txtPwd.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtPwd.TextChanged += new System.EventHandler(this.txtNewPwd2_TextChanged);
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.BackColor = System.Drawing.SystemColors.Window;
            this.txtUser.Caption.BackColor = System.Drawing.Color.Transparent;
            this.txtUser.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUser.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUser.Caption.Text = "用户名：";
            this.txtUser.Caption.Width = 90;
            this.txtUser.Location = new System.Drawing.Point(21, 181);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(410, 20);
            this.txtUser.SpecialChars = new char[0];
            this.txtUser.SpecialCharsStyle = DevComponents.DotNetBar.eSpecialCharsStyle.Invalid;
            this.txtUser.TabIndex = 40;
            this.txtUser.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.txtUser.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // txtDB
            // 
            this.txtDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDB.BackColor = System.Drawing.SystemColors.Window;
            this.txtDB.Caption.BackColor = System.Drawing.Color.Transparent;
            this.txtDB.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDB.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDB.Caption.Text = "数据库：";
            this.txtDB.Caption.Width = 90;
            this.txtDB.Location = new System.Drawing.Point(21, 145);
            this.txtDB.Margin = new System.Windows.Forms.Padding(2);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(410, 20);
            this.txtDB.SpecialChars = new char[0];
            this.txtDB.SpecialCharsStyle = DevComponents.DotNetBar.eSpecialCharsStyle.Invalid;
            this.txtDB.TabIndex = 39;
            this.txtDB.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.txtDB.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.BackColor = System.Drawing.SystemColors.Window;
            this.txtServer.Caption.BackColor = System.Drawing.Color.Transparent;
            this.txtServer.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtServer.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtServer.Caption.Text = "服务器：";
            this.txtServer.Caption.Width = 90;
            this.txtServer.Location = new System.Drawing.Point(21, 84);
            this.txtServer.Margin = new System.Windows.Forms.Padding(2);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(410, 20);
            this.txtServer.SpecialChars = new char[0];
            this.txtServer.SpecialCharsStyle = DevComponents.DotNetBar.eSpecialCharsStyle.Invalid;
            this.txtServer.TabIndex = 37;
            this.txtServer.TabStop = false;
            this.txtServer.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.txtServer.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(356, 257);
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
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(254, 257);
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
            this.lab.Size = new System.Drawing.Size(280, 31);
            this.lab.TabIndex = 43;
            this.lab.Text = "设置mariadb服务器";
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
            // txtPort
            // 
            this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPort.BackColor = System.Drawing.SystemColors.Window;
            this.txtPort.Caption.BackColor = System.Drawing.Color.Transparent;
            this.txtPort.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPort.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPort.Caption.Text = "端口号：";
            this.txtPort.Caption.Width = 90;
            this.txtPort.Location = new System.Drawing.Point(21, 116);
            this.txtPort.Margin = new System.Windows.Forms.Padding(2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(410, 20);
            this.txtPort.SpecialChars = new char[0];
            this.txtPort.SpecialCharsStyle = DevComponents.DotNetBar.eSpecialCharsStyle.Invalid;
            this.txtPort.TabIndex = 38;
            this.txtPort.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.txtPort.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // frmSetDBServer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::DMS.Properties.Resources.background;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(466, 302);
            this.ControlBox = false;
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtDB);
            this.Controls.Add(this.txtServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSetDBServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置mariadb服务器";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.Editors.LabelTextBox txtPwd;
        private DevComponents.Editors.LabelTextBox txtUser;
        private DevComponents.Editors.LabelTextBox txtDB;
        private DevComponents.Editors.LabelTextBox txtServer;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.Editors.LabelTextBox txtPort;
    }
}