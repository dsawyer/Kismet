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
    class Attack1State: PlayerState
    {
         // Constructor
        public Attack1State(PlayerState state) :
             this(state.Player)
        {
          
        }
        public Attack1State(Player player)
        {
 
            Player = player;
            Player.Sprite.PlayAnimation("attack");
            Player.Velocity = new Vector2(0, 0);
          
        }

        public override void Update()
        {
            
            if (Player.Sprite.CurrentFrame == Player.Sprite.CurrentAnimation.EndFrame)
            {
                KeyboardState keyboardState = Keyboard.GetState();

                //is there movement not movement on the thumbstick
                if (Player.IdleCheck())
                    Player.State = new IdleState(this);
                else if (keyboardState.IsKeyDown(Keys.S))
                    Player.State = new Attack1State(this);
                else if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.Right))
                    Player.State = new WalkingState(this);
            }

            //Player.Velocity = new Vector2(0.0f, Player.Velocity.Y + GV.GRAVITY);
        }


    }
}
