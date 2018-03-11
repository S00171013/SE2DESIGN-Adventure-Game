using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_Adventure_Game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        // Set up graphics and spriteBatch.
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Declare Player variable.
        Player player;

        // Declare player sprites. - Idle and Movement textures.
        Texture2D lookingDown, lookingUp, lookingLeft, lookingRight, movingDown, movingUp, movingLeft, movingRight;

        #region Item Experimentation.
        // Create item variables.
        Item key1, key2, key3, key4;

        // Create item lists.
        List<Item> room1Items, room2Items;
        #endregion

        #region Room and Door Experimentation.
        Door entranceDoor, exitDoor;

        // Create list of doors for room1 and room 2.
        List<Door> room1Exits, room2Exits;

        Room currentRoom, room1, room2, roomToChange;
        #endregion

        // North Wall test.
        Texture2D northWall;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            #region Set up screen resolution.
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            #endregion

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here        
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            #region Load Player.
            #region Load Idle Player sprites.
            lookingLeft = Content.Load<Texture2D>("Images/Player/Stand Left");
            lookingRight = Content.Load<Texture2D>("Images/Player/Stand Right");
            lookingUp = Content.Load<Texture2D>("Images/Player/Stand Up");
            lookingDown = Content.Load<Texture2D>("Images/Player/Stand Down");
            #endregion

            #region Load Movement Player sprites.
            movingLeft = Content.Load<Texture2D>("Images/Player/Move Left");
            movingRight = Content.Load<Texture2D>("Images/Player/Move Right");
            movingUp = Content.Load<Texture2D>("Images/Player/Move Up");
            movingDown = Content.Load<Texture2D>("Images/Player/Move Down");                     
            #endregion

            // Load animated player sprite.
            player = new Player(
                this, // Game
                lookingDown, // Image
                new Vector2(300, 300), // Position
                Color.White, // Colour
                2); // Frames          

            // Send these textures to the Player class.
            player.GetAnimations(lookingLeft, lookingRight, lookingUp, lookingDown,
                movingLeft, movingRight, movingUp, movingDown);
            #endregion

            // Instantiate lists.
            room1Items = new List<Item>();
            room2Items = new List<Item>();

            room1Exits = new List<Door>();
            room2Exits = new List<Door>();

            #region Item list setup
            // Load items.
            key1 = new Item(Content.Load<Texture2D>("Images/Items/Key 1"),
                new Vector2(400, 600),
                Color.White,
                "Opens red doors.",
                "You found a red key.");

            key2 = new Item(Content.Load<Texture2D>("Images/Items/Key 2"),
                new Vector2(450, 600),
                Color.White,
                "Opens green doors.",
                "You found a green key.");

            key3 = new Item(Content.Load<Texture2D>("Images/Items/Key 3"),
                new Vector2(200, 300),
                Color.White,
                "Opens yellow doors.",
                "You found a yellow key.");

            key4 = new Item(Content.Load<Texture2D>("Images/Items/Key 4"),
                new Vector2(100, 500),
                Color.White,
                "Opens yellow doors.",
                "You found a yellow key.");

            // Add to the item lists for each room.
            room1Items.Add(key1);
            room1Items.Add(key2);

            room2Items.Add(key3);
            room2Items.Add(key4);

            #endregion



            #region Load doors and rooms.
            entranceDoor = new Door(Content.Load<Texture2D>("Images/Doors/Door 1"),
               new Vector2(780, 10),
               Color.White,
               room2,
               true);

            exitDoor = new Door(Content.Load<Texture2D>("Images/Doors/Door 2"),
                new Vector2(780, 650),
                Color.White,
                room1,
                true);          

            // Load Rooms.
            room1 = new Room(Content.Load<Texture2D>("Images/Floors/Wood Flooring"),
                room1Items,
                room1Exits);

            room2 = new Room(Content.Load<Texture2D>("Images/Floors/Wood Flooring"),
                room2Items,
                room2Exits);

            entranceDoor.Destination = room2;
            exitDoor.Destination = room1;

            // Add doors to Door lists.
            room1Exits.Add(entranceDoor);
            room2Exits.Add(exitDoor);

            // Set current room.
            currentRoom = room1;
            #endregion

           // northWall = Content.Load<Texture2D>("Images/Walls/Grey North Brick Wall");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here         
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // Update the player.
            player.Update(gameTime);

            #region Check for door collisions and change room accordingly.
            foreach(Door exit in currentRoom.Exits)
            {
                if(exit.CheckCollision(player) == true)
                {
                    // Change the current room using the entered door's ChangeRoom() method.                                                       
                    currentRoom = exit.ChangeRoom(player);
                    break;           
                }               
            }
            #endregion

            // Update the current room.
            currentRoom.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            

            // Draw the current room.
            currentRoom.Draw(spriteBatch);

            //spriteBatch.Draw(northWall, new Vector2(0, 0), Color.White);

            // Draw the player.
            player.Draw(spriteBatch);

           

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
