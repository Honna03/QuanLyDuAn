using System;

namespace ProjectManagementApp
{
    public class UserAccount
    {
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        public string Password { get; set; } = string.Empty; // Giả lập mật khẩu
    }
}