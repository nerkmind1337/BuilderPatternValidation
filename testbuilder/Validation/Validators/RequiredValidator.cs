using testbuilder.Models;

namespace testbuilder.Validation;

public class RequiredValidator : IValidator
{
    private readonly string _property;

    public RequiredValidator(string property)
    {
        _property = property;
    }

    public string ErrorMessage => $"{_property} is required.";

    public bool Validate(Feature feature)
    {
        return feature.PropertyTypes.Any(p =>
            p.Name == _property &&
            !string.IsNullOrWhiteSpace(p.Value)
        );
    }
}