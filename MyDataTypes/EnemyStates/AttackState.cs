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
    class AttackState : EnemyState
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public AttackState(EnemyState state) :
            this(state.Enemy)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public AttackState(Enemy enemy)
        {
            Enemy = enemy;
            Enemy.Sprite.PlayAnimation("attack1");
            //CollisionManager.ResolveCollisions(Enemy);


            if (Enemy.IsHit)
            {
                Enemy.StateMachine.UpdateState("isHit");

            }
           
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update()
        {
            Enemy.Velocity = new Vector2(0.0f, Enemy.Velocity.Y);

            if (enemy.CollisionDetected && enemy.GetType().ToString() != "KismetDataTypes.DemonArcher")
            {
                GV.Player.IsHit = true;
            }
            //CollisionManager.ResolveCollisions(Enemy);
            if (Enemy.IsHit)
            {
                Enemy.StateMachine.UpdateState("isHit");

            }

            if (Enemy.Sprite.CurrentFrame == Enemy.Sprite.CurrentAnimation.EndFrame)
            {
                if (Enemy.GetType().ToString() == "KismetDataTypes.DemonArcher")
                {
                    MagicItemManager.CreateMagicItem("arrow", Enemy);
                }
                    Enemy.StateMachine.UpdateState("");

                    
            }

        }
        #endregion
    }
}
