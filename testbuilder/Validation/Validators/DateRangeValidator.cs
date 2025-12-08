using testbuilder.Models;

namespace testbuilder.Validation;

public class DateRangeValidator : IValidator
{
    private readonly string _property;

    public DateRangeValidator(string property)
    {
        _property = property;
    }

    public string ErrorMessage => $"{_property} has an invalid date range.";

    public bool Validate(Feature feature)
    {
        var prop = feature.PropertyTypes.FirstOrDefault(p => p.Name == _property);
        if (prop == null) return true;

        return prop.ValidFrom <= prop.ValidTo;
    }
}