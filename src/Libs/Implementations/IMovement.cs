using System.Numerics;

namespace Implementations;

public interface IMovement
{
    Vector2 Move(Vector2 from, Vector2 by);
}