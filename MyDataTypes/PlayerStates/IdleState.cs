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
            Player.MaxLightRadius = 0;
            Player.Rate = 0;
        }
        #endregion

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            Player.Rate = 0;
            Player.UpdateRadius();
            if (Player.IsHit)
            {
                Player.State = new HittingState(this);

            }
            // if player is attacking
            else if (keyboardState.IsKeyDown(Keys.S) || gamePadState.IsButtonDown(Buttons.X))
            {
                Player.State = new Attack1State(this);
            }
            else if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.Left) ||
                     gamePadState.IsButtonDown(Buttons.DPadRight) || gamePadState.IsButtonDown(Buttons.DPadLeft) ||
                     gamePadState.IsButtonDown(Buttons.LeftThumbstickRight) || gamePadState.IsButtonDown(Buttons.LeftThumbstickLeft))
            {
                Player.State = new WalkingState(this);
            }
           
           
            else if (keyboardState.IsKeyDown(Keys.D) || gamePadState.IsButtonDown(Buttons.B))
            {
                if (Player.CheckInventory())
                {
                    Player.State = new MagicAttackState(this);
                }
            }

           
                //if player is jumping
            else if ((keyboardState.IsKeyDown(Keys.A) || gamePadState.IsButtonDown(Buttons.A) )&& GV.Player.IsOnGround)
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
