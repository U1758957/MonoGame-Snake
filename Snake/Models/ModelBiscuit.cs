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

            var random = new Random();

            float x = ((float) Math.Round(graphics.PreferredBackBufferWidth * 0.1f) * 0.1f);
            float y = ((float) Math.Round(graphics.PreferredBackBufferHeight * 0.1f) * 0.1f);

            _position = new Vector2(x, y);

        }

    }
}
