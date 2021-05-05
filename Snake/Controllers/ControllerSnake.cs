using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

    }
}
