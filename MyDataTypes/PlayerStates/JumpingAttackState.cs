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
    class JumpingAttackState : PlayerState
    {


        // Constructor
        public JumpingAttackState(PlayerState state) :
            this(state.Player)
        {

        }
        public JumpingAttackState(Player player)
        {
            this.Player = player;
            this.Player.Sprite.PlayAnimation("jumpingAttack");
        }

        public override void Update(GameTime gameTime)
        {
            Player.Velocity = new Vector2(Player.AnalogState, Player.Velocity.Y);
            if (Player.IsOnGround)
                Player.State = new IdleState(this);

            //else 
            //Player.Velocity = new Vector2(Player.AnalogState, Player.Velocity.Y + GV.GRAVITY);
        }



    }
}
