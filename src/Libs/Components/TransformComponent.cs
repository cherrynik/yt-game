using System.Numerics;
using Scellecs.Morpeh;

namespace Components;

public struct TransformComponent : IComponent
{
    public Vector2 Position;
    public Vector2 Velocity;
}
