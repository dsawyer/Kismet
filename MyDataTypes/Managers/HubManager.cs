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
        public int minMannaNeeded = 200;
        public Texture2D texture1;
        public Texture2D texture2;
        Vector4 ColorVector;
        SpriteFont Font1;
        Vector2 FontPos;
        Rectangle MannaBox;
        Color magicColor;
        Color healthColor;
        float time;
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
            magicColor = Color.OrangeRed;
            texture1 = GV.ContentManager.Load<Texture2D>("Sprites/greenPixel");
            texture2 = GV.ContentManager.Load<Texture2D>("Sprites/WhitePixel");
            time = 0.0f;
            Font1 = GV.ContentManager.Load<SpriteFont>("SpriteFont1");         
            ColorVector = Color.DarkGray.ToVector4();
            ColorVector.W = 0.5f;
            healthColor = new Color(ColorVector);
        }

        public  void ChangeMagicItem(string item)
        {
            
            switch (item)
            {
                case "fire":
                    activeMagic.PlayAnimation("pickupFire");
                    magicColor = Color.OrangeRed;
                    break;
                case "water":
                    magicColor = Color.Blue;
                    activeMagic.PlayAnimation("pickupWater");
                    break;
                case "wind":
                    magicColor = Color.Green;
                    activeMagic.PlayAnimation("pickupWind");
                    break;
                case "earth":
                    magicColor = Color.Brown;
                    activeMagic.PlayAnimation("pickupEarth");
                    break;
                case "dark":
                    magicColor = Color.Purple;
                    activeMagic.PlayAnimation("pickupDark");
                    break;
                default:
                    Console.WriteLine("Invalid selection in Hub Manager");
                    break;

                    
            }
            GV.Player.CurrentMagicItem = item;
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


            Vector2 FontOrigin = Font1.MeasureString("" + GV.Player.Manna  + "/" + GV.Player.CurrentMagicCount) / 2;
            // Draw the string
            spriteBatch.DrawString(Font1, "" + GV.Player.Manna + "/" + GV.Player.CurrentMagicCount, new Vector2(50, 90), Color.BlueViolet, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

            Rectangle positionBox = new Rectangle((int)100, (int)+40, GV.Player.Health, 20);
            BoundingBox boundBox = new BoundingBox();
            spriteBatch.Draw(texture2, new Rectangle(positionBox.Left, positionBox.Top, positionBox.Width, 20), Color.Yellow);
            //boundBox.Draw(spriteBatch, positionBox, Color.Blue);

            MannaBox = new Rectangle((int)100, (int)+10, GV.Player.Manna, 20);
            Rectangle mannapower = new Rectangle((int)100, (int)+10, GV.Player.CurrentMagicCount, 20);
            
            positionBox = new Rectangle((int)100, (int)+5, 600, 25);
            //spriteBatch.Draw(texture2, new Rectangle(positionBox.Left, positionBox.Top, positionBox.Width, 20), Color.White);
            spriteBatch.Draw(texture2, new Rectangle(mannapower.Left, mannapower.Top, mannapower.Width, 20), magicColor);
            spriteBatch.Draw(texture2, new Rectangle(MannaBox.Left, MannaBox.Top, MannaBox.Width, 20), healthColor);


           
        }

    }
}
