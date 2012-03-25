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
        public override void Update(GameTime gameTime)
        {
            Enemy.Velocity = new Vector2(0.0f, Enemy.Velocity.Y);

            if (enemy.CollisionDetected && (enemy.Sprite.CurrentFrame == 2 || enemy.Sprite.CurrentFrame == 6) && Enemy.GetType().ToString() != "KismetDataTypes.DemonArcher")
            {
                if (!GV.Player.IsHit)
                    GV.Player.IsHit = true;
            }
            //CollisionManager.ResolveCollisions(Enemy);
            if (Enemy.IsHit)
            {
                Enemy.StateMachine.UpdateState("isHit");

            }

            else if (Enemy.Sprite.CurrentFrame == Enemy.Sprite.CurrentAnimation.EndFrame)
            {
                if (Enemy.GetType().ToString() == "KismetDataTypes.DemonArcher")
                {
                    MagicItemManager.CreateMagicItem("arrow", Enemy);
                }
                else if (Enemy.GetType().ToString() == "KismetDataTypes.FireMage")
                {
                    MagicItemManager.CreateMagicItem("fireRow", Enemy);
                }
                else if (Enemy.GetType().ToString() == "KismetDataTypes.MiniBoss")
                {
                    MagicItemManager.CreateMagicItem("egg", Enemy);
                }
                    Enemy.StateMachine.UpdateState("");

                    
            }

        }
        #endregion
    }
}
