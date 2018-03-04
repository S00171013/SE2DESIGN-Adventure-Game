using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignment_Adventure_Game
{
    class Item: SimpleSprite
    {
        // Properties
        public string Description { get; set; }
        public string ExamineInfo { get; set; }

        // Constructor.
        public Item(Texture2D image, Vector2 position, Color tint, string descIn, string exInfoIn) : base(image, position, tint)
        {
            Description = descIn;
            ExamineInfo = exInfoIn;

            // Set bounds.
            Bounds = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
        }

        public virtual void Update(GameTime gtIn)
        {
           
        }        
    }
}
