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
        private float time = 0;
        int randomNumber;
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
            if(Enemy.GetType().ToString() == "KismetDataTypes.Goblin")
            {
                Enemy.Range = 50;
            }
            else if(Enemy.GetType().ToString() == "KismetDataTypes.FireMage")
            {
                 Enemy.Range = 200;
            }
            else if(Enemy.GetType().ToString() == "KismetDataTypes.DemonAracher")
            {
                     Enemy.Range = 500;
            }

            //Enemy.Range = 50;
            Random random = new Random();
            randomNumber = random.Next(3, 10);
           

           
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
             if (Enemy.Direction == GV.LEFT)
                Enemy.Velocity = new Vector2(-randomNumber, Enemy.Velocity.Y);
            else if (Enemy.Direction == GV.RIGHT)
                Enemy.Velocity = new Vector2(randomNumber, Enemy.Velocity.Y);

            //CollisionManager.ResolveCollisions(Enemy);
            if (Enemy.IsHit)
            {
                Enemy.StateMachine.UpdateState("isHit");

            }
            else if (Enemy.CollisionDetected)
            {
                Enemy.StateMachine.UpdateState("collision");

            }

            else if (Enemy.Sprite.CurrentFrame == Enemy.Sprite.CurrentAnimation.EndFrame)
            {
           
                Enemy.StateMachine.UpdateState("noCollision");

            }
           
        }
        #endregion
    }
}
