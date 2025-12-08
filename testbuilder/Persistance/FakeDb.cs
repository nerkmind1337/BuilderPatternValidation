namespace testbuilder.Persistance;

public static class FakeDatabase
{
    private static readonly Dictionary<string, List<string>> _data = new()
    {
        { "StatusCodes", new List<string> { "Active", "Inactive", "Pending" } }
    };

    public static List<string> GetAllowedValues(string table)
    {
        return _data.ContainsKey(table)
            ? _data[table]
            : new List<string>();
    }
}