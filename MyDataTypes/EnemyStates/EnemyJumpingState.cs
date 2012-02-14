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
    class EnemyJumpingState : EnemyState
    {
        #region Properties
        /// <summary>
        /// Constants 
        /// </summary>
        private const float JUMPVELOCITY = -20.0f;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructors
        /// </summary>
        /// <param name="state"></param>
        public EnemyJumpingState(EnemyState state) :
            this(state.Enemy)
        { }

        public EnemyJumpingState(Enemy enemy)
        {
            Enemy = enemy;
            Enemy.Sprite.PlayAnimation("jumping");

            Enemy.JumpVelocity = new Vector2(0, 0);
            //Player.Velocity = new Vector2(Player.Velocity.X, -(Math.Abs(Player.AnalogState)) +JUMPVELOCITY);
            if (Enemy.Direction == GV.LEFT)
                Enemy.Velocity = new Vector2(-5, -20);
            else if (Enemy.Direction == GV.RIGHT)
                Enemy.Velocity = new Vector2(5, -20);
           
            Enemy.IsOnGround = false;
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //if (Enemy.Direction == GV.LEFT)
               // Enemy.Velocity = new Vector2(, Enemy.Velocity.Y);
            //else if (Enemy.Direction == GV.RIGHT)
            //    Enemy.Velocity = new Vector2(0, Enemy.Velocity.Y);
            //CollisionManager.ResolveCollisions(Enemy);
            if (Enemy.IsHit)
            {
                Enemy.StateMachine.UpdateState("isHit");

            }
           //CollisionManager.ResolveEnemyCollisions(enemy, Enemy.EnemyBounds);
            if (Enemy.Sprite.CurrentFrame == Enemy.Sprite.CurrentAnimation.EndFrame)
            {
                if (Enemy.IsOnGround)
                {
                    Enemy.Velocity = new Vector2(0, 0);
                    Enemy.StateMachine.UpdateState("");
                }
            }


        }
        #endregion
    }
}
