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
        public static int lightCount = 0;
        public static void CreateMagicItem(string type, Enemy enemy)
        {
            switch (type)
            {
                //player magic spells
                case "fire":
                case "earth":
                case "water":
                case "wind":
                case "dark":
                case "light":
                    magicItemList.Add(new MagicItem("XML Documents/DanMagicAnimations", "player", type, 5, null));
                    if (type == "light")
                        lightCount++;
                    break;

                // enemy weapons
                case "arrow":
                    magicItemList.Add(new MagicItem("XML Documents/EnemyMagicAnimations", "enemy", type, 5, enemy));
                    break;
                // enemy weapons
                case "fireRow":
                    MagicItem magicItem1 = (new MagicItem("XML Documents/EnemyMagicAnimations", "enemy", type, 5, enemy));
                    MagicItem magicItem2 = (new MagicItem("XML Documents/EnemyMagicAnimations", "enemy", type, 5, enemy));
                    MagicItem magicItem3 = (new MagicItem("XML Documents/EnemyMagicAnimations", "enemy", type, 5, enemy));
                    MagicItem magicItem4 = (new MagicItem("XML Documents/EnemyMagicAnimations", "enemy", type, 5, enemy));
                    MagicItem magicItem5 = (new MagicItem("XML Documents/EnemyMagicAnimations", "enemy", type, 5, enemy));
                    int direction = 1;
                    if (enemy.Direction == GV.LEFT)
                        direction = -1;

                    magicItem1.Position = new Vector2(enemy.Position.X + (direction * 20),enemy.Position.Y) ;
                    magicItem2.Position = new Vector2(enemy.Position.X + (direction * 60),enemy.Position.Y) ;
                    magicItem3.Position = new Vector2(enemy.Position.X + (direction * 100),enemy.Position.Y) ;
                    magicItem4.Position = new Vector2(enemy.Position.X + (direction * 140),enemy.Position.Y) ;
                    magicItem5.Position = new Vector2(enemy.Position.X + (direction * 180),enemy.Position.Y) ;

                    magicItemList.Add(magicItem1);
                    magicItemList.Add(magicItem2);
                    magicItemList.Add(magicItem3);
                    magicItemList.Add(magicItem4);
                    magicItemList.Add(magicItem5);
                    break;

               

                default:
                    Console.WriteLine("Invalid selection in Magic Item Manager");
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
                    /*if (item.ItemType == "light")
                        lightCount--;*/

                    if (!item.Active)
                    {
                        
                        magicItemList.Remove(item);
                        if (item.ItemType == "light")
                        { lightCount--; }
                    
                    }
                    else
                    {
                        //CollisionManager.ResolveMagicStaticCollisions(item);
                        item.Update(gameTime);
                    }

                }
            }
        }

        public static Vector2[] GetLightMagicArray(int num)
        {
            Vector2[] lightarray = new Vector2[num];
            int count = 0;
            if (magicItemList.Count > 0)
            {
                foreach (MagicItem item in magicItemList) // Loop through List with foreach
                {
                    if (item.ItemType == "light")
                    {
                        lightarray[count] = item.Light.Centre;
                        count++;
                    }
                    if (count == num)
                    { break; }
                }
            }
            return lightarray;
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
