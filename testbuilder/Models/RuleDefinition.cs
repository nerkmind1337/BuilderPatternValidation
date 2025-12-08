namespace testbuilder.Models;

public class RuleDefinition
{
    public string PropertyName { get; set; }
    public string ValidatorType { get; set; } // e.g. "required", "allowedValues"
    public Dictionary<string, string> Config { get; set; } = new();
}
