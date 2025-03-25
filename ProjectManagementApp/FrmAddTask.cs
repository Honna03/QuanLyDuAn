using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ProjectManagementApp;

namespace ProjectManagementApp
{
    public partial class FrmAddTask : Form
    {
        private TaskItem _newTask = new TaskItem();
        private bool _isEditMode = false; // Biến để xác định chế độ (thêm mới hay chỉnh sửa)

        [Browsable(false)]
        public TaskItem NewTask
        {
            get => _newTask;
            set => _newTask = value ?? new TaskItem(); // Đảm bảo không gán null
        }

        // Constructor cho chế độ thêm mới
        public FrmAddTask()
        {
            InitializeComponent();
            cmbStatus.SelectedIndex = 0;
            AddHoverEffects();
            ApplyColorScheme();
            this.Text = "Thêm công việc";
            btnSave.Text = "Lưu"; // Đặt tiêu đề nút phù hợp với chế độ
        }

        // Constructor cho chế độ chỉnh sửa
        public FrmAddTask(TaskItem taskToEdit) : this()
        {
            _isEditMode = true;
            _newTask = taskToEdit ?? new TaskItem();
            this.Text = "Chỉnh sửa công việc";
            btnSave.Text = "Cập nhật"; // Thay đổi tiêu đề nút khi ở chế độ chỉnh sửa

            // Hiển thị thông tin công việc hiện tại
            txtTaskName.Text = _newTask.Name;
            cmbStatus.Text = _newTask.Status;
            dtpDueDate.Value = _newTask.DueDate;

            // Hiển thị các SubTask
            foreach (var subTask in _newTask.SubTasks)
            {
                AddSubTaskToPanel(subTask);
            }
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

            foreach (Control control in flpSubTasks.Controls)
            {
                ApplyControlColors(control, textColor, backgroundColor);
            }
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
            else if (control is Panel panel)
            {
                foreach (Control subControl in panel.Controls)
                {
                    ApplyControlColors(subControl, textColor, backgroundColor);
                }
            }
        }

        private void AddHoverEffects()
        {
            Color hoverColor = ColorTranslator.FromHtml("#1A3C32");
            Color backgroundColor = ColorTranslator.FromHtml("#0F2D25");

            btnAddSubTask.MouseEnter += (s, e) => btnAddSubTask.BackColor = hoverColor;
            btnAddSubTask.MouseLeave += (s, e) => btnAddSubTask.BackColor = backgroundColor;
            btnSave.MouseEnter += (s, e) => btnSave.BackColor = hoverColor;
            btnSave.MouseLeave += (s, e) => btnSave.BackColor = backgroundColor;
            btnCancel.MouseEnter += (s, e) => btnCancel.BackColor = hoverColor;
            btnCancel.MouseLeave += (s, e) => btnCancel.BackColor = backgroundColor;
        }

        private void AddSubTaskToPanel(SubTask subTask)
        {
            Color textColor = ColorTranslator.FromHtml("#A4AC9E");
            Color backgroundColor = ColorTranslator.FromHtml("#0F2D25");
            Color hoverColor = ColorTranslator.FromHtml("#1A3C32");

            Panel subTaskPanel = new Panel
            {
                Size = new System.Drawing.Size(340, 30),
                BackColor = backgroundColor,
                Margin = new Padding(5)
            };

            CheckBox subTaskCheckBox = new CheckBox
            {
                Text = subTask.Name,
                ForeColor = textColor,
                Font = new System.Drawing.Font("Segoe UI", 10F),
                AutoSize = true,
                Location = new System.Drawing.Point(5, 5),
                Checked = subTask.IsCompleted
            };

            Button btnDelete = new Button
            {
                Text = "X",
                ForeColor = textColor,
                BackColor = backgroundColor,
                FlatStyle = FlatStyle.Flat,
                Size = new System.Drawing.Size(25, 25),
                Location = new System.Drawing.Point(310, 2)
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.MouseEnter += (s, e) => btnDelete.BackColor = hoverColor;
            btnDelete.MouseLeave += (s, e) => btnDelete.BackColor = backgroundColor;
            btnDelete.Click += (s, e) =>
            {
                flpSubTasks.Controls.Remove(subTaskPanel);
            };

            subTaskPanel.Controls.Add(subTaskCheckBox);
            subTaskPanel.Controls.Add(btnDelete);
            flpSubTasks.Controls.Add(subTaskPanel);
        }

        private void btnAddSubTask_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSubTask.Text))
            {
                SubTask newSubTask = new SubTask
                {
                    Name = txtSubTask.Text,
                    IsCompleted = false
                };
                AddSubTaskToPanel(newSubTask);
                txtSubTask.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên công việc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_isEditMode)
            {
                _newTask.Id = DateTime.Now.GetHashCode(); // Gán ID mới nếu là thêm mới
            }

            _newTask.Name = txtTaskName.Text;
            _newTask.Status = cmbStatus.Text;
            _newTask.DueDate = dtpDueDate.Value;
            _newTask.SubTasks.Clear(); // Xóa các SubTask cũ

            foreach (Control control in flpSubTasks.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control subControl in panel.Controls)
                    {
                        if (subControl is CheckBox checkBox)
                        {
                            _newTask.SubTasks.Add(new SubTask
                            {
                                Name = checkBox.Text,
                                IsCompleted = checkBox.Checked
                            });
                        }
                    }
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}