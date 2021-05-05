using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Models
{
    class ModelSnake
    {

        private readonly Texture2D[] _snakeTextures = new Texture2D[2];
        private Vector2 _position;

        public ModelSnake(ContentManager content, GraphicsDeviceManager graphics)
        {

            _snakeTextures[0] = content.Load<Texture2D>("snake_head");
            _snakeTextures[1] = content.Load<Texture2D>("snake_body");

            _position = new Vector2(
                graphics.PreferredBackBufferWidth * 0.5f,
                graphics.PreferredBackBufferHeight * 0.5f);

        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_snakeTextures[0], _position, Color.White);
        }

    }
}
