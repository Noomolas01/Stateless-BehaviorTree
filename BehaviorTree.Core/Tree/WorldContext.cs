namespace BehaviorTree.Core.Tree;

public class WorldContext
{
    private readonly Dictionary<string, object?> _World = new();

    public object? Get(string pKey)
    {
        if (_World.TryGetValue(pKey, out object? value))
        {
            return value;
        }

        Console.WriteLine("Key doesn't exist.");
        return null;
    }

    public void Set<T>(string pKey, T pValue)
    {
        if (_World.ContainsKey(pKey))
        {
            _World[pKey] = pValue;
            return;
        }

        Console.WriteLine("Key doesn't exist.");
    }
}
