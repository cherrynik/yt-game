using System.Numerics;
using Components;
using Implementations;
using Scellecs.Morpeh;

namespace Systems;

public class InputSystem : ISystem
{
    private readonly IInputScanner _inputScanner;
    public World World { get; set; }

    public InputSystem(World world, IInputScanner inputScanner)
    {
        World = world;
        _inputScanner = inputScanner;
    }

    public void OnAwake()
    {
    }

    public void OnUpdate(float deltaTime)
    {
        Filter filter = World.Filter
            .With<InputMovableComponent>()
            .With<TransformComponent>()
            .Build();

        Vector2 direction = _inputScanner.GetDirection();

        foreach (Entity e in filter)
        {
            ref TransformComponent transform = ref e.GetComponent<TransformComponent>();

            transform.Velocity = direction;
        }
    }

    public void Dispose()
    {
    }
}