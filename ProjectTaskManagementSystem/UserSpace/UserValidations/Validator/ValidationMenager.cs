using ProjectTaskManagementSystem.UserSpace.UserValidations.Interfaces;

namespace ProjectTaskManagementSystem.UserSpace.UserValidations.Validator;
/// <summary>
/// Menage the validation rules in IEnumerable container
/// </summary>
internal class ValidationMenager
{
    private readonly List<IUserDataValidation> _rules = new List<IUserDataValidation>();

    public ValidationMenager(IEnumerable<IUserDataValidation> rules)
    {
        _rules = rules.ToList();
    }

    public void AddRule(IUserDataValidation rule) => _rules.Add(rule);
    public bool Validate(string? input) => _rules.All(rule => rule.IsValid(input));
}

