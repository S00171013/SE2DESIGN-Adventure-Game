using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignment_Adventure_Game
{
    class Weapon : Item
    {
        // Properties.
        public int AmmoCapacity { get; set; }
        public int Ammunition { get; set; }

        // Constructor.
        public Weapon(Texture2D image, Vector2 position, Color tint, string descIn, string exInfoIn,
            int ammoCapacityIn)
            : base(image, position, tint, descIn, exInfoIn)
        {
            // Set bounds.
            Bounds = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
        }

        public virtual new void Update(GameTime gtIn)
        {

        }

    }
}

