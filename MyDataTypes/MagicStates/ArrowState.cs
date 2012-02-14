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
    class ArrowState : MagicState
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public ArrowState(MagicState state) :
            this(state.MagicItem)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public ArrowState(MagicItem magicItem)
        {
            MagicItem = magicItem;
            MagicItem.Sprite.PlayAnimation("arrow");

            //CollisionManager.ResolveEnemyCollisions(enemy, Enemy.EnemyBounds);
            if (MagicItem.Enemy.Direction == "left")
                MagicItem.Velocity = new Vector2(-10, 0);
            else if (MagicItem.Enemy.Direction == "right")
                MagicItem.Velocity = new Vector2(10, 0);
            //MagicItem.Velocity = new Vector2(2, 10);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update()
        {


            MagicItem.Velocity = new Vector2(MagicItem.Velocity.X, MagicItem.Velocity.Y - GV.GRAVITY);
        }
        #endregion
    }
}
