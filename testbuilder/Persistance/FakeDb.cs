namespace testbuilder.Persistance;

public static class FakeDatabase
{
    private static readonly Dictionary<string, List<string>> _data = new()
    {
        { "kön", new List<string> { "kvinna", "man"} }
    };

    public static List<string> GetAllowedValues(string propertyName)
    {
        return _data.ContainsKey(propertyName)
            ? _data[propertyName]
            : new List<string>();
    }
}