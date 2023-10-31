using Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Scellecs.Morpeh;

namespace Systems;

public class RenderSystem : ISystem
{
    private readonly SpriteBatch _spriteBatch;
    private readonly Texture2D _pixel;
    public World World { get; set; }

    public RenderSystem(World world, SpriteBatch spriteBatch)
    {
        World = world;
        _spriteBatch = spriteBatch;

        _pixel = new Texture2D(_spriteBatch.GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.Gold });
    }

    public void OnUpdate(float deltaTime)
    {
        Filter filter = World.Filter.With<TransformComponent>().Build();

        foreach (Entity e in filter)
        {
            _spriteBatch.Draw(
                texture: _pixel,
                position: e.GetComponent<TransformComponent>().Position,
                sourceRectangle: new Rectangle(0, 0, 200, 200),
                color: Color.Gold);
        }
    }

    public void Dispose()
    {
    }

    public void OnAwake()
    {
    }
}