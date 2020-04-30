using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSmart.Core
{
    public enum TaskPriority
    {
        Low,
        High,
        Critical
    }

    public class Task
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public TaskPriority Priority { get; set; }
    }
}
