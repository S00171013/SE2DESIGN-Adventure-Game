using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignment_Adventure_Game
{
    class Room
    {
        // Properties.
        public Texture2D Background { get; set; }

        // Fields.
        List<Item> roomItems;
        public List<Door> Exits { get; set; }

        // Constructor
        public Room(Texture2D backgroundIn, List<Item> roomItemsIn, List<Door> exitsIn)
        {
            Background = backgroundIn;
            roomItems = roomItemsIn;
            Exits = exitsIn;
        }

        
        public virtual void Update(GameTime gtIn)
        {
            // Draw Items.
            foreach (Item item in roomItems)
            {
                item.Update(gtIn);
            }

            // Update exit doors.
            //foreach (Door exit in exits)
            //{
            //    exit.Update(gtIn);
            //}
        }

        public virtual void Draw(SpriteBatch spIn)
        {                   
            // Draw floor.
            spIn.Draw(Background, new Vector2(0, 0), Color.White);

            // Draw Items.
            foreach (Item item in roomItems)
            {
                item.Draw(spIn);
                
            }

            // Draw exit doors.
            foreach(Door exit in Exits)
            {
                exit.Draw(spIn);
            }       
        }
    }
}
