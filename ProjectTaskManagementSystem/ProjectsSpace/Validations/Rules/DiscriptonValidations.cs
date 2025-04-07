using ProjectTaskManagementSystem.ProjectsSpace.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.ProjectsSpace.Validations.Rules;

class DiscriptionLengthRule : IProjectValition
{
    public bool IsValied(string str) => str.Length > 10;
}

