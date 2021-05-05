using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Snake.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Controllers
{
    class ControllerSnake
    {

        private readonly ModelSnake _snake;

        public ControllerSnake(ContentManager content, GraphicsDeviceManager graphics)
        {
            _snake = new ModelSnake(content, graphics);
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            _snake.Update(gameTime, graphics);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _snake.Draw(spriteBatch);
        }

    }
}
