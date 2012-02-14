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
            //Player.Velocity = new Vector2(Player.Velocity.X, -(Math.Abs(Player.AnalogState)) +JUMPVELOCITY);
            Enemy.Velocity = new Vector2(Enemy.Velocity.X, JUMPVELOCITY);
            //Enemy.IsOnGround = false;
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

            //CollisionManager.ResolveEnemyCollisions(enemy, Enemy.EnemyBounds);

            /*if (Enemy.IsOnGround)
            {
                Enemy.State = new PatrolState(this);

            }*/
           


        }
        #endregion
    }
}
