using Components;
using Implementations;
using Scellecs.Morpeh;

namespace Systems;

public class MovementSystem : ISystem
{
    private readonly IMovement _movement;
    public World World { get; set; }

    public MovementSystem(World world, IMovement movement)
    {
        _movement = movement;
        World = world;
    }

    public void OnAwake()
    {
        Console.WriteLine((nameof(MovementSystem), "OnAwake"));
    }

    public void OnUpdate(float deltaTime)
    {
        Filter filter = World.Filter
            .With<InputMovableComponent>()
            .With<TransformComponent>()
            .Build();

        foreach (Entity e in filter)
        {
            ref TransformComponent transform = ref e.GetComponent<TransformComponent>();

            transform.Position = _movement.Move(from: transform.Position, by: transform.Velocity);
        }
    }

    public void Dispose()
    {
    }
}