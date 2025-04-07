using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.ProjectsSpace.Repository.Interfaces
{
    interface IProjectRepository
    {
        public void Add(Project project);
        public void Delete(Project project);
        public void Update(Project project);
        public Project GetById(int Id);
        public IEnumerable<Project> GetAll();
    }
}
