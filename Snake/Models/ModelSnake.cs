using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Models
{
    class ModelSnake
    {

        private readonly Texture2D[] _snakeTextures = new Texture2D[2];
        private Vector2 _position;

        private const float Speed = 1024.0f;

        private int _direction; // 0, 1, 2, 3 = Left, Right, Up, Down
        private bool _staggering;
        private double _currentSecond;

        public ModelSnake(ContentManager content, GraphicsDeviceManager graphics)
        {

            _snakeTextures[0] = content.Load<Texture2D>("snake_head");
            _snakeTextures[1] = content.Load<Texture2D>("snake_body");

            _direction = 0;
            _staggering = false;
            _currentSecond = 0;

            _position = new Vector2(
                graphics.PreferredBackBufferWidth * 0.5f,
                graphics.PreferredBackBufferHeight * 0.5f);

        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {

            var keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.A))
            {
                _direction = 0;
            }
            else if (keyState.IsKeyDown(Keys.D))
            {
                _direction = 1;
            }
            else if (keyState.IsKeyDown(Keys.W))
            {
                _direction = 2;
            }
            else if (keyState.IsKeyDown(Keys.S))
            {
                _direction = 3;
            }

            if (!_staggering)
            {
                switch (_direction)
                {
                    case 0:
                        _position.X -= Speed * (float) gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 1:
                        _position.X += Speed * (float) gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 2:
                        _position.Y -= Speed * (float) gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                    case 3:
                        _position.Y += Speed * (float) gameTime.ElapsedGameTime.TotalSeconds;
                        break;
                }

                _staggering = true;
                _currentSecond = gameTime.TotalGameTime.TotalSeconds;
            } 
            else
            {
                if (gameTime.TotalGameTime.TotalSeconds >= _currentSecond + 0.5d)
                {
                    _staggering = false;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_snakeTextures[0], _position, Color.White);
        }

    }
}
