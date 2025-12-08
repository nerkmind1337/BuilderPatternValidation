using testbuilder.Models;

namespace testbuilder.Validation;

public class AllowedValuesValidator : IValidator
{
    private readonly string _propertyName;
    private readonly List<string> _allowedValues;

    public AllowedValuesValidator(string propertyName, List<string> allowedValues)
    {
        _propertyName = propertyName;
        _allowedValues = allowedValues;
    }

    public string ErrorMessage => $"{_propertyName} contains a value not in the allowed list.";

    public bool Validate(Feature feature)
    {
        var prop = feature.PropertyTypes.FirstOrDefault(p => p.Name == _propertyName);
        if (prop == null) return true;

        return _allowedValues.Contains(prop.Value);
    }
}
