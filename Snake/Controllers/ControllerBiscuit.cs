using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

    }
}
