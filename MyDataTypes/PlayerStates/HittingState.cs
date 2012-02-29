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

namespace KismetDataTypes
{
    class HittingState : PlayerState
    {
        // Constructor
        public HittingState(PlayerState state) :
            this(state.Player)
        {

        }
        public HittingState(Player player)
        {

            this.Player = player;
            this.Player.Sprite.PlayAnimation("hitting");
            if (Player.Direction == "left")
                Player.Velocity = new Vector2(5,Player.Velocity.Y);
            else if (Player.Direction == "right")
                Player.Velocity = new Vector2(-5, Player.Velocity.Y);

        }

        public override void Update(GameTime gameTime)
        {

            KeyboardState keyboardState = Keyboard.GetState();

            if (Player.Direction == "left")
                Player.Velocity = new Vector2(0, Player.Velocity.Y);
            else if (Player.Direction == "right")
                Player.Velocity = new Vector2(0, Player.Velocity.Y);

            if (keyboardState.IsKeyDown(Keys.S))
            {
                //Player.IsHit = false;
                Player.State = new Attack1State(this);
            }
            else if (keyboardState.IsKeyDown(Keys.A) && Player.IsOnGround )
            {
                Player.IsHit = false;
                Player.State = new JumpingState(this);
            }
            if (this.Player.Sprite.CurrentFrame == this.Player.Sprite.CurrentAnimation.EndFrame)
            {
                Player.IsHit = false;
                //Console.WriteLine("got hit");
                if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.Left))
                {
                    //Player.State = new WalkingState(this);
                }
                else if (keyboardState.IsKeyDown(Keys.S))
                {
                    //Player.State = new Attack1State(this);
                }
                else if (keyboardState.IsKeyDown(Keys.A))
                {
                   // Player.State = new JumpingState(this);
                }

                //else
                //{
                    Player.State = new IdleState(this);
                //}
            }
        }


    }
}
