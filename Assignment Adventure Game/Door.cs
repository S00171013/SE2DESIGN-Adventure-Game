using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignment_Adventure_Game
{
    class Door : AnimatedSprite
    {
        // Properties.
        public Room Destination { get; set; }

        public enum location { NORTH, SOUTH, WEST, EAST};
        public location doorLocation;
        private bool vertical = false;

        // Declare const int for the distance the player appears from each door they come from.
        const int DOOR_DISTANCE = 100;

        // Constructor
        public Door(Texture2D image, Vector2 position, Color tint, Room destinationIn, bool verticalIn, int frameCount) : base(image, position, tint, frameCount)
        {
            // Set door destination.
            Destination = destinationIn;

            // Set whether or not the door is displayed vertically. If false, the door is displayed horizontally.
            vertical = verticalIn;

            // Get the door's location.
            doorLocation = GetLocation(Position, vertical);       
        }
       
        // This method is called when the player goes through the door. 
        public Room ChangeRoom(Player player)
        {
            #region Get the location of the door and ensure the player appears in the appropriate entrance of the next room.
            // Check each door that exists in the next room.
            foreach (Door exit in Destination.Exits)
            {
                // The following if statements will determine whether the other side of the door is on the north, south, west or east wall of the next room.
                // When the other side's wall location is determined, the player will appear in front of the door in the next room.
                if (exit.doorLocation == location.NORTH && this.doorLocation == location.SOUTH)
                {
                    player.Enter(exit.Position + new Vector2(0, DOOR_DISTANCE));
                    break;
                }

                else if (exit.doorLocation == location.SOUTH && this.doorLocation == location.NORTH)
                {
                    player.Enter(exit.Position + new Vector2(0, -DOOR_DISTANCE));
                    break;
                }

                else if (exit.doorLocation == location.WEST && this.doorLocation == location.EAST)
                {
                    player.Enter(exit.Position + new Vector2(DOOR_DISTANCE, 0));
                    break;
                }

                else if (exit.doorLocation == location.EAST && this.doorLocation == location.WEST)
                {
                    player.Enter(exit.Position + new Vector2(-DOOR_DISTANCE, 0));
                    break;
                }
            }
            #endregion

            // The door's destination is returned and the player should be in the next room.
            return Destination;
        }

        public location GetLocation(Vector2 positionIn, bool verticalIn)
        {
            // This method will determine which wall a door is placed on.

            // Set up variable to return location.
            location locationToReturn = new location();

            #region Determine which wall the door is placed on.
            // If the door is placed vertically...
            if (verticalIn == true)
            {
                // ...Check the door's Y position.
                if (Position.Y < 360)
                {
                    locationToReturn = location.NORTH;
                }

                else if (Position.Y > 360)
                {
                    locationToReturn = location.SOUTH;
                }
            }

            // Otherwise, if the door is placed horizontally...
            else
            {
                // Check the door's X position.
                if (Position.X < 640)
                {
                    locationToReturn = location.WEST;
                }

                else if (Position.X > 640)
                {
                    locationToReturn = location.EAST;
                }
            }
            #endregion

            // Return the wall the door is placed on.
            return locationToReturn;
        }
        }
    }

