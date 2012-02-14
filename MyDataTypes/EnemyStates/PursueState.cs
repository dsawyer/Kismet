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
    class PursueState : EnemyState
    {
        //private float deviation;
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public PursueState(EnemyState state) :
            this(state.Enemy)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public PursueState(Enemy enemy)
        {
            Enemy = enemy;
            Enemy.Range = 50;


           
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update()
        {
            if (Enemy.Direction == GV.LEFT)
                Enemy.Velocity = new Vector2(-5, Enemy.Velocity.Y);
            else if (Enemy.Direction == GV.RIGHT)
                Enemy.Velocity = new Vector2(5, Enemy.Velocity.Y);

            //CollisionManager.ResolveCollisions(Enemy);
            if (Enemy.IsHit)
            {
                Enemy.StateMachine.UpdateState("isHit");

            }
            else if (Enemy.CollisionDetected)
            {
                Enemy.StateMachine.UpdateState("collision");

            }
            if (Enemy.Sprite.CurrentFrame == Enemy.Sprite.CurrentAnimation.EndFrame)
            {
           
                Enemy.StateMachine.UpdateState("noCollision");

            }
           
        }
        #endregion
    }
}
