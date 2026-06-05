namespace BehaviorTree.Core.Struct;

public struct Vector2
{
    public float X;
    public float Y;


    public static Vector2 Zero() => new() { X = 0, Y = 0 };
}
