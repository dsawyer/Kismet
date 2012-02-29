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
    class EnemyIdleState : EnemyState
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public EnemyIdleState(EnemyState state) :
            this(state.Enemy)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public EnemyIdleState(Enemy enemy)
        {
            Enemy = enemy;
            //Enemy.Range = 500;
            Enemy.Sprite.PlayAnimation("idle");
            Enemy.Velocity = new Vector2(0, 0);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (Enemy.IsHit)
            {
                Enemy.StateMachine.UpdateState("isHit");

            }
            else if (Enemy.CollisionDetected)
            {
                Enemy.StateMachine.UpdateState("collision");

            }
        }
        #endregion
    }
}
