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
    class LittleHitState : EnemyState
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public LittleHitState(EnemyState state) :
            this(state.Enemy)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public LittleHitState(Enemy enemy)
        {
            Enemy = enemy;
            Enemy.Sprite.PlayAnimation("littleHit");
            Enemy.Velocity = new Vector2(0, 0);
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (Enemy.Sprite.CurrentFrame == Enemy.Sprite.CurrentAnimation.EndFrame)
            {
                //if player is got hit
                if (keyboardState.IsKeyDown(Keys.Z))
                {
                    Enemy.State = new EnemyJumpingState(this);
                }
                else
                    Enemy.State = new PatrolState(this);
            }
        }
        #endregion
    }
}