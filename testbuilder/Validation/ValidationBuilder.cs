using testbuilder.Models;

namespace testbuilder.Validation;

public class ValidationBuilder
{
    public ValidationPipeline Build(Feature feature, List<RuleDefinition> rules)
    {
        var pipeline = new ValidationPipeline();

        foreach (var rule in rules)
        {
            var validator = ValidatorFactory.Create(rule);
            pipeline.Add(validator);
        }

        return pipeline;
    }
}
