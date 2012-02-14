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
    public static class MagicItemManager
    {

        public static List<MagicItem> magicItemList = new List<MagicItem>();
        
        public static void CreateMagicItem(string type, Enemy enemy)
        {
            switch (type)
            {
                case "fire":
                case "earth":
                case "water":
                case "wind":
                case "dark":
                case "light":
                    magicItemList.Add(new MagicItem("XML Documents/DanMagicAnimations", "player", type, 5, null));
                    break;
               

                case "arrow":
                    magicItemList.Add(new MagicItem("XML Documents/EnemyMagicAnimations", "enemy", type, 5, enemy));
                    break;

               

                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }


        }

        public static void Update(GameTime gameTime)
        {
            if (magicItemList.Count > 0)
            {
                for (int i = 0; i< magicItemList.Count; i++) // Loop through List with for each item in list
                {
                    MagicItem item = magicItemList[i];
                    if (!item.Active)
                    {
                        magicItemList.Remove(item);
                    
                    }
                    else
                    {
                        //CollisionManager.ResolveMagicStaticCollisions(item);
                        item.Update(gameTime);
                    }

                }
            }
        }

        public static List<MagicItem> GetList()
        {
            return magicItemList;
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (magicItemList.Count > 0)
            {
                foreach (MagicItem item in magicItemList) // Loop through List with foreach
                {
                    item.Draw(gameTime, spriteBatch);
                }
            }
        }

    }
}
