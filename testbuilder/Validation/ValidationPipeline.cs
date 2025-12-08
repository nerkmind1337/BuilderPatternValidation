using testbuilder.Models;

namespace testbuilder.Validation;

public class ValidationPipeline
{
    private readonly List<IValidator> _validators = new();

    public void Add(IValidator v) => _validators.Add(v);

    public ValidationResult Execute(Feature feature)
    {
        var result = new ValidationResult();

        foreach (var v in _validators)
        {
            if (!v.Validate(feature))
                result.Errors.Add(v.ErrorMessage);
        }

        return result;
    }
}