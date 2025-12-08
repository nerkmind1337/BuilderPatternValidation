using testbuilder.Models;
using testbuilder.Validation;

namespace testbuilder;

public class Program
{
    public static void Main()
    {
        var invalidFeature = new Feature
        {
            Name = "InvalidFeature",
            FeatureType = "PersonInfo",
            PropertyTypes = new List<PropertyType>
            {
                new PropertyType {
                    Name = "kön",
                    Value = "ikkebinär",
                    ValidFrom = DateTime.Now.AddDays(1),
                    ValidTo = DateTime.Now // invalid since, this is before the validFrom date
                }
            }
        };
        
        var validFeature = new Feature
        {
            Name = "ValidFeature",
            FeatureType = "PersonInfo",
            PropertyTypes = new List<PropertyType>
            {
                new PropertyType
                {
                    Name = "kön",
                    Value = "kvinna",
                    ValidFrom = DateTime.Now,
                    ValidTo = DateTime.Now.AddDays(5)
                }
            }
        };
        
        // Fake rules from DB - in actual implementation we will use "getRules method"
        var rules = new List<RuleDefinition>
        {
            new RuleDefinition {
                PropertyName = "kön",
                ValidatorType = "required"
            },
            new RuleDefinition {
                PropertyName = "kön",
                ValidatorType = "allowedValues",
            },
            new RuleDefinition {
                PropertyName = "kön",
                ValidatorType = "dateRange"
            }
        };

        // Build validation pipeline
        var builder = new ValidationBuilder();
        var pipeline = builder.Build(validFeature, rules);

        // Run validation
        var validationResult = pipeline.Execute(validFeature);

        // Output result
        if (validationResult.IsValid)
        {
            Console.WriteLine("VALID");
        }
        else
        {
            Console.WriteLine("INVALID");
            foreach (var err in validationResult.Errors)
                Console.WriteLine("- " + err);
        }
    }
}