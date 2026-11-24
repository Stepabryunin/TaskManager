using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Domain.Entities
{
    internal class TaskItem : IEntity
    {
        private string title="";
        public string Title { get { return title; } private set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Заголовок не может быть пустым", nameof(value)); title = value; } }
        private string description;
        public string Description { get { return description; } private set { description = value ?? string.Empty; } }
        private int priority;
        public int Priority { get { return priority; } private set { if (value < 1 || value > 5) throw new ArgumentOutOfRangeException("Приоритет должен быть в диапазоне от 1 до 5", value, nameof(value)); priority = value; } }
        public  TaskStatus Status { get; private set; }
        public int ProjectId { get; private set; }
        public int? AssigneeId { get; private set; }
        public DateTime CreatedAt { get;  }
        private DateTime? deadline=null;
        public DateTime? Deadline { get { return deadline; } private set { if (value is not null && DateTime.Compare(DateTime.UtcNow, (DateTime)value) >= 0) throw new ArgumentException("Время дедлайна не может быть раньше текущего момента", nameof(value)); deadline = value; } }

        public TaskItem(int id, string title_, string description, int priority,  TaskStatus status, int projectId, DateTime? deadline=null, int? assigneeId = null) :base(id)
        {
            Title = title_;
            Description = description;
            Priority = priority;
            Status = status;
            ProjectId = projectId;
            AssigneeId = assigneeId;
            CreatedAt = DateTime.UtcNow;
            Deadline = deadline;
        }
        public void ChangeTitle(string title)
        {
            Title = title;
        }
        public void ChangeDescription(string description) { Description = description; }
        public void ChangePriority(int priority) {Priority = priority; }
        public void ChangeStatus(TaskStatus status) 
        {
            Status = status;

        }
        public void ChangeProjectId(int projectId)
        {
            if (projectId <= 0)
            {
                throw new ArgumentOutOfRangeException("Id проекта не может быть отрицательным",
                    nameof(projectId));
            }
            
            ProjectId = projectId; 
        }
        public void ChangeAssignedId(int assignedId)
        {
            if (assignedId <= 0)
            {
                throw new ArgumentOutOfRangeException("Id исполнителя не может быть отрицательным",
                    nameof(assignedId));
            }

            AssigneeId = assignedId;
        }
        public void Unassign() {AssigneeId = null;}
        public void ChangeDeadline(DateTime? deadline) {Deadline = deadline;}


    }
}
