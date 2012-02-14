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
    public static class PickUpItemManager
    {

        public static List<PickUpItem> pickUpItemList = new List<PickUpItem>();

        public static void CreatePickUpItem(string type, Vector2 point)
        {
            switch (type)
            {

                case "pickupFire":
                case "pickupWater":
                case "pickupWind":
                case "pickupEarth":
                case "pickupDark":
                case "pickupHeal":

                    pickUpItemList.Add(new PickUpItem("XML Documents/PickUpItemsAnimations", type, point));
                    break;

               
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }


        }

        public static void Update(GameTime gameTime)
        {
            if (pickUpItemList.Count > 0)
            {
                for (int i = 0; i < pickUpItemList.Count; i++) // Loop through List with for each item in list
                {
                    PickUpItem item = pickUpItemList[i];
                    if (!item.Active)
                    {
                        pickUpItemList.Remove(item);

                    }
                    else
                    {
                        item.Update(gameTime);
                    }

                }
            }
        }

        public static List<PickUpItem> GetList()
        {
            return pickUpItemList;
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (pickUpItemList.Count > 0)
            {
                foreach (PickUpItem item in pickUpItemList) // Loop through List with foreach
                {
                    item.Draw(gameTime, spriteBatch);
                }
            }
        }

    }
}
