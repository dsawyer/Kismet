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
    class PatrolState : EnemyState
    {
        private float time;
        //private float deviation;
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public PatrolState(EnemyState state) :
             this(state.Enemy)
        {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public PatrolState(Enemy enemy)
        {
            Enemy = enemy;
            Enemy.Range = 0;
            time = 0.0f;
            Enemy.Sprite.PlayAnimation("walking");


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

            if (time <= 5.0f)
            {
                if (Enemy.Direction == GV.LEFT)
                    Enemy.Velocity = new Vector2(-2, Enemy.Velocity.Y);
                else if (Enemy.Direction == GV.RIGHT)
                    Enemy.Velocity = new Vector2(2, Enemy.Velocity.Y);

                //CollisionManager.ResolveCollisions(Enemy);
                if (Enemy.IsHit)
                {
                    Enemy.StateMachine.UpdateState("isHit");

                }
                else if (Enemy.SightDetected)
                {
                    if (Enemy.JumpVelocity.Y < -32)
                        Enemy.StateMachine.UpdateState("jump");
                    else
                        Enemy.StateMachine.UpdateState("insight");

                }
            }
            else
            {
                time = 0.0f;
                Enemy.ToggleDirections();
            }

         }
        #endregion
    }
}
