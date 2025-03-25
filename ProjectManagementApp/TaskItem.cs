using System;
using System.Collections.Generic;

namespace ProjectManagementApp
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = "Chưa bắt đầu";
        public DateTime DueDate { get; set; }
        public List<SubTask> SubTasks { get; set; } = new List<SubTask>();
        public int Progress
        {
            get
            {
                if (SubTasks.Count == 0) return 0;
                int completed = SubTasks.Count(st => st.IsCompleted);
                return (int)((completed / (float)SubTasks.Count) * 100);
            }
        }
    }

    public class SubTask
    {
        public string Name { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}