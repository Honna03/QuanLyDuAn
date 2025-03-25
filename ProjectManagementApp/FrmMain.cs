using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProjectManagementApp;

namespace ProjectManagementApp
{
    public partial class FrmMain : Form
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private int kpiTarget = 0;
        private List<Employee> employees = new List<Employee>();
        private const double KpiBonusRate = 0.1;
        private UserAccount currentUser;

        public FrmMain()
        {
            InitializeComponent();
            currentUser = new UserAccount
            {
                Username = "user1",
                FullName = "Nguyễn Văn A",
                Email = "user1@example.com",
                PhoneNumber = "0123456789",
                JoinDate = DateTime.Now.AddDays(-100),
                Password = "password123"
            };
            LoadInitialContent();
            AddHoverEffect();
            ConfigureDataGridView();
            ApplyColorScheme();
        }

        private void ApplyColorScheme()
        {
            Color textColor = ColorTranslator.FromHtml("#A4AC9E");
            Color backgroundColor = ColorTranslator.FromHtml("#0F2D25");

            this.BackColor = backgroundColor;

            foreach (Control control in this.Controls)
            {
                ApplyControlColors(control, textColor, backgroundColor);
            }

            ApplyControlColors(pnlTasksContent, textColor, backgroundColor);
            ApplyControlColors(pnlKPIContent, textColor, backgroundColor);
            ApplyControlColors(pnlSalaryContent, textColor, backgroundColor);
            ApplyControlColors(pnlAccountContent, textColor, backgroundColor);
        }

        private void ApplyControlColors(Control control, Color textColor, Color backgroundColor)
        {
            control.ForeColor = textColor;
            control.BackColor = backgroundColor;

            if (control is Button button)
            {
                button.FlatAppearance.BorderSize = 0;
                button.BackColor = backgroundColor;
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.FlatStyle = FlatStyle.Flat;
            }
            else if (control is DataGridView dgv)
            {
                dgv.BackgroundColor = backgroundColor;
                dgv.ForeColor = textColor;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#1A3C32");
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = textColor;
            }
            else if (control is Panel panel)
            {
                foreach (Control subControl in panel.Controls)
                {
                    ApplyControlColors(subControl, textColor, backgroundColor);
                }
            }
            else if (control is TabControl tabControl)
            {
                tabControl.BackColor = backgroundColor;
                tabControl.ForeColor = textColor;
                foreach (TabPage tabPage in tabControl.TabPages)
                {
                    tabPage.BackColor = backgroundColor;
                    tabPage.ForeColor = textColor;
                    foreach (Control subControl in tabPage.Controls)
                    {
                        ApplyControlColors(subControl, textColor, backgroundColor);
                    }
                }
            }
        }

        private void AddHoverEffect()
        {
            Color hoverColor = ColorTranslator.FromHtml("#1A3C32");
            Color backgroundColor = ColorTranslator.FromHtml("#0F2D25");

            btnLogout.MouseEnter += (s, e) => btnLogout.BackColor = hoverColor;
            btnLogout.MouseLeave += (s, e) => btnLogout.BackColor = backgroundColor;
            btnAddTask.MouseEnter += (s, e) => btnAddTask.BackColor = hoverColor;
            btnAddTask.MouseLeave += (s, e) => btnAddTask.BackColor = backgroundColor;
            btnEditTask.MouseEnter += (s, e) => btnEditTask.BackColor = hoverColor;
            btnEditTask.MouseLeave += (s, e) => btnEditTask.BackColor = backgroundColor;
            btnDeleteTask.MouseEnter += (s, e) => btnDeleteTask.BackColor = hoverColor;
            btnDeleteTask.MouseLeave += (s, e) => btnDeleteTask.BackColor = backgroundColor;
        }

        private void ConfigureDataGridView()
        {
            Color textColor = ColorTranslator.FromHtml("#A4AC9E");
            Color backgroundColor = ColorTranslator.FromHtml("#0F2D25");
            Color headerColor = ColorTranslator.FromHtml("#1A3C32");

            dgvTasks.BackgroundColor = backgroundColor;
            dgvTasks.ForeColor = textColor;
            dgvTasks.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = headerColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
        }

        private void LoadInitialContent()
        {
            LoadTasksContent();
            LoadKPIContent();
            LoadSalaryContent();
            LoadAccountContent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                new FrmDangnhap().Show();
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            using (FrmAddTask frmAddTask = new FrmAddTask())
            {
                if (frmAddTask.ShowDialog() == DialogResult.OK)
                {
                    TaskItem newTask = frmAddTask.NewTask;
                    if (newTask != null)
                    {
                        tasks.Add(newTask);
                        UpdateTaskSelector();
                        dgvTasks.DataSource = null;
                        dgvTasks.DataSource = tasks;
                        UpdateKPIContent();
                        UpdateSalaryContent();
                        UpdateAccountContent();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm công việc vì dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một công việc để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = dgvTasks.SelectedRows[0].Index;
            TaskItem taskToEdit = tasks[selectedIndex];

            using (FrmAddTask frmAddTask = new FrmAddTask(taskToEdit))
            {
                if (frmAddTask.ShowDialog() == DialogResult.OK)
                {
                    TaskItem updatedTask = frmAddTask.NewTask;
                    if (updatedTask != null)
                    {
                        tasks[selectedIndex] = updatedTask;
                        UpdateTaskSelector();
                        dgvTasks.DataSource = null;
                        dgvTasks.DataSource = tasks;
                        UpdateKPIContent();
                        UpdateSalaryContent();
                        UpdateAccountContent();
                    }
                    else
                    {
                        MessageBox.Show("Không thể chỉnh sửa công việc vì dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một công việc để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa công việc này?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int selectedIndex = dgvTasks.SelectedRows[0].Index;
                tasks.RemoveAt(selectedIndex);
                UpdateTaskSelector();
                dgvTasks.DataSource = null;
                dgvTasks.DataSource = tasks;
                UpdateKPIContent();
                UpdateSalaryContent();
                UpdateAccountContent();
            }
        }

        private void LoadTasksContent()
        {
            tasks = tasks ?? new List<TaskItem>();
            tasks.Clear();

            tasks.Add(new TaskItem
            {
                Id = 1,
                Name = "Thiết kế giao diện",
                Status = "Đang thực hiện",
                DueDate = DateTime.Now.AddDays(3),
                SubTasks = new List<SubTask>
                {
                    new SubTask { Name = "Thiết kế wireframe", IsCompleted = true },
                    new SubTask { Name = "Thiết kế UI", IsCompleted = false }
                }
            });
            tasks.Add(new TaskItem
            {
                Id = 2,
                Name = "Xây dựng backend",
                Status = "Chưa bắt đầu",
                DueDate = DateTime.Now.AddDays(5),
                SubTasks = new List<SubTask>
                {
                    new SubTask { Name = "Cài đặt server", IsCompleted = false },
                    new SubTask { Name = "Xây dựng API", IsCompleted = false }
                }
            });

            pnlTasksContent.Controls.Clear();
            pnlTasksContent.Controls.Add(label1);
            pnlTasksContent.Controls.Add(dgvTasks);
            pnlTasksContent.Controls.Add(btnAddTask);
            pnlTasksContent.Controls.Add(btnEditTask);
            pnlTasksContent.Controls.Add(btnDeleteTask);
            pnlTasksContent.Controls.Add(label2);
            pnlTasksContent.Controls.Add(cmbTaskSelector);
            pnlTasksContent.Controls.Add(clbSubTasks);

            dgvTasks.DataSource = null;
            dgvTasks.DataSource = tasks;

            cmbTaskSelector.SelectedIndexChanged += (s, e) => LoadSubTasks();
            clbSubTasks.ItemCheck += (s, e) =>
            {
                if (cmbTaskSelector.SelectedIndex >= 0)
                {
                    TaskItem selectedTask = tasks[cmbTaskSelector.SelectedIndex];
                    selectedTask.SubTasks[e.Index].IsCompleted = e.NewValue == CheckState.Checked;
                    dgvTasks.DataSource = null;
                    dgvTasks.DataSource = tasks;
                    UpdateKPIContent();
                    UpdateSalaryContent();
                    UpdateAccountContent();
                }
            };

            UpdateTaskSelector();
        }

        private void UpdateTaskSelector()
        {
            cmbTaskSelector.Items.Clear();
            foreach (var task in tasks)
            {
                cmbTaskSelector.Items.Add(task.Name);
            }
            if (tasks.Count > 0) cmbTaskSelector.SelectedIndex = 0;
        }

        private void LoadSubTasks()
        {
            if (cmbTaskSelector.SelectedIndex >= 0)
            {
                clbSubTasks.Items.Clear();
                TaskItem selectedTask = tasks[cmbTaskSelector.SelectedIndex];
                foreach (var subTask in selectedTask.SubTasks)
                {
                    clbSubTasks.Items.Add(subTask.Name, subTask.IsCompleted);
                }
            }
        }

        private void LoadKPIContent()
        {
            Color textColor = ColorTranslator.FromHtml("#A4AC9E");
            Color backgroundColor = ColorTranslator.FromHtml("#0F2D25");
            Color hoverColor = ColorTranslator.FromHtml("#1A3C32");
            Color headerColor = ColorTranslator.FromHtml("#1A3C32");

            pnlKPIContent.Controls.Clear();

            Label lblTitle = new Label
            {
                Text = "Thông tin KPI",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(30, 30),
                AutoSize = true
            };
            pnlKPIContent.Controls.Add(lblTitle);

            Label lblKpiTarget = new Label
            {
                Text = "Mục tiêu KPI (số công việc hoàn thành):",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 70),
                AutoSize = true
            };
            TextBox txtKpiTarget = new TextBox
            {
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(270, 70),
                Size = new Size(120, 30),
                Text = kpiTarget.ToString()
            };
            Button btnSetKpiTarget = new Button
            {
                Text = "Lưu mục tiêu",
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(400, 70),
                Size = new Size(100, 30)
            };
            btnSetKpiTarget.FlatAppearance.BorderSize = 0;
            btnSetKpiTarget.MouseEnter += (s, e) => btnSetKpiTarget.BackColor = hoverColor;
            btnSetKpiTarget.MouseLeave += (s, e) => btnSetKpiTarget.BackColor = backgroundColor;
            btnSetKpiTarget.Click += (s, e) =>
            {
                if (int.TryParse(txtKpiTarget.Text, out int target) && target >= 0)
                {
                    kpiTarget = target;
                    UpdateKPIContent();
                    UpdateSalaryContent();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập một số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            DataGridView dgvKpi = new DataGridView
            {
                BackgroundColor = backgroundColor,
                ForeColor = textColor,
                Location = new Point(30, 110),
                Size = new Size(620, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true
            };
            dgvKpi.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = headerColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            dgvKpi.Columns.Add("Id", "Id");
            dgvKpi.Columns.Add("Name", "Tên công việc");
            dgvKpi.Columns.Add("Progress", "Tiến độ (%)");
            dgvKpi.Columns.Add("DueDate", "Hạn chót");
            dgvKpi.Columns.Add("KpiStatus", "Trạng thái KPI");

            foreach (var task in tasks)
            {
                string kpiStatus = CalculateKpiStatus(task);
                dgvKpi.Rows.Add(task.Id, task.Name, task.Progress, task.DueDate.ToString("dd/MM/yyyy"), kpiStatus);
            }

            int completedTasks = tasks.Count(t => t.Progress == 100);
            int overdueTasks = tasks.Count(t => t.Progress < 100 && t.DueDate < DateTime.Now);
            double kpiAchievement = kpiTarget > 0 ? (completedTasks / (double)kpiTarget) * 100 : 0;

            Label lblCompletedTasks = new Label
            {
                Text = $"Số công việc hoàn thành: {completedTasks}",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 330),
                AutoSize = true
            };
            Label lblOverdueTasks = new Label
            {
                Text = $"Số công việc quá hạn: {overdueTasks}",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 360),
                AutoSize = true
            };
            Label lblKpiAchievement = new Label
            {
                Text = $"Tỷ lệ đạt KPI: {kpiAchievement:F2}%",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 390),
                AutoSize = true
            };

            pnlKPIContent.Controls.Add(lblKpiTarget);
            pnlKPIContent.Controls.Add(txtKpiTarget);
            pnlKPIContent.Controls.Add(btnSetKpiTarget);
            pnlKPIContent.Controls.Add(dgvKpi);
            pnlKPIContent.Controls.Add(lblCompletedTasks);
            pnlKPIContent.Controls.Add(lblOverdueTasks);
            pnlKPIContent.Controls.Add(lblKpiAchievement);
        }

        private string CalculateKpiStatus(TaskItem task)
        {
            if (task.Progress == 100 && task.DueDate >= DateTime.Now)
                return "Đạt";
            else if (task.Progress < 100 && task.DueDate < DateTime.Now)
                return "Quá hạn";
            else
                return "Không đạt";
        }

        private void UpdateKPIContent()
        {
            LoadKPIContent();
        }

        private void LoadSalaryContent()
        {
            Color textColor = ColorTranslator.FromHtml("#A4AC9E");
            Color backgroundColor = ColorTranslator.FromHtml("#0F2D25");
            Color hoverColor = ColorTranslator.FromHtml("#1A3C32");
            Color headerColor = ColorTranslator.FromHtml("#1A3C32");

            employees = employees ?? new List<Employee>();
            employees.Clear();

            employees.Add(new Employee { Id = 1, Name = "Nguyễn Văn A", BaseSalary = 10000000 });
            employees.Add(new Employee { Id = 2, Name = "Trần Thị B", BaseSalary = 12000000 });
            employees.Add(new Employee { Id = 3, Name = "Lê Văn C", BaseSalary = 8000000 });

            pnlSalaryContent.Controls.Clear();

            Label lblTitle = new Label
            {
                Text = "Thông tin lương",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(30, 30),
                AutoSize = true
            };
            pnlSalaryContent.Controls.Add(lblTitle);

            Label lblSelectEmployee = new Label
            {
                Text = "Chọn nhân viên:",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 70),
                AutoSize = true
            };
            ComboBox cmbSelectEmployee = new ComboBox
            {
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(130, 70),
                Size = new Size(200, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            foreach (var employee in employees)
            {
                cmbSelectEmployee.Items.Add($"{employee.Id} - {employee.Name}");
            }
            if (employees.Count > 0) cmbSelectEmployee.SelectedIndex = 0;

            Label lblBaseSalary = new Label
            {
                Text = "Lương cơ bản:",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(350, 70),
                AutoSize = true
            };
            TextBox txtBaseSalary = new TextBox
            {
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(450, 70),
                Size = new Size(120, 30),
                Text = employees.Count > 0 ? employees[0].BaseSalary.ToString("N0") : "0"
            };
            Button btnUpdateSalary = new Button
            {
                Text = "Cập nhật",
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(580, 70),
                Size = new Size(90, 30)
            };
            btnUpdateSalary.FlatAppearance.BorderSize = 0;
            btnUpdateSalary.MouseEnter += (s, e) => btnUpdateSalary.BackColor = hoverColor;
            btnUpdateSalary.MouseLeave += (s, e) => btnUpdateSalary.BackColor = backgroundColor;

            cmbSelectEmployee.SelectedIndexChanged += (s, e) =>
            {
                if (cmbSelectEmployee.SelectedIndex >= 0)
                {
                    int employeeId = int.Parse(cmbSelectEmployee.SelectedItem.ToString().Split('-')[0].Trim());
                    var selectedEmployee = employees.Find(emp => emp.Id == employeeId);
                    if (selectedEmployee != null)
                    {
                        txtBaseSalary.Text = selectedEmployee.BaseSalary.ToString("N0");
                    }
                }
            };

            btnUpdateSalary.Click += (s, e) =>
            {
                if (cmbSelectEmployee.SelectedIndex >= 0 && double.TryParse(txtBaseSalary.Text, out double baseSalary) && baseSalary >= 0)
                {
                    int employeeId = int.Parse(cmbSelectEmployee.SelectedItem.ToString().Split('-')[0].Trim());
                    var selectedEmployee = employees.Find(emp => emp.Id == employeeId);
                    if (selectedEmployee != null)
                    {
                        selectedEmployee.BaseSalary = baseSalary;
                        UpdateSalaryContent();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập một số hợp lệ cho lương cơ bản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            DataGridView dgvSalary = new DataGridView
            {
                BackgroundColor = backgroundColor,
                ForeColor = textColor,
                Location = new Point(30, 110),
                Size = new Size(620, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true
            };
            dgvSalary.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = headerColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            dgvSalary.Columns.Add("Id", "Id");
            dgvSalary.Columns.Add("Name", "Tên nhân viên");
            dgvSalary.Columns.Add("BaseSalary", "Lương cơ bản (VNĐ)");
            dgvSalary.Columns.Add("KpiBonus", "Thưởng KPI (VNĐ)");
            dgvSalary.Columns.Add("TotalSalary", "Tổng lương (VNĐ)");

            int completedTasks = tasks.Count(t => t.Progress == 100);
            double kpiAchievement = kpiTarget > 0 ? (completedTasks / (double)kpiTarget) * 100 : 0;
            foreach (var employee in employees)
            {
                employee.KpiBonus = employee.BaseSalary * (kpiAchievement / 100) * KpiBonusRate;
                dgvSalary.Rows.Add(employee.Id, employee.Name, employee.BaseSalary.ToString("N0"), employee.KpiBonus.ToString("N0"), employee.TotalSalary.ToString("N0"));
            }

            double totalSalaryPaid = employees.Sum(emp => emp.TotalSalary);
            int employeeCount = employees.Count;
            double averageSalary = employeeCount > 0 ? totalSalaryPaid / employeeCount : 0;

            Label lblTotalSalaryPaid = new Label
            {
                Text = $"Tổng tiền lương đã chi: {totalSalaryPaid:N0} VNĐ",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 330),
                AutoSize = true
            };
            Label lblEmployeeCount = new Label
            {
                Text = $"Số nhân viên: {employeeCount}",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 360),
                AutoSize = true
            };
            Label lblAverageSalary = new Label
            {
                Text = $"Lương trung bình: {averageSalary:N0} VNĐ",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 390),
                AutoSize = true
            };

            pnlSalaryContent.Controls.Add(lblSelectEmployee);
            pnlSalaryContent.Controls.Add(cmbSelectEmployee);
            pnlSalaryContent.Controls.Add(lblBaseSalary);
            pnlSalaryContent.Controls.Add(txtBaseSalary);
            pnlSalaryContent.Controls.Add(btnUpdateSalary);
            pnlSalaryContent.Controls.Add(dgvSalary);
            pnlSalaryContent.Controls.Add(lblTotalSalaryPaid);
            pnlSalaryContent.Controls.Add(lblEmployeeCount);
            pnlSalaryContent.Controls.Add(lblAverageSalary);
        }

        private void UpdateSalaryContent()
        {
            LoadSalaryContent();
        }

        private void LoadAccountContent()
        {
            Color textColor = ColorTranslator.FromHtml("#A4AC9E");
            Color backgroundColor = ColorTranslator.FromHtml("#0F2D25");
            Color hoverColor = ColorTranslator.FromHtml("#1A3C32");

            pnlAccountContent.Controls.Clear();

            Label lblTitle = new Label
            {
                Text = "Thông tin tài khoản",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(30, 30),
                AutoSize = true
            };
            pnlAccountContent.Controls.Add(lblTitle);

            Label lblUsername = new Label
            {
                Text = $"Tên đăng nhập: {currentUser.Username}",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 70),
                AutoSize = true
            };
            Label lblFullName = new Label
            {
                Text = "Họ tên:",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 100),
                AutoSize = true
            };
            TextBox txtFullName = new TextBox
            {
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(120, 100),
                Size = new Size(250, 30),
                Text = currentUser.FullName
            };
            Label lblEmail = new Label
            {
                Text = "Email:",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 140),
                AutoSize = true
            };
            TextBox txtEmail = new TextBox
            {
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(120, 140),
                Size = new Size(250, 30),
                Text = currentUser.Email
            };
            Label lblPhoneNumber = new Label
            {
                Text = "Số điện thoại:",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 180),
                AutoSize = true
            };
            TextBox txtPhoneNumber = new TextBox
            {
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(120, 180),
                Size = new Size(250, 30),
                Text = currentUser.PhoneNumber
            };
            Button btnUpdateInfo = new Button
            {
                Text = "Cập nhật thông tin",
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(380, 180),
                Size = new Size(150, 30)
            };
            btnUpdateInfo.FlatAppearance.BorderSize = 0;
            btnUpdateInfo.MouseEnter += (s, e) => btnUpdateInfo.BackColor = hoverColor;
            btnUpdateInfo.MouseLeave += (s, e) => btnUpdateInfo.BackColor = backgroundColor;
            btnUpdateInfo.Click += (s, e) =>
            {
                currentUser.FullName = txtFullName.Text;
                currentUser.Email = txtEmail.Text;
                currentUser.PhoneNumber = txtPhoneNumber.Text;
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateAccountContent();
            };

            Label lblChangePasswordTitle = new Label
            {
                Text = "Đổi mật khẩu",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(30, 230),
                AutoSize = true
            };
            Label lblOldPassword = new Label
            {
                Text = "Mật khẩu cũ:",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 260),
                AutoSize = true
            };
            TextBox txtOldPassword = new TextBox
            {
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(130, 260),
                Size = new Size(250, 30),
                UseSystemPasswordChar = true
            };
            Label lblNewPassword = new Label
            {
                Text = "Mật khẩu mới:",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 300),
                AutoSize = true
            };
            TextBox txtNewPassword = new TextBox
            {
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(130, 300),
                Size = new Size(250, 30),
                UseSystemPasswordChar = true
            };
            Label lblConfirmPassword = new Label
            {
                Text = "Xác nhận mật khẩu mới:",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 340),
                AutoSize = true
            };
            TextBox txtConfirmPassword = new TextBox
            {
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(180, 340),
                Size = new Size(200, 30),
                UseSystemPasswordChar = true
            };
            Button btnChangePassword = new Button
            {
                Text = "Đổi mật khẩu",
                BackColor = backgroundColor,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(390, 340),
                Size = new Size(130, 30)
            };
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.MouseEnter += (s, e) => btnChangePassword.BackColor = hoverColor;
            btnChangePassword.MouseLeave += (s, e) => btnChangePassword.BackColor = backgroundColor;
            btnChangePassword.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtOldPassword.Text) || string.IsNullOrWhiteSpace(txtNewPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtOldPassword.Text != currentUser.Password)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                currentUser.Password = txtNewPassword.Text;
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPassword.Clear();
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
            };

            int daysActive = (DateTime.Now - currentUser.JoinDate).Days;
            int completedTasks = tasks.Count(t => t.Progress == 100);

            Label lblOverviewTitle = new Label
            {
                Text = "Tổng quan tài khoản",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(30, 390),
                AutoSize = true
            };
            Label lblDaysActive = new Label
            {
                Text = $"Số ngày hoạt động: {daysActive} ngày",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 420),
                AutoSize = true
            };
            Label lblCompletedTasks = new Label
            {
                Text = $"Số công việc đã hoàn thành: {completedTasks}",
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10),
                Location = new Point(30, 450),
                AutoSize = true
            };

            pnlAccountContent.Controls.Add(lblUsername);
            pnlAccountContent.Controls.Add(lblFullName);
            pnlAccountContent.Controls.Add(txtFullName);
            pnlAccountContent.Controls.Add(lblEmail);
            pnlAccountContent.Controls.Add(txtEmail);
            pnlAccountContent.Controls.Add(lblPhoneNumber);
            pnlAccountContent.Controls.Add(txtPhoneNumber);
            pnlAccountContent.Controls.Add(btnUpdateInfo);
            pnlAccountContent.Controls.Add(lblChangePasswordTitle);
            pnlAccountContent.Controls.Add(lblOldPassword);
            pnlAccountContent.Controls.Add(txtOldPassword);
            pnlAccountContent.Controls.Add(lblNewPassword);
            pnlAccountContent.Controls.Add(txtNewPassword);
            pnlAccountContent.Controls.Add(lblConfirmPassword);
            pnlAccountContent.Controls.Add(txtConfirmPassword);
            pnlAccountContent.Controls.Add(btnChangePassword);
            pnlAccountContent.Controls.Add(lblOverviewTitle);
            pnlAccountContent.Controls.Add(lblDaysActive);
            pnlAccountContent.Controls.Add(lblCompletedTasks);
        }

        private void UpdateAccountContent()
        {
            LoadAccountContent();
        }
    }
}