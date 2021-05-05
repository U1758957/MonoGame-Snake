using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Snake.Controllers;

namespace Snake
{
    public class GameLoop : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private ControllerSnake _controllerSnake;
        private ControllerBiscuit _controllerBiscuit;

        public GameLoop()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 1024;
            _graphics.ApplyChanges();

            _controllerSnake = new ControllerSnake(Content, _graphics);
            _controllerBiscuit = new ControllerBiscuit(Content, _graphics);

            _controllerSnake.setControllerBiscuit(ref _controllerBiscuit);
            _controllerBiscuit.setControllerSnake(ref _controllerSnake);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Content.Unload();
                Content.Dispose();
                Exit();
            }

            _controllerSnake.Update(gameTime, _graphics);
            _controllerBiscuit.Update(gameTime, _graphics);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _controllerSnake.Draw(_spriteBatch);
            _controllerBiscuit.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
