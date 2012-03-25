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
    class EggState : MagicState
    {
        float time;
        int randomNumber,randomx,randomy;

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public EggState(MagicState state) :
            this(state.MagicItem)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public EggState(MagicItem magicItem)
        {
            Random random = new Random();
            randomx = random.Next(10, 30);
            randomy = random.Next(10, 20);

            MagicItem = magicItem;
            MagicItem.Sprite.PlayAnimation("light");
            MagicItem.IsOnGround = false;
            //CollisionManager.ResolveEnemyCollisions(enemy, Enemy.EnemyBounds);
            if (MagicItem.Enemy.Direction == "left")
                MagicItem.Velocity = new Vector2(-randomx, -randomy);
            else if (MagicItem.Enemy.Direction == "right")
                MagicItem.Velocity = new Vector2(randomx, -randomy);

        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (MagicItem.IsOnGround)
            {
                Random random = new Random();
                randomNumber = random.Next(0, 3);
                //MagicItem.State = new InUseState(this);
                MagicItem.Active = false;
                if (randomNumber >= 1)
                    NPCManager.SpawnObject("goblin", MagicItem.Position);
                else
                    NPCManager.SpawnObject("fireMage", MagicItem.Position);

            }

           //MagicItem.Velocity = new Vector2(MagicItem.Velocity.X, MagicItem.Velocity.Y);
        }
        #endregion
    }
}
