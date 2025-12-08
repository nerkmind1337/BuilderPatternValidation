namespace testbuilder.Models;

public class Feature
{
    public string Name { get; set; }
    public string FeatureType { get; set; }
    public List<PropertyType> PropertyTypes { get; set; } = new();
}