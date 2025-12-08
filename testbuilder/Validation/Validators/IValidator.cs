using testbuilder.Models;

namespace testbuilder;

public interface IValidator
{
    bool Validate(Feature feature);
    string ErrorMessage { get; }
}
