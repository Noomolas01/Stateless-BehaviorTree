// ========================================================
// Author: Muhammad H. Fayette Mikano
// ========================================================

namespace BehaviorTree.Core.Struct
{


    public struct Vector2
    {
        public float X;
        public float Y;


        public static Vector2 Zero() => new Vector2() { X = 0, Y = 0 };
    }
}
