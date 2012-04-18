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
    class EnemyDyingState : EnemyState
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public EnemyDyingState(EnemyState state) :
            this(state.Enemy)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public EnemyDyingState(Enemy enemy)
        {
            Enemy = enemy;
            //Enemy.Sprite.PlayAnimation("knockedDown");
            //Enemy.Velocity /= 5.0f; 
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

           // if (Enemy.Sprite.CurrentFrame == Enemy.Sprite.CurrentAnimation.EndFrame)
            //{
                Random random = new Random();
                int rtype = random.Next(0, 2);
                string type;
                int amount = 0;

                if (rtype == 0)
                {
                    switch (Enemy.GetType().ToString())
                    {
                        case "KismetDataTypes.Goblin":
                            amount = 200;
                            break;
                        case "KismetDataTypes.DemonArcher":
                            amount = 200;
                            break;
                        case "KismetDataTypes.FireMage":
                            amount = 500;
                            break;
                        default:
                            Console.WriteLine("Invalid enemy type in Reward Manager");
                            break;
                    }
                    type = "manna";
                    GV.Player.Manna += amount;
                }
                else
                {
                    type = "health";
                    amount = 50;
                    GV.Player.Health += amount;

                }

                RewardManager.AddReward(type, amount, Enemy.Position);
               

                Enemy.IsAlive = false;
            //}
        }
        #endregion
    }
}
