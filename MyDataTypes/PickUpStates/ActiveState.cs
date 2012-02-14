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
    class ActiveState : PickUpState
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public ActiveState(PickUpState state) :
            this(state.PickUpItem)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public ActiveState(PickUpItem pickUpItem)
        {
            PickUpItem = pickUpItem;
            PickUpItem.Sprite.PlayAnimation(PickUpItem.ItemType);
            PickUpItem.Velocity = new Vector2(0, 0);
           
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update()
        {
            if (PickUpItem.Sprite.CurrentFrame == PickUpItem.Sprite.CurrentAnimation.EndFrame)
            //if (PickUpItem.IsOnGround)
            {

                //PickUpItem.State = new InActiveState(this);

            }
            //MagicItem.Velocity = new Vector2(MagicItem.Velocity.X, MagicItem.Velocity.Y + GV.GRAVITY);
        }
        #endregion
    }
}
