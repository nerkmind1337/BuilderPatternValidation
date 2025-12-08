namespace testbuilder.Models;

public class RuleDefinition
{
    public string PropertyName { get; set; }
    public string ValidatorType { get; set; } // e.g. "required", "allowedValues", or "dateRange" or something
}
