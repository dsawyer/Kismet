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
    class JumpingState : PlayerState
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
        public JumpingState(PlayerState state):
            this(state.Player)
        {}

        public JumpingState(Player player)
        {
            Player = player;
            Player.Sprite.PlayAnimation("jumping");
            //Player.Velocity = new Vector2(Player.Velocity.X, -(Math.Abs(Player.AnalogState)) +JUMPVELOCITY);
            Player.Velocity = new Vector2(Player.Velocity.X, JUMPVELOCITY);
            Player.IsOnGround = false;
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

            if (Player.IsHit)
            {
                
                Player.State = new HittingState(this);
            }
            if (Player.IsOnGround)
            {
                Player.MaxLightRadius = 200;
                Player.Rate = 200;
                Player.UpdateRadius();
                if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.Left) ||
                     gamePadState.IsButtonDown(Buttons.DPadRight) || gamePadState.IsButtonDown(Buttons.DPadLeft) ||
                     gamePadState.IsButtonDown(Buttons.LeftThumbstickRight) || gamePadState.IsButtonDown(Buttons.LeftThumbstickLeft))
                    Player.State = new WalkingState(this);
                else 
                    Player.State = new IdleState(this);
                
            }

            //is there movement not movement on the thumbstick
            else if (keyboardState.IsKeyDown(Keys.S) || gamePadState.IsButtonDown(Buttons.X))
            {
                Player.State = new JumpingAttackState(this);
            }


            else
            {
                Player.Rate = 0; 
                Player.UpdateRadius();
                Player.Velocity = new Vector2(Player.AnalogState, Player.Velocity.Y);
            }
          

        }
        #endregion
    }
}
