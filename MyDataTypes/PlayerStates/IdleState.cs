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
    class IdleState : PlayerState
    {
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public IdleState(PlayerState state) :
             this(state.Player)
        {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public IdleState(Player player)
        {
            Player = player;
            Player.Sprite.PlayAnimation("idle");
            //Player.Velocity = new Vector2(0, GV.GRAVITY);
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

            if (Player.IsHit)
            {
                Player.State = new HittingState(this);

            }
            else if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.Left))
            {
                Player.State = new WalkingState(this);
            }
           
            // if player is attacking
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                Player.State = new Attack1State(this);
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                Player.State = new MagicAttackState(this);
            }
                //if player is jumping
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                Player.State = new JumpingState(this.Player);
            }
  
            //else
            //this updates the player velocity
                //Player.Velocity = new Vector2(Player.AnalogState, Player.Velocity.Y + GV.GRAVITY);
        }
        #endregion
    }
}
