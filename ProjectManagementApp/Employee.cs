namespace ProjectManagementApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double BaseSalary { get; set; }
        public double KpiBonus { get; set; }
        public double TotalSalary => BaseSalary + KpiBonus;
    }
}