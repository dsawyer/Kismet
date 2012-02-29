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
    class FlockPatrolState : EnemyState
    {
        private float time;
        private float angle;
        private float turnaroundtime;
        //private float deviation;
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public FlockPatrolState(EnemyState state) :
            this(state.Enemy)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public FlockPatrolState(Enemy enemy)
        {
            Enemy = enemy;
            //Enemy.Range = 500;
            time = 0.0f;
            angle = 0;
            turnaroundtime = 1.0f;

            if (Enemy.Direction == GV.LEFT)
            {
                Enemy.Velocity = new Vector2(-5, Enemy.Velocity.Y);
            }
            else
            {
                Enemy.Velocity = new Vector2(5, Enemy.Velocity.Y);
            }


        }
        #endregion
        #region Update
       
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime )
        {

               float vely, velx;
            // Process passing time.
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;



            if (time <= turnaroundtime)
            {
                angle = angle % 360.0f;
                float radianAngle = (angle * (float)Math.PI) / 180;
                velx = 5 * radianAngle;
                //y = ASin(k*x)
                vely = 5 * ((float)Math.Sin(velx));
                Enemy.Velocity = new Vector2(Enemy.Velocity.X, vely);

                if (Enemy.Direction == GV.LEFT)
                    angle--;
                else
                    angle++;

            }
            else
            {
                if (Enemy.Direction == GV.LEFT)
                {
                    Enemy.Direction = GV.RIGHT;
                    Enemy.Velocity = new Vector2(5, Enemy.Velocity.Y);
                }
                else
                {
                    Enemy.Direction = GV.LEFT;
                    Enemy.Velocity = new Vector2(-5, Enemy.Velocity.Y);
                }
                time = 0.0f;
                angle = 0;
                turnaroundtime = 2.0f;
                //Enemy.State = new FlockPatrolState(Enemy);
            }

        }
        #endregion
    }
}
