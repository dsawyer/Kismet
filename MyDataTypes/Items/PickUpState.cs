using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace KismetDataTypes
{
    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    public abstract class PickUpState
    {
        protected PickUpItem pickUpItem;
        protected Sprite sprite;

        // Properties
        public PickUpItem PickUpItem
        {
            get { return pickUpItem; }
            set { pickUpItem = value; }
        }

        // Properties
        public Sprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        public abstract void Update();
    }


}
