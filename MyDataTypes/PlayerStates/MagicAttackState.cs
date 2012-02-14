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
    class MagicAttackState : PlayerState
    {
        // Constructor
        public MagicAttackState(PlayerState state) :
            this(state.Player)
        {

        }
        public MagicAttackState(Player player)
        {   
            Player = player;
            Player.Sprite.PlayAnimation("magicAttack");
            Player.Velocity = new Vector2(0, 0);
        }

        public override void Update(GameTime gameTime)
        {

            if (Player.Sprite.CurrentFrame == Player.Sprite.CurrentAnimation.EndFrame)
            {
                KeyboardState keyboardState = Keyboard.GetState();
                MagicItemManager.CreateMagicItem(Player.CurrentMagicItem, null);
                //MagicItem magicItem = new MagicItem(Player, "fire");
                Player.State = new IdleState(this);
            }
        }


    }
}
