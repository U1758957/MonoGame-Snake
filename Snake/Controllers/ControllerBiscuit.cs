using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Snake.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Controllers
{
    class ControllerBiscuit
    {

        private readonly ModelBiscuit _modelBiscuit;

        public ControllerBiscuit(ContentManager content, GraphicsDeviceManager graphics)
        {
            _modelBiscuit = new ModelBiscuit(content, graphics);
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _modelBiscuit.Draw(spriteBatch);
        }

    }
}
