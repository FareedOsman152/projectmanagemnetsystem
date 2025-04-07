using ProjectTaskManagementSystem.ProjectsSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectTaskManagementSystem.ProjectsSpace.Project;

namespace ProjectTaskManagementSystem.ProjectsSpace
{
    public enum enStatus { InProgress, Completed, OnHold };
    class Project
    {
        public string ID { get; private set; }
        public string UserId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public enStatus Status { get; private set; }        
        public Project(string iD,string userId, string title, string description, DateTime createdAt, enStatus status)
        {
            ID = iD;
            UserId = userId;
            Title = title?? $"Project{ID}";
            Description = description??" ";
            CreatedAt = createdAt;
            Status = status;
        }
    }
}
