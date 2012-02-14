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
    class InAirState : MagicState
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public InAirState(MagicState state) :
            this(state.MagicItem)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public InAirState(MagicItem magicItem)
        {
            MagicItem = magicItem;
            MagicItem.Sprite.PlayAnimation("base");
            
            //CollisionManager.ResolveEnemyCollisions(enemy, Enemy.EnemyBounds);
            if (GV.Player.Direction == "left")
                MagicItem.Velocity = new Vector2(-10, -20);
            else if (GV.Player.Direction == "right")
                MagicItem.Velocity = new Vector2(10, -20);
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
//if (MagicItem.Sprite.CurrentFrame == MagicItem.Sprite.CurrentAnimation.EndFrame)
            if (MagicItem.IsOnGround)
            {

                MagicItem.State = new InUseState(this);

            }
            //MagicItem.Velocity = new Vector2(MagicItem.Velocity.X, MagicItem.Velocity.Y + GV.GRAVITY);
        }
        #endregion
    }
}
