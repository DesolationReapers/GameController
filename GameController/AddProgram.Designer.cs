namespace GameController
{
    partial class AddProgram
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radAuto = new System.Windows.Forms.RadioButton();
            this.radProcess = new System.Windows.Forms.RadioButton();
            this.radService = new System.Windows.Forms.RadioButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnAddOK = new System.Windows.Forms.Button();
            this.btnAddCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "exe";
            this.openFileDialog1.FileName = "*.exe";
            this.openFileDialog1.Title = "Select Program";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radAuto);
            this.groupBox1.Controls.Add(this.radProcess);
            this.groupBox1.Controls.Add(this.radService);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Method";
            // 
            // radAuto
            // 
            this.radAuto.AutoSize = true;
            this.radAuto.Enabled = false;
            this.radAuto.Location = new System.Drawing.Point(6, 65);
            this.radAuto.Name = "radAuto";
            this.radAuto.Size = new System.Drawing.Size(82, 17);
            this.radAuto.TabIndex = 2;
            this.radAuto.TabStop = true;
            this.radAuto.Text = "Auto Detect";
            this.radAuto.UseVisualStyleBackColor = true;
            // 
            // radProcess
            // 
            this.radProcess.AutoSize = true;
            this.radProcess.Location = new System.Drawing.Point(6, 42);
            this.radProcess.Name = "radProcess";
            this.radProcess.Size = new System.Drawing.Size(64, 17);
            this.radProcess.TabIndex = 1;
            this.radProcess.TabStop = true;
            this.radProcess.Text = "Program";
            this.radProcess.UseVisualStyleBackColor = true;
            this.radProcess.CheckedChanged += new System.EventHandler(this.radProgram_CheckedChanged);
            // 
            // radService
            // 
            this.radService.AutoSize = true;
            this.radService.Location = new System.Drawing.Point(6, 19);
            this.radService.Name = "radService";
            this.radService.Size = new System.Drawing.Size(61, 17);
            this.radService.TabIndex = 0;
            this.radService.TabStop = true;
            this.radService.Text = "Service";
            this.radService.UseVisualStyleBackColor = true;
            this.radService.CheckedChanged += new System.EventHandler(this.radService_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(196, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(176, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(196, 53);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(176, 20);
            this.txtPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(139, 93);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnAddOK
            // 
            this.btnAddOK.Location = new System.Drawing.Point(220, 93);
            this.btnAddOK.Name = "btnAddOK";
            this.btnAddOK.Size = new System.Drawing.Size(75, 23);
            this.btnAddOK.TabIndex = 5;
            this.btnAddOK.Text = "OK";
            this.btnAddOK.UseVisualStyleBackColor = true;
            this.btnAddOK.Click += new System.EventHandler(this.btnAddOK_Click);
            // 
            // btnAddCancel
            // 
            this.btnAddCancel.Location = new System.Drawing.Point(301, 93);
            this.btnAddCancel.Name = "btnAddCancel";
            this.btnAddCancel.Size = new System.Drawing.Size(75, 23);
            this.btnAddCancel.TabIndex = 6;
            this.btnAddCancel.Text = "Cancel";
            this.btnAddCancel.UseVisualStyleBackColor = true;
            this.btnAddCancel.Click += new System.EventHandler(this.btnAddCancel_Click);
            // 
            // AddProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 130);
            this.Controls.Add(this.btnAddCancel);
            this.Controls.Add(this.btnAddOK);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddProgram";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Add Service or Program";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radAuto;
        private System.Windows.Forms.RadioButton radProcess;
        private System.Windows.Forms.RadioButton radService;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnAddOK;
        private System.Windows.Forms.Button btnAddCancel;
    }
}