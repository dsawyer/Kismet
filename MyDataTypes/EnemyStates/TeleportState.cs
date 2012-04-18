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
        static int currentposition = 0;
        Vector2[] TeleportMap = new Vector2[]
        {
            new Vector2(34.0f, 11.0f),
            new Vector2(6.0f, 14.0f),
            new Vector2(16.0f, 12.0f),
            new Vector2(25.0f, 11.0f)
        };
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
        public override void Update(GameTime gameTime)
        {
            Enemy.Velocity = new Vector2(0.0f, Enemy.Velocity.Y);


            if (Enemy.Sprite.CurrentFrame == Enemy.Sprite.CurrentAnimation.EndFrame && Enemy.Sprite.CurrentAnimation.Name == "teleport1")
            {
                /*if (GV.Player.IsOnGround)
                {
                    float xPos = (int)Math.Floor((float)GV.Player.Position.X / Layer.TileWidth);
                    float yPos = (int)Math.Floor((float)GV.Player.Position.Y / Layer.TileHeight-1);
                    //Enemy.PositionInTile(new Vector2(xPos, yPos));
                }
                else
                {*/
                    Random random = new Random();
                    int randnum;
                    do
                    {
                       randnum = random.Next(0, 3);
                    }while (randnum == currentposition);
                    currentposition = randnum;
                    Enemy.PositionInTile(TeleportMap[randnum]);
                //}

                
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
