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
    public class HubManager
    {
        public Sprite activeMagic;
        public string currentMagic;
        public Texture2D texture;
        SpriteFont Font1;
        Vector2 FontPos;
         /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player"></param>
        public HubManager()
        {
            activeMagic = new Sprite(GV.ContentManager, "XML Documents/PickUpItemsAnimations");
            activeMagic.Position = new Vector2(Camera.Position.X + 100, Camera.Position.Y + 100);
            activeMagic.Scale = 0.5f;
            activeMagic.PlayAnimation("pickupFire");
            currentMagic = "fire";
            texture = GV.ContentManager.Load<Texture2D>("Sprites/greenPixel");

            Font1 = GV.ContentManager.Load<SpriteFont>("SpriteFont1");         

        }

        public  void ChangeMagicItem(string item)
        {
            
            switch (item)
            {
                case "fire":
                    activeMagic.PlayAnimation("pickupFire");
                    break;
                case "water":
                    activeMagic.PlayAnimation("pickupWater");
                    break;
                case "wind":
                    activeMagic.PlayAnimation("pickupWind");
                    break;
                case "earth":
                    activeMagic.PlayAnimation("pickupEarth");
                    break;
                case "dark":
                    activeMagic.PlayAnimation("pickupDark");
                    break;
                case "light":
                    break;
                default:
                    Console.WriteLine("Invalid selection in Hub Manager");
                    break;
            }
        }
        public void Update(GameTime gameTime)
        {

            activeMagic.Position = new Vector2( 100, 70);
            if (currentMagic != GV.Player.CurrentMagicItem)
            {
                ChangeMagicItem(GV.Player.CurrentMagicItem);
                currentMagic = GV.Player.CurrentMagicItem;
            }
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            activeMagic.Draw(gameTime, spriteBatch);


            Vector2 FontOrigin = Font1.MeasureString("" + GV.Player.CurrentMagicCount) / 2;
        // Draw the string
            spriteBatch.DrawString(Font1, "" + GV.Player.CurrentMagicCount, new Vector2( 50, 90), Color.BlueViolet, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

            Rectangle positionBox = new Rectangle((int)100, (int)+10, GV.Player.Health, 20);
            BoundingBox boundBox = new BoundingBox();
            spriteBatch.Draw(texture, new Rectangle(positionBox.Left, positionBox.Top, positionBox.Width, 20), Color.Yellow);
            boundBox.Draw(spriteBatch, positionBox, Color.Blue);
        }

    }
}
