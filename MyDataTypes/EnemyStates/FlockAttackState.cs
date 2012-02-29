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
    class FlockAttackState : EnemyState
    {
        private float time;
        private float angle;
        private Vector2 returnPosition;
        //private float deviation;
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public FlockAttackState(EnemyState state) :
            this(state.Enemy)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public FlockAttackState(Enemy enemy)
        {
            Enemy = enemy;
            time = 0.0f;
            returnPosition = Enemy.Position;
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

           // if (time <=1.0f)
            //{

                Vector2 playersPosition = GV.Player.Position;
                Enemy.Velocity = (playersPosition - Enemy.Position)/40;
                //Enemy.Velocity = new Vector2(0.0f,1.0f);
                //Enemy.Velocity = new Vector2(0.0f,0.0f);
               // if (!Enemy.SightDetected)
              // {
                //   Enemy.State = new FlockPatrolState(this);
               //}
            //}
            //else
            //{
                //Enemy.Velocity = (GV.Player.Position.X - Enemy.Position) / 40;
                //Enemy.Velocity = new Vector2(0, -5);

            //}

           

        }
        #endregion
    }
}
