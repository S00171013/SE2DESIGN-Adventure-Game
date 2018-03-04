using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Monogame classes are in these namespaces.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Assignment_Adventure_Game
{
    class SimpleSprite
    {
        // Variables
        public Texture2D Image { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Bounds;
        public Color Tint { get; set; }
     
        // Used to determine where inside the spritesheet we are drawing
        public Rectangle SourceRectangle;

        

        // Constructor
        public SimpleSprite(Texture2D image, Vector2 position, Color tint)
        {         
            Image = image;
            Position = position;
            Tint = tint;

            // Set bounds.
            Bounds = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);

        }
        
        // Caller has a spritebatch ready and has already called Begin
        public void Draw(SpriteBatch sp)
        {
            //sp.Draw(Image, Position, SourceRectangle, Tint);
             sp.Draw(Image, Position, Tint);
        }

        public void Draw(SpriteBatch sp, SpriteFont sfont)
        {
            sp.Draw(Image, Position, Tint);
            sp.DrawString(sfont, Position.ToString(), Position, Color.White);
        }

        public void Move(Vector2 delta)
        {
            Position += delta;
            Bounds.X = (int)Position.X;
            Bounds.Y = (int)Position.Y;
        }

        // Check for collision
        public bool CheckCollision(AnimatedSprite other)
        {
            // Rectangle intersects

            // If there's a collision change the tint to red
            // Otherwise set tint to white
            if ((Bounds.Intersects(other.Bounds)))
            {
                Tint = Color.Red;
                return true;
            }

            else
            {
                Tint = Color.White;
                return false;
            }
        }
    }
}
