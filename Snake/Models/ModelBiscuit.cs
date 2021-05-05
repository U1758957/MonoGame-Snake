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

            RectBiscuit = new Rectangle((int) _position.X, (int) _position.Y, _biscuitTexture.Width, _biscuitTexture.Height);

        }

        public Rectangle RectBiscuit { get; private set; }

        public bool Collided { private get; set; }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            if (Collided)
            {
                Random rnd = new Random();

                _position.X = rnd.Next(0, graphics.PreferredBackBufferWidth);
                _position.Y = rnd.Next(0, graphics.PreferredBackBufferHeight);

                RectBiscuit = new Rectangle((int) _position.X, (int) _position.Y, _biscuitTexture.Width, _biscuitTexture.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_biscuitTexture, _position, Color.White);
        }

    }
}
