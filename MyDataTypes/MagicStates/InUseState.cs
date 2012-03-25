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
    class InUseState : MagicState
    {
        private float time= 0;

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public InUseState(MagicState state) :
            this(state.MagicItem)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public InUseState(MagicItem magicItem)
        {
            MagicItem = magicItem;
            MagicItem.Sprite.PlayAnimation(MagicItem.ItemType);

            //CollisionManager.ResolveEnemyCollisions(enemy, Enemy.EnemyBounds);
            
            //MagicItem.Velocity = new Vector2(2, 10);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            // Process passing time.
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (time < 6.0)
            {
                if (MagicItem.ItemType == "wind")
                {
                    MagicItem.Velocity = new Vector2(GV.Player.Velocity.X,-2);

                }
                else
                    MagicItem.Velocity = new Vector2(0, MagicItem.Velocity.Y);

                if (MagicItem.Sprite.CurrentFrame == MagicItem.Sprite.CurrentAnimation.EndFrame)
                {
                    if (MagicItem.Owner != "enemy" && MagicItem.ItemType != "earth")
                    {
                        MagicItem.Active = false;
                    }
                    else
                    {
                        MagicItem.Sprite.CurrentFrame = MagicItem.Sprite.CurrentAnimation.EndFrame;

                    }
                }

                if(MagicItem.ItemType != "light")
                GV.Player.Manna = 0;
           }
            else
                MagicItem.Active = false;

        }
        #endregion
    }
}
