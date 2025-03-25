using System;
using System.Drawing;
using System.Windows.Forms;
using ProjectManagementApp;

namespace ProjectManagementApp
{
    public partial class FrmDangnhap : Form
    {
        public FrmDangnhap()
        {
            InitializeComponent();
            AddHoverEffects();
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
        }

        private void AddHoverEffects()
        {
            Color hoverColor = ColorTranslator.FromHtml("#1A3C32");
            Color backgroundColor = ColorTranslator.FromHtml("#0F2D25");

            btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = hoverColor;
            btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = backgroundColor;
            btnExit.MouseEnter += (s, e) => btnExit.BackColor = hoverColor;
            btnExit.MouseLeave += (s, e) => btnExit.BackColor = backgroundColor;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtUsername.Text == "admin" && txtPassword.Text == "admin123")
            {
                this.Hide();
                new FrmMain().Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}