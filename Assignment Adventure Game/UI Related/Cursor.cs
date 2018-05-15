using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_Adventure_Game
{
    class Cursor
    {
        protected Game myGame;

        private float angle = 0;
        public int selectCounter = 0;

        // Cursor properties.
        public Texture2D Texture { get; }
        public Vector2 Position { get; set; }
        public Rectangle BoundingRectangle { get; set; }
        public SoundEffect NavigateSound { get; }
        

        public Cursor(Game1 gameIn, Texture2D textureIn, Vector2 positionIn, SoundEffect navigateSoundIn)
        {
            myGame = gameIn;
            Texture = textureIn;
            Position = positionIn;
            NavigateSound = navigateSoundIn;

            BoundingRectangle = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);           
        } 

        public void Update(MenuOption[] optionsIn)
        {
            // Continuously rotate the icon. This helps to make the UI seem less static.
            angle += 0.09f;

            #region Selection testing.            

            if (InputManager.IsKeyPressed(Keys.Down) || InputManager.IsKeyPressed(Keys.S))
            {
                MoveDown(optionsIn);
            }

            else if (InputManager.IsKeyPressed(Keys.Up) || InputManager.IsKeyPressed(Keys.W))
            {
                MoveUp(optionsIn);
            }
            #endregion
        }

        public void Draw(SpriteBatch spIn)
        {
            spIn.Draw(Texture, Position, null,
                 Color.White, angle, new Vector2(Texture.Width/2, Texture.Height/2), 1f, SpriteEffects.None, 1);
        }

        private void MoveDown(MenuOption[] optionsIn)
        {
            // Increase the selection counter.
            selectCounter++;

            // Send "false" to the previously selected option so that it can determine that it is no longer highlighted.           
            optionsIn[selectCounter - 1].GetHighlightedStatus(false);

            #region Ensure the cursor will cycle from the bottom option back to the top option.
            if (selectCounter == optionsIn.Length)
            {
                // Reset the counter to 0.
                selectCounter = 0;
            }
            #endregion           

            // Send "true" to the currently selected option so that it can determine that it is now highlighted.  
            optionsIn[selectCounter].GetHighlightedStatus(true);

            Position = Vector2.Lerp(Position, new Vector2(optionsIn[selectCounter].Position.X - 30, optionsIn[selectCounter].Position.Y + 30), 1f);

            // Play navigation sound effect.
            NavigateSound.Play();
        }

        private void MoveUp(MenuOption[] optionsIn)
        {
            // Decrease the selection counter.
            selectCounter--;

            // Send "false" to the previously selected option so that it can determine that it is no longer highlighted.
            optionsIn[selectCounter + 1].GetHighlightedStatus(false);

            #region Ensure the arrow will cycle from the first box back to the last box.
            if (selectCounter == -1)
            {
                // Reset the counter to the highest option index.
                selectCounter = optionsIn.Length - 1;
            }
            #endregion

            // Send "true" to the currently selected option so that it can determine that it is now highlighted.
            optionsIn[selectCounter].GetHighlightedStatus(true);

            Position = Vector2.Lerp(Position, new Vector2(optionsIn[selectCounter].Position.X - 30, optionsIn[selectCounter].Position.Y + 30), 1f);

            NavigateSound.Play();
        }
    }
}
