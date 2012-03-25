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
    class LightState : PlayerState
    {
        float time;
        // Constructor
        public LightState(PlayerState state) :
            this(state.Player)
        {

        }
        public LightState(Player player)
        {
            Player = player;
            //Player.Velocity = new Vector2(0, 0);
        }

        public override void Update(GameTime gameTime)
        {
            
            MagicItemManager.CreateMagicItem("light", null);
            //MagicItem magicItem = new MagicItem(Player, "fire");
            Player.State = new IdleState(this);
             
           
        }


    }
}
