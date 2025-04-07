using ProjectTaskManagementSystem.ProjectsSpace.Validations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.ProjectsSpace.Validations.Rules
{
    class LengthRule : IProjectValition
    {
        public bool IsValied(string str) => str.Length > 1;
    }

    class NoPunctuationRule : IProjectValition
    {
        public bool IsValied(string str) => !str.Any(s => char.IsPunctuation(s));
    }

}
