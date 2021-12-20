namespace DMS.Controls.SystemControl
{
    partial class StartUpConfigControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartUpConfigControl));
            this.cmbColor = new DevComponents.DotNetBar.ColorPickerButton();
            this.labColor = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbUIStyle = new DevComponents.Editors.LabelComboBox();
            this.cmbDesk = new DevComponents.Editors.LabelComboBox();
            this.cmbMenu = new DevComponents.Editors.LabelComboBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbColor
            // 
            this.cmbColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cmbColor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cmbColor.Image = ((System.Drawing.Image)(resources.GetObject("cmbColor.Image")));
            this.cmbColor.Location = new System.Drawing.Point(115, 154);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.cmbColor.Size = new System.Drawing.Size(206, 21);
            this.cmbColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbColor.SubItemsExpandWidth = 24;
            this.cmbColor.TabIndex = 6;
            // 
            // labColor
            // 
            this.labColor.AutoSize = true;
            this.labColor.Location = new System.Drawing.Point(49, 158);
            this.labColor.Name = "labColor";
            this.labColor.Size = new System.Drawing.Size(65, 12);
            this.labColor.TabIndex = 5;
            this.labColor.Text = "主题色系：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbColor);
            this.groupBox1.Controls.Add(this.labColor);
            this.groupBox1.Controls.Add(this.cmbUIStyle);
            this.groupBox1.Controls.Add(this.cmbDesk);
            this.groupBox1.Controls.Add(this.cmbMenu);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 302);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "主窗体布局";
            // 
            // cmbUIStyle
            // 
            this.cmbUIStyle.BackColor = System.Drawing.Color.Transparent;
            this.cmbUIStyle.Caption.BackColor = System.Drawing.Color.Transparent;
            this.cmbUIStyle.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbUIStyle.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbUIStyle.Caption.Text = "主题设置：";
            this.cmbUIStyle.Caption.Width = 100;
            this.cmbUIStyle.ColumnsVisible = true;
            this.cmbUIStyle.DropDownHeight = 100;
            this.cmbUIStyle.DropDownWidth = 0;
            this.cmbUIStyle.EditBoxLength = 32767;
            this.cmbUIStyle.Location = new System.Drawing.Point(15, 113);
            this.cmbUIStyle.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUIStyle.Name = "cmbUIStyle";
            this.cmbUIStyle.Size = new System.Drawing.Size(306, 21);
            this.cmbUIStyle.TabIndex = 3;
            this.cmbUIStyle.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            // 
            // cmbDesk
            // 
            this.cmbDesk.BackColor = System.Drawing.Color.Transparent;
            this.cmbDesk.Caption.BackColor = System.Drawing.Color.Transparent;
            this.cmbDesk.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDesk.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbDesk.Caption.Text = "桌面设置：";
            this.cmbDesk.Caption.Width = 100;
            this.cmbDesk.ColumnsVisible = true;
            this.cmbDesk.DropDownHeight = 100;
            this.cmbDesk.DropDownWidth = 0;
            this.cmbDesk.EditBoxLength = 32767;
            this.cmbDesk.Location = new System.Drawing.Point(15, 71);
            this.cmbDesk.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDesk.Name = "cmbDesk";
            this.cmbDesk.Size = new System.Drawing.Size(306, 21);
            this.cmbDesk.TabIndex = 1;
            this.cmbDesk.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            // 
            // cmbMenu
            // 
            this.cmbMenu.BackColor = System.Drawing.Color.Transparent;
            this.cmbMenu.Caption.BackColor = System.Drawing.Color.Transparent;
            this.cmbMenu.Caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMenu.Caption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbMenu.Caption.Text = "主窗体布局：";
            this.cmbMenu.Caption.Width = 100;
            this.cmbMenu.ColumnsVisible = true;
            this.cmbMenu.DropDownHeight = 100;
            this.cmbMenu.DropDownWidth = 0;
            this.cmbMenu.EditBoxLength = 32767;
            this.cmbMenu.Location = new System.Drawing.Point(15, 30);
            this.cmbMenu.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMenu.Name = "cmbMenu";
            this.cmbMenu.Size = new System.Drawing.Size(306, 21);
            this.cmbMenu.TabIndex = 0;
            this.cmbMenu.VisibleStyle = DevComponents.Editors.LabelBoxVisibleStyle.Both;
            this.cmbMenu.SelectedIndexChanged += new System.EventHandler(this.cmbMenu_SelectedIndexChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::DMS.Properties.Resources.explorerform;
            this.pictureBox.Location = new System.Drawing.Point(378, 30);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(70, 66);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // StartUpConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "StartUpConfigControl";
            this.Size = new System.Drawing.Size(473, 302);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ColorPickerButton cmbColor;
        private System.Windows.Forms.Label labColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.Editors.LabelComboBox cmbUIStyle;
        private DevComponents.Editors.LabelComboBox cmbDesk;
        private DevComponents.Editors.LabelComboBox cmbMenu;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}
