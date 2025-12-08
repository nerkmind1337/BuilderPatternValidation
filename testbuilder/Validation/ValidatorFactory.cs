using testbuilder.Models;
using testbuilder.Persistance;
using testbuilder.Validation;

namespace testbuilder;


public class ValidatorFactory
{
    public static IValidator Create(RuleDefinition rule)
    {
        return rule.ValidatorType switch
        {
            "required" =>
                new RequiredValidator(rule.PropertyName),

            "dateRange" =>
                new DateRangeValidator(rule.PropertyName),

            "allowedValues" =>
                new AllowedValuesValidator(
                    rule.PropertyName,
                    FakeDatabase.GetAllowedValues(rule.PropertyName)
                ),

            _ =>
                throw new NotImplementedException(
                    $"Validator '{rule.ValidatorType}' not implemented"
                )
        };
    }
}