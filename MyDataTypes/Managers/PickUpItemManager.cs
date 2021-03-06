﻿using System;
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
                    Console.WriteLine("Invalid selection in Pickup Manager");
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

        /// <summary>
        /// Checks to see if an item is lit by the light spell
        /// </summary>
        /// <param name="item">The item being checked</param>
        /// <param name="min">The number of lights being checked</param>
        private static bool IsLitByMagic(PickUpItem item, int min)
        {
            Vector2 position = new Vector2(item.Position.X - item.Bounds.Width - 16, item.Position.Y - (item.Bounds.Height / 3));
            Vector2[] lightSpells = MagicItemManager.GetLightMagicArray(min);

            for (int i = 0; i < min; i += 1)
            {
                Vector2 pVector = position - lightSpells[i];
                float distance = (float)Math.Sqrt((Math.Pow((pVector.X), 2) + Math.Pow((pVector.Y), 2)));
                if (distance <= 200)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks to see if an item is lit by the lights in the level
        /// </summary>
        /// <param name="item">The item being checked</param>
        /// <param name="min">The number of lights being checked</param>
        private static bool IsLitByStaticLighting(PickUpItem item, int min)
        {
            Vector2 position = new Vector2(item.Position.X - item.Bounds.Width - 16, item.Position.Y - (item.Bounds.Height / 3));
            LightSource[] lights = GV.Level.Lights;

            for (int i = 0; i < min; i += 1)
            {
                Vector2 pVector = position - lights[i].Centre;
                double distance = Math.Sqrt((Math.Pow((pVector.X), 2) + Math.Pow((pVector.Y), 2)));
                pVector.Normalize();
                Vector2 normalisedDirection = lights[i].Direction;
                normalisedDirection.Normalize();
                float angle = Vector2.Dot(normalisedDirection, pVector);
                if (angle >= lights[i].IlluminationAngle && (float)distance <= lights[i].Radius)
                {
                    return true;
                }
            }

            return false;
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (pickUpItemList.Count > 0)
            {
                foreach (PickUpItem item in pickUpItemList) // Loop through List with foreach
                {
                    int min = 4 < GV.Level.NumLights ? 4 : GV.Level.NumLights;
                    int min1 = 4 < MagicItemManager.lightCount ? 4 : MagicItemManager.lightCount;

                    if (IsLitByMagic(item, min1) || IsLitByStaticLighting(item, min))
                    {
                        item.isLit = true;
                        item.Draw(gameTime, spriteBatch);
                    }
                    else
                    {
                        item.isLit = false;
                    }
                }
            }
        }

    }
}
