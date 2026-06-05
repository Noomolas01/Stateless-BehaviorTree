namespace BehaviorTree.Core.Tree;

public class Blackboard
{
    private readonly Dictionary<string, object?> _memory = new();

    public object? Get(string pKey)
    {
        if (_memory.TryGetValue(pKey, out object? value))
        {
            return value;
        }

        Console.WriteLine($"Key: {pKey} doesn't exist.");
        return null;
    }

    public void Set<T>(string pKey, T pValue)
    {
        if (!_memory.ContainsKey(pKey))
        {
            Console.WriteLine($"Key: {pKey} added.");

        }

        _memory[pKey] = pValue;
    }
}
