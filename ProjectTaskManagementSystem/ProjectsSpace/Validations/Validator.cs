using ProjectTaskManagementSystem.ProjectsSpace.Validations.Interfaces;
using ProjectTaskManagementSystem.ProjectsSpace.Validations.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTaskManagementSystem.ProjectsSpace.Validations;

class ProjectValidator : IProjectVliadtor
{
    private readonly ValitionsManager _tilteValidator = new(new List<IProjectValition>
    {
        new LengthRule(),
        new NoPunctuationRule(),
    });
    private readonly ValitionsManager _disriptionValidator = new(new List<IProjectValition>
    {
        new DiscriptionLengthRule(),
    });
    public bool IsDiscreptionValid(string discripton) => _disriptionValidator.Validate(discripton);

    public bool IsTilteValid(string title) => _tilteValidator.Validate(title);
}
