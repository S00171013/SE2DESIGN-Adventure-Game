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

        private float angle = 0;

        // Cursor properties.
        public Texture2D Texture { get; }
        public Rectangle BoundingRectangle { get; set; }

        public Cursor(Game1 gameIn, Texture2D textureIn, Rectangle boundingRectIn)
        {
            myGame = gameIn;
            Texture = textureIn;
            BoundingRectangle = boundingRectIn;
        } 

        public void Update()
        {
            angle += 0.09f;
        }

        public void Draw(SpriteBatch spIn)
        {
            spIn.Draw(Texture, new Vector2(BoundingRectangle.X, BoundingRectangle.Y), null,
                 Color.White, angle, new Vector2(Texture.Width/2, Texture.Height/2), 0.1f, SpriteEffects.None, 1);
        }
    }
}
