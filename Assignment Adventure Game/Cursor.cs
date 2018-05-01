using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignment_Adventure_Game
{
    class Cursor
    {
        protected Game myGame;

        // Cursor properties.
        public Texture2D Texture { get; }
        public Rectangle BoundingRectangle { get; set; }

        public Cursor(Game1 gameIn, Texture2D textureIn, Rectangle boundingRectIn)
        {
            myGame = gameIn;
            Texture = textureIn;
            BoundingRectangle = boundingRectIn;
        } 
    }
}
