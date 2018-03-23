﻿using System;
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
        public List<Item> RoomItems;
        public List<Door> Exits { get; set; }
        public List<Wall> Walls;
       

        // Constructor
        public Room(Texture2D backgroundIn, List<Item> roomItemsIn, Dictionary<string, Texture2D> wallsIn)
        {
            Background = backgroundIn;
            RoomItems = roomItemsIn;

            Exits = new List<Door>();
            Walls = new List<Wall>();

            // Set up walls.
            SetUpWalls(wallsIn);
        }
       
        public virtual void Update(GameTime gtIn)
        {
            // Draw Items.
            foreach (Item item in RoomItems)
            {
                item.Update(gtIn);
            }       
        }

        public virtual void Draw(SpriteBatch spIn)
        {            
            // Draw floor.
            spIn.Draw(Background, new Vector2(0, 0), Color.White);

            // Draw Walls.
            foreach (Wall wall in Walls)
            {
                wall.DrawNoRect(spIn);
            }

            // Draw Items.
            foreach (Item item in RoomItems)
            {
                item.Draw(spIn);
                
            }

            // Draw exit doors.
            foreach(Door exit in Exits)
            {
                exit.Draw(spIn);
            }       
        }

        public void GetExits(List<Door> exitsIn)
        {          
            Exits = exitsIn;
        }

        public void SetUpWalls(Dictionary<string, Texture2D> wallTexturesIn)
        {
            // Set up position variable for the wall's position.
            Vector2 wallPosition;

            foreach(var wall in wallTexturesIn)
            {
                // Get the wall's placement on the screen and add the walls to the room's wall list. 
                switch(wall.Key)
                {
                    case "C North":
                        wallPosition = new Vector2(0, -60);
                        Walls.Add(new Wall(wall.Value, wallPosition, Color.White, 1));
                        break;

                    case "D South":
                        wallPosition = new Vector2(0, 650);
                        Walls.Add(new Wall(wall.Value, wallPosition, Color.White, 1));
                        break;

                    case "A West":
                        wallPosition = new Vector2(-60, 0);
                        Walls.Add(new Wall(wall.Value, wallPosition, Color.White, 1));
                        break;

                    case "B East":
                        wallPosition = new Vector2(1220, 0);
                        Walls.Add(new Wall(wall.Value, wallPosition, Color.White, 1));
                        break;
                }            
            }
        }
    }
}
