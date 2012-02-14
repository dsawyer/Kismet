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
    class TeleportState : EnemyState
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public TeleportState(EnemyState state) :
            this(state.Enemy)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public TeleportState(Enemy enemy)
        {
            Enemy = enemy;
            Enemy.Sprite.PlayAnimation("teleport1");
            //CollisionManager.ResolveCollisions(Enemy);

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


            if (Enemy.Sprite.CurrentFrame == Enemy.Sprite.CurrentAnimation.EndFrame && Enemy.Sprite.CurrentAnimation.Name == "teleport1")
            {

                Enemy.PositionInTile(new Vector2 (15.0f, 13.0f));
                Enemy.Sprite.PlayAnimation("teleport2");
            }
            if (Enemy.Sprite.CurrentFrame == Enemy.Sprite.CurrentAnimation.EndFrame && Enemy.Sprite.CurrentAnimation.Name == "teleport2")
            {
                Enemy.StateMachine.UpdateState("");
            }
        }
        #endregion
    }
}
