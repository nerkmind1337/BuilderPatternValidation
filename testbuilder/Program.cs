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
            FeatureType = "TypeA",
            PropertyTypes = new List<PropertyType>
            {
                new PropertyType {
                    Name = "status",
                    Value = "Broken",
                    ValidFrom = DateTime.Now.AddDays(1),
                    ValidTo = DateTime.Now // invalid since, this is before the validFrom date
                }
            }
        };
        
        var validFeature = new Feature
        {
            Name = "ValidFeature",
            FeatureType = "TypeA",
            PropertyTypes = new List<PropertyType>
            {
                new PropertyType
                {
                    Name = "status",
                    Value = "Active",
                    ValidFrom = DateTime.Now,
                    ValidTo = DateTime.Now.AddDays(5)
                }
            }
        };
        
        // Fake rules from DB - in actual implementation we will use "getRules method"
        var rules = new List<RuleDefinition>
        {
            new RuleDefinition {
                PropertyName = "status",
                ValidatorType = "required"
            },
            new RuleDefinition {
                PropertyName = "status",
                ValidatorType = "allowedValues",
                Config = new() { { "table", "StatusCodes" } }
            },
            new RuleDefinition {
                PropertyName = "status",
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