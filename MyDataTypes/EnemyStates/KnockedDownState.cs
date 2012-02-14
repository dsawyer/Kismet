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
    class KnockedDownState : EnemyState
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public KnockedDownState(EnemyState state) :
            this(state.Enemy)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public KnockedDownState(Enemy enemy)
        {
            Enemy = enemy;
            Enemy.Sprite.PlayAnimation("knockedDown");

            if (Enemy.Direction == "left" && Enemy.BackStabber)
            {
                Enemy.Velocity = new Vector2(-2, -10);
                Enemy.ToggleDirections();
            }
            else if (Enemy.Direction == "right" && Enemy.BackStabber)
            {
                Enemy.Velocity = new Vector2(2, -10);
                Enemy.ToggleDirections();
            }
            else if (Enemy.Direction == "left" && Enemy.FaceOff)
            {
                Enemy.Velocity = new Vector2(2, -10);
            }
            else if (Enemy.Direction == "right" && Enemy.FaceOff)
            {
                Enemy.Velocity = new Vector2(-2, -10);
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //CollisionManager.ResolveCollisions(Enemy);
            if (Enemy.Sprite.CurrentFrame == Enemy.Sprite.CurrentAnimation.EndFrame)
            {
                Enemy.IsHit = false;
                    Enemy.StateMachine.UpdateState(""); 
            }
        }
        #endregion
    }
}