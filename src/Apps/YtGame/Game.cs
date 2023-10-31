using Entities;
using Implementations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Scellecs.Morpeh;
using Systems;

namespace YtGame
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SystemsGroup _systemsGroup;
        private SystemsGroup _renderSystemsGroup;
        private World _world;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _world = World.Create();
            Player.Create(@in: _world);

            _renderSystemsGroup = _world.CreateSystemsGroup();
            _renderSystemsGroup.AddSystem(new RenderSystem(_world, _spriteBatch));

            _systemsGroup = _world.CreateSystemsGroup();
            _systemsGroup.AddSystem(new InputSystem(_world, new KeyboardInput()), enabled: true);
            _systemsGroup.AddSystem(new MovementSystem(_world, new SimpleMovement()), enabled: true);
            _systemsGroup.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _systemsGroup.Update(deltaTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _spriteBatch.Begin();
            _renderSystemsGroup.Update(deltaTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}