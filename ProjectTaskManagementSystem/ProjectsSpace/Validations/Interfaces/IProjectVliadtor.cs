using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.ProjectsSpace.Validations.Interfaces;

interface IProjectVliadtor
{
    bool IsTilteValid(string title);
    bool IsDiscreptionValid(string title);
}
