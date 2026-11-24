using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Domain.Entities
{
    internal class TaskItem : IEntity
    {
        private string title="";
        public string Title { get { return title; } private set { if (string.IsNullOrEmpty(value)) throw new ArgumentException("Заголовок не может быть пустым"); title = value; } } 
        public string Description { get; private set; } = "";
        private int priority;
        public int Priority { get { return priority; } private set { if (value < 1 || value > 5) throw new ArgumentException("Приоритет должен быть в диапазоне от 1 до 5"); priority = value; } }
        public TaskStatus Status { get; private set; }
        public int ProjectId { get; private set; }
        public int? AssigneeId { get; private set; }
        public DateTime CreatedAt { get;  }
        private DateTime? deadline=null;
        public DateTime? Deadline { get { return deadline; } private set { if (value is not null && DateTime.Compare(DateTime.UtcNow, (DateTime)value) >= 0) throw new ArgumentException("Время дедлайна не может быть раньше текущего момента"); deadline = value; } }

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
            if (!string.IsNullOrEmpty(title))
                throw new ArgumentException("Заголовок не может быть пустым");
            Title = title;
        }
        public void ChangeDescription(string description) { Description = description; }
        public void ChangePriority(int priority) {Priority = priority; }
        public void ChangeStatus(TaskStatus status) {Status = status; }
        public void ChangeProjectId(int projectId) {ProjectId = projectId; }
        public void ChangeAssignedId(int assignedId) {AssigneeId = assignedId;}
        public void ChangeDeadline(DateTime deadline) {Deadline = deadline;}

    }
}
