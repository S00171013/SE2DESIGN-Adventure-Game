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
    class Player : AnimatedSprite
    {
        protected Game myGame;
        Viewport gameScreen;

        // Properties.
        public int MaxHealth { get; set; }
        public int Health { get; set; }

        // Fields - public for now.
        public List<Item> Inventory;
        public List<Weapon> Weapons;

        public Item EquippedItem;
        public Weapon EquippedWeapon;

        // Declare bool to keep track of whether the player has been updated initially. - There's likely a way to fix this.
        bool setUp;

        #region Declare variables to handle animation for this class.
        // Set up enum to keep track of player orientation.    
        public enum Direction { DOWN, UP, LEFT, RIGHT }
        public Direction playerDirection;

        // Idle Textures
        public Texture2D FaceLeft { get; set; }
        public Texture2D FaceRight { get; set; }
        public Texture2D FaceUp { get; set; }
        public Texture2D FaceDown { get; set; }

        // Movement Textures.
        public Texture2D MoveLeft { get; set; }
        public Texture2D MoveRight { get; set; }
        public Texture2D MoveUp { get; set; }
        public Texture2D MoveDown { get; set; }
        #endregion

        // Constructor.
        public Player(Game gameIn, Texture2D image, Vector2 position, Color tint, int frameCount) : base(image, position, tint, frameCount)
        {
            myGame = gameIn;
            Image = image;
            Position = position;
            Tint = tint;
            FrameCount = frameCount;

            // The original example had this running in the player's Update method. - In case problems arise later with different rooms.
            gameScreen = myGame.GraphicsDevice.Viewport;
        }

        public virtual void Update(GameTime gameTime)
        {
           

            #region Update the player sprite initially so that it draws to the screen. - Should be fixed later.
            if (setUp == false)
            {
                UpdateAnimation(gameTime);
                setUp = true;
            }
            #endregion

            #region Handle movement.
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                // Left             
                Move(new Vector2(-5, 0));
                Image = MoveLeft;

                playerDirection = Direction.LEFT;

                UpdateAnimation(gameTime);
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                // Right                
                Move(new Vector2(5, 0));
                Image = MoveRight;

                playerDirection = Direction.RIGHT;
                 
                UpdateAnimation(gameTime);
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                // Up                
                Move(new Vector2(0, -5));
                Image = MoveUp;

                playerDirection = Direction.UP;
                      
                UpdateAnimation(gameTime);
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                // Down              
                Move(new Vector2(0, 5));

                Image = MoveDown;

                playerDirection = Direction.DOWN;
                    
                UpdateAnimation(gameTime);
            }

            // Display the correct idle sprite depending on the player's current orientation.
            else
            {
                switch (playerDirection)
                {
                    case Direction.DOWN:
                        Image = FaceDown;
                        break;

                    case Direction.UP:
                        Image = FaceUp;
                        break;

                    case Direction.LEFT:
                        Image = FaceLeft;
                        break;

                    case Direction.RIGHT:
                        Image = FaceRight;
                        break;
                }
            }
            #endregion


            #region Make sure the player stays in the bounds of the screen.
            Position = Vector2.Clamp(Position, Vector2.Zero,
                new Vector2(gameScreen.Width - Image.Width,
                gameScreen.Height - Image.Height));
            #endregion

            
        }

        // This method will take in the player animations that have already been loaded in the game1 class.
        public void GetAnimations(Texture2D faceLeftIn, Texture2D faceRightIn, Texture2D faceUpIn, Texture2D faceDownIn,
            Texture2D moveLeftIn, Texture2D moveRightIn, Texture2D moveUpIn, Texture2D moveDownIn)
        {
            #region Take in Idle textures.
            FaceLeft = faceLeftIn;
            FaceRight = faceRightIn;
            FaceUp = faceUpIn;
            FaceDown = faceDownIn;
            #endregion

            #region Take in Movement textures.
            MoveLeft = moveLeftIn;
            MoveRight = moveRightIn;
            MoveUp = moveUpIn;
            MoveDown = moveDownIn;
            #endregion
        }

        // This method is called whenever the player goes through a door.
        public void Enter(Vector2 newPositionIn)
        {
            // Chnage the player's position to where they entered the room.
            Position = newPositionIn;
        }
    }
}
