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

        private SpriteFont _font;

        private double _timeCounter = 0.0d;
        private bool _showFPS = true;
        private double _frameRate;
        private double _avgFrameRate;
        private readonly double[] _frameRates = new double[32];
        private int _frameRatesIndex;

        private int _score;

        public GameLoop()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.SynchronizeWithVerticalRetrace = false;
            IsFixedTimeStep = false;

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
            _font = Content.Load<SpriteFont>("Font");
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
            else if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                _showFPS ^= true;
            }

            _controllerSnake.Update(gameTime, _graphics);
            _controllerBiscuit.Update(gameTime, _graphics);

            _score = _controllerBiscuit.Score;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _controllerSnake.Draw(_spriteBatch);
            _controllerBiscuit.Draw(_spriteBatch);

            if (_showFPS)
            {

                _timeCounter += gameTime.ElapsedGameTime.TotalMilliseconds;

                if (_timeCounter >= 100)

                {
                    _frameRate = 1 / (float) gameTime.ElapsedGameTime.TotalSeconds;
                    _frameRates[_frameRatesIndex++] = _frameRate;

                    if (_frameRatesIndex == _frameRates.Length)
                    {
                        _frameRatesIndex = 0;

                        double frameRateSum = 0.0d;

                        foreach (double frameRate in _frameRates) frameRateSum += frameRate;

                        _avgFrameRate = frameRateSum / _frameRates.Length;
                    }

                    _timeCounter = 0.0d;
                }

                _spriteBatch.DrawString(_font, $"FPS: {_frameRate}", new Vector2(0, 0), Color.White);
                _spriteBatch.DrawString(_font, $"Avg FPS: {_avgFrameRate}", new Vector2(0, _font.LineSpacing), Color.White);

            }

            _spriteBatch.DrawString(_font, $"Score: {_score}", new Vector2(0, _graphics.PreferredBackBufferWidth - _font.LineSpacing), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
