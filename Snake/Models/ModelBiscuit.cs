using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Models
{
    class ModelBiscuit
    {

        private readonly Texture2D _biscuitTexture;
        private Vector2 _position;

        public ModelBiscuit(ContentManager content, GraphicsDeviceManager graphics)
        {

            _biscuitTexture = content.Load<Texture2D>("biscuit");

            _position = new Vector2(
                graphics.PreferredBackBufferWidth * 0.25f,
                graphics.PreferredBackBufferHeight * 0.25f);

        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_biscuitTexture, _position, Color.White);
        }

    }
}
