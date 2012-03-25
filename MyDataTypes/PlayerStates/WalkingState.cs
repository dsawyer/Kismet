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
    class WalkingState : PlayerState
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public WalkingState(PlayerState state)
        {
          this.player = state.Player;
          Player.Sprite.PlayAnimation("walking");
          Player.MaxLightRadius = 150;
         
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
            
            //is there movement not movement on the thumbstick
            if (Player.IdleCheck())
                Player.State = new IdleState(this);

            else if (Player.IsHit)
            {
                Player.State = new HittingState(this);
            }


            //if player is jumping
            else if ((keyboardState.IsKeyDown(Keys.A) || gamePadState.IsButtonDown(Buttons.A)) && GV.Player.IsOnGround)
            {

                Player.State = new JumpingState(this.Player);
            }

             // if player is attacking
            else if (keyboardState.IsKeyDown(Keys.S) || gamePadState.IsButtonDown(Buttons.X))
            {
                Player.State = new Attack1State(this);
            }
            
            else
            {
                Player.Rate = 5;
                Player.UpdateRadius();
                Player.Velocity = new Vector2(Player.AnalogState, Player.Velocity.Y);
            }

        }
        #endregion
    }
}
