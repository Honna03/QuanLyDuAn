namespace ProjectManagementApp
{
    partial class FrmMain
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTasks = new System.Windows.Forms.TabPage();
            this.pnlTasksContent = new System.Windows.Forms.Panel();
            this.clbSubTasks = new System.Windows.Forms.CheckedListBox();
            this.cmbTaskSelector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabKPI = new System.Windows.Forms.TabPage();
            this.pnlKPIContent = new System.Windows.Forms.Panel();
            this.tabSalary = new System.Windows.Forms.TabPage();
            this.pnlSalaryContent = new System.Windows.Forms.Panel();
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.pnlAccountContent = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabTasks.SuspendLayout();
            this.tabKPI.SuspendLayout();
            this.tabSalary.SuspendLayout();
            this.tabAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTasks);
            this.tabControl.Controls.Add(this.tabKPI);
            this.tabControl.Controls.Add(this.tabSalary);
            this.tabControl.Controls.Add(this.tabAccount);
            this.tabControl.Location = new System.Drawing.Point(12, 50);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(696, 538);
            this.tabControl.TabIndex = 0;
            // 
            // tabTasks
            // 
            this.tabTasks.Controls.Add(this.pnlTasksContent);
            this.tabTasks.Location = new System.Drawing.Point(4, 24);
            this.tabTasks.Name = "tabTasks";
            this.tabTasks.Padding = new System.Windows.Forms.Padding(3);
            this.tabTasks.Size = new System.Drawing.Size(688, 510);
            this.tabTasks.TabIndex = 0;
            this.tabTasks.Text = "Công việc";
            this.tabTasks.UseVisualStyleBackColor = true;
            // 
            // pnlTasksContent
            // 
            this.pnlTasksContent.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.pnlTasksContent.Location = new System.Drawing.Point(0, 0);
            this.pnlTasksContent.Name = "pnlTasksContent";
            this.pnlTasksContent.Size = new System.Drawing.Size(688, 510);
            this.pnlTasksContent.TabIndex = 0;
            // 
            // clbSubTasks
            // 
            this.clbSubTasks.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.clbSubTasks.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.clbSubTasks.FormattingEnabled = true;
            this.clbSubTasks.Location = new System.Drawing.Point(30, 390);
            this.clbSubTasks.Name = "clbSubTasks";
            this.clbSubTasks.Size = new System.Drawing.Size(620, 109);
            this.clbSubTasks.TabIndex = 5;
            // 
            // cmbTaskSelector
            // 
            this.cmbTaskSelector.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.cmbTaskSelector.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.cmbTaskSelector.FormattingEnabled = true;
            this.cmbTaskSelector.Location = new System.Drawing.Point(130, 350);
            this.cmbTaskSelector.Name = "cmbTaskSelector";
            this.cmbTaskSelector.Size = new System.Drawing.Size(250, 23);
            this.cmbTaskSelector.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.label2.Location = new System.Drawing.Point(30, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chọn công việc:";
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.btnAddTask.Location = new System.Drawing.Point(350, 30);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(100, 30);
            this.btnAddTask.TabIndex = 2;
            this.btnAddTask.Text = "Thêm công việc";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnEditTask
            // 
            this.btnEditTask.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.btnEditTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTask.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.btnEditTask.Location = new System.Drawing.Point(450, 30);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(100, 30);
            this.btnEditTask.TabIndex = 6;
            this.btnEditTask.Text = "Sửa";
            this.btnEditTask.UseVisualStyleBackColor = false;
            this.btnEditTask.Click += new System.EventHandler(this.btnEditTask_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.btnDeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTask.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.btnDeleteTask.Location = new System.Drawing.Point(550, 30);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteTask.TabIndex = 7;
            this.btnDeleteTask.Text = "Xóa";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // dgvTasks
            // 
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Location = new System.Drawing.Point(30, 70);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowHeadersWidth = 51;
            this.dgvTasks.Size = new System.Drawing.Size(620, 250);
            this.dgvTasks.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách công việc";
            // 
            // tabKPI
            // 
            this.tabKPI.Controls.Add(this.pnlKPIContent);
            this.tabKPI.Location = new System.Drawing.Point(4, 24);
            this.tabKPI.Name = "tabKPI";
            this.tabKPI.Padding = new System.Windows.Forms.Padding(3);
            this.tabKPI.Size = new System.Drawing.Size(688, 510);
            this.tabKPI.TabIndex = 1;
            this.tabKPI.Text = "KPI";
            this.tabKPI.UseVisualStyleBackColor = true;
            // 
            // pnlKPIContent
            // 
            this.pnlKPIContent.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.pnlKPIContent.Location = new System.Drawing.Point(0, 0);
            this.pnlKPIContent.Name = "pnlKPIContent";
            this.pnlKPIContent.Size = new System.Drawing.Size(688, 510);
            this.pnlKPIContent.TabIndex = 0;
            // 
            // tabSalary
            // 
            this.tabSalary.Controls.Add(this.pnlSalaryContent);
            this.tabSalary.Location = new System.Drawing.Point(4, 24);
            this.tabSalary.Name = "tabSalary";
            this.tabSalary.Padding = new System.Windows.Forms.Padding(3);
            this.tabSalary.Size = new System.Drawing.Size(688, 510);
            this.tabSalary.TabIndex = 2;
            this.tabSalary.Text = "Lương";
            this.tabSalary.UseVisualStyleBackColor = true;
            // 
            // pnlSalaryContent
            // 
            this.pnlSalaryContent.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.pnlSalaryContent.Location = new System.Drawing.Point(0, 0);
            this.pnlSalaryContent.Name = "pnlSalaryContent";
            this.pnlSalaryContent.Size = new System.Drawing.Size(688, 510);
            this.pnlSalaryContent.TabIndex = 0;
            // 
            // tabAccount
            // 
            this.tabAccount.Controls.Add(this.pnlAccountContent);
            this.tabAccount.Location = new System.Drawing.Point(4, 24);
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccount.Size = new System.Drawing.Size(688, 510);
            this.tabAccount.TabIndex = 3;
            this.tabAccount.Text = "Tài khoản";
            this.tabAccount.UseVisualStyleBackColor = true;
            // 
            // pnlAccountContent
            // 
            this.pnlAccountContent.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.pnlAccountContent.Location = new System.Drawing.Point(0, 0);
            this.pnlAccountContent.Name = "pnlAccountContent";
            this.pnlAccountContent.Size = new System.Drawing.Size(688, 510);
            this.pnlAccountContent.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F2D25");
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A4AC9E");
            this.btnLogout.Location = new System.Drawing.Point(598, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 30);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 600);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl);
            this.Name = "FrmMain";
            this.Text = "Quản lý dự án";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabTasks.ResumeLayout(false);
            this.tabKPI.ResumeLayout(false);
            this.tabSalary.ResumeLayout(false);
            this.tabAccount.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.Panel pnlTasksContent;
        private System.Windows.Forms.CheckedListBox clbSubTasks;
        private System.Windows.Forms.ComboBox cmbTaskSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabKPI;
        private System.Windows.Forms.Panel pnlKPIContent;
        private System.Windows.Forms.TabPage tabSalary;
        private System.Windows.Forms.Panel pnlSalaryContent;
        private System.Windows.Forms.TabPage tabAccount;
        private System.Windows.Forms.Panel pnlAccountContent;
        private System.Windows.Forms.Button btnLogout;
    }
}