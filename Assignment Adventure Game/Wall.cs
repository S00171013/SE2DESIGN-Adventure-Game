using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignment_Adventure_Game
{
    class Wall : AnimatedSprite
    {
        public Wall(Texture2D image, Vector2 position, Color tint, int frameCountIn) : base(image, position, tint, frameCountIn)
        {

        }             
    }
}
