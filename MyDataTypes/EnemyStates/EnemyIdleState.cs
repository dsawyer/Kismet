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
        float time;
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
            Enemy.Velocity = new Vector2(0, Enemy.Velocity.Y);
            time = 0;
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            Enemy.Velocity = new Vector2(0, Enemy.Velocity.Y);
            if (Enemy.GetType().ToString() == "KismetDataTypes.MiniBoss")
            {
                time += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (time > 2.0f)
                {
                    Enemy.StateMachine.UpdateState("teleport");
                }


            }


            if (Enemy.IsHit)
            {
                Enemy.StateMachine.UpdateState("isHit");

            }
            else if (Enemy.SightDetected)
            {
                Enemy.StateMachine.UpdateState("insight");

            }
            else if (Enemy.CollisionDetected)
            {
                Enemy.StateMachine.UpdateState("collision");

            }
        }
        #endregion
    }
}
