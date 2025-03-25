namespace ProjectManagementApp
{
    partial class FrmAddTask
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubTask = new System.Windows.Forms.TextBox();
            this.btnAddSubTask = new System.Windows.Forms.Button();
            this.flpSubTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTaskName
            // 
            this.txtTaskName.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.txtTaskName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.txtTaskName.Location = new System.Drawing.Point(120, 30);
            this.txtTaskName.Size = new System.Drawing.Size(250, 23);
            this.txtTaskName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên công việc:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hạn chót:";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CalendarForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.dtpDueDate.CalendarMonthBackground = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.dtpDueDate.Location = new System.Drawing.Point(120, 70);
            this.dtpDueDate.Size = new System.Drawing.Size(250, 23);
            this.dtpDueDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trạng thái:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.cmbStatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Chưa bắt đầu",
            "Đang thực hiện",
            "Hoàn thành"});
            this.cmbStatus.Location = new System.Drawing.Point(120, 110);
            this.cmbStatus.Size = new System.Drawing.Size(250, 23);
            this.cmbStatus.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.label4.Location = new System.Drawing.Point(30, 150);
            this.label4.Size = new System.Drawing.Size(74, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhiệm vụ con:";
            // 
            // txtSubTask
            // 
            this.txtSubTask.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.txtSubTask.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.txtSubTask.Location = new System.Drawing.Point(120, 150);
            this.txtSubTask.Size = new System.Drawing.Size(200, 23);
            this.txtSubTask.TabIndex = 7;
            // 
            // btnAddSubTask
            // 
            this.btnAddSubTask.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.btnAddSubTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubTask.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.btnAddSubTask.Location = new System.Drawing.Point(330, 150);
            this.btnAddSubTask.Size = new System.Drawing.Size(75, 23);
            this.btnAddSubTask.TabIndex = 8;
            this.btnAddSubTask.Text = "Thêm";
            this.btnAddSubTask.UseVisualStyleBackColor = false;
            this.btnAddSubTask.Click += new System.EventHandler(this.btnAddSubTask_Click);
            // 
            // flpSubTasks
            // 
            this.flpSubTasks.AutoScroll = true;
            this.flpSubTasks.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.flpSubTasks.Location = new System.Drawing.Point(30, 190);
            this.flpSubTasks.Size = new System.Drawing.Size(375, 150);
            this.flpSubTasks.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.btnSave.Location = new System.Drawing.Point(225, 350);
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.btnCancel.Location = new System.Drawing.Point(325, 350);
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmAddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 400);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.flpSubTasks);
            this.Controls.Add(this.btnAddSubTask);
            this.Controls.Add(this.txtSubTask);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTaskName);
            this.Name = "FrmAddTask";
            this.Text = "Thêm công việc";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubTask;
        private System.Windows.Forms.Button btnAddSubTask;
        private System.Windows.Forms.FlowLayoutPanel flpSubTasks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}