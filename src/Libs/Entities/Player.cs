using Components;
using Scellecs.Morpeh;

namespace Entities;

public static class Player
{
    public static Entity Create(World @in)
    {
        Entity e = @in.CreateEntity();

        e.AddComponent<InputMovableComponent>();
        e.AddComponent<TransformComponent>();

        return e;
    }
}