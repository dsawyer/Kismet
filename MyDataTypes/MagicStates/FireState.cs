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
    class FireState : MagicState
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public FireState(MagicState state) :
            this(state.MagicItem)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public FireState(MagicItem magicItem)
        {
            MagicItem = magicItem;
            MagicItem.Sprite.PlayAnimation("fireRow");

            //CollisionManager.ResolveEnemyCollisions(enemy, Enemy.EnemyBounds);
            if (MagicItem.Enemy.Direction == "left")
                MagicItem.Velocity = new Vector2(0, 0);
            else if (MagicItem.Enemy.Direction == "right")
                MagicItem.Velocity = new Vector2(0, 0);
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
            if (MagicItem.Sprite.CurrentFrame == MagicItem.Sprite.CurrentAnimation.EndFrame)
            {
                MagicItem.Active = false;
            }
            MagicItem.Velocity = new Vector2(MagicItem.Velocity.X, MagicItem.Velocity.Y);
        }
        #endregion
    }
}
