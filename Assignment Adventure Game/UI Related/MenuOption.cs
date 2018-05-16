using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_Adventure_Game
{
    class MenuOption : AnimatedSprite
    {
        protected Game myGame;

        // Menu Option Properties
        public string Function { get; }
        public bool HighlightedStatus { get; set; }

        public MenuOption(Game gameIn, Texture2D image, Vector2 position, Color tint, int frameCountIn, string functionIn, bool highlightedStatusIn) : base(image, position, tint, frameCountIn)
        {
            myGame = gameIn;
            Function = functionIn;
            HighlightedStatus = highlightedStatusIn;
        }

        public void GetHighlightedStatus(bool statusIn)
        {
            HighlightedStatus = statusIn;

            AlterColour();
        }

        public void AlterColour()
        {
            if (HighlightedStatus == true)
            {
                Tint = Color.MonoGameOrange;
            }

            else
            {
                Tint = Color.White;
            }
        }

        public bool CheckClicked(Point mousePosIn)
        {          
            if (Bounds.Contains(mousePosIn))
            {
                return true;
            }

            else return false;

        }
    }
}
