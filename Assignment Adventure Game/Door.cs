using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignment_Adventure_Game
{
    class Door : SimpleSprite
    {
        // Properties.
        public Room Destination { get; set; }

        // Constructor
        public Door(Texture2D image, Vector2 position, Color tint, Room destinationIn) : base(image, position, tint)
        {
            Destination = destinationIn;
        }

        //public virtual void Update(GameTime gameTime)
        //{
            
        //}


        // This method is called when the player goes through the door. 
        public Room ChangeRoom()
        {
            // The door's destination is returned and the player should be in the next room.
            return Destination;
        }
    }
}
