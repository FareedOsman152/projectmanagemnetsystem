using ProjectTaskManagementSystem.ProjectsSpace.Validations.Interfaces;

namespace ProjectTaskManagementSystem.ProjectsSpace.Validations;

class ValitionsManager
{
    List<IProjectValition> validations;

    public ValitionsManager(List<IProjectValition> validations)
    {
        this.validations = validations;
    }

    public void AddValidation(IProjectValition validation) => validations.Add(validation);
    public bool Validate(string str) => validations.All(v => v.IsValied(str));
}