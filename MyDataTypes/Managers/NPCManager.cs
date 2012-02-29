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
    public static class NPCManager
    {
       
        public static List<Enemy> sceneObjectsList = new List<Enemy>();
        public static void SpawnObject(string type, Vector2 point)
        {
            switch (type)
            {
                case "goblin":
                    sceneObjectsList.Add(new Goblin(GV.ContentManager, "XML Documents/GoblinAnimations", point));
                    break;
                case "demon":
                    sceneObjectsList.Add(new DemonArcher(GV.ContentManager, "XML Documents/DemonArcherAnimations", point));
                    break;
                case "fireMage":
                    sceneObjectsList.Add(new FireMage(GV.ContentManager, "XML Documents/FireMageAnimations", point));
                    break;
                case "miniboss":
                    sceneObjectsList.Add(new MiniBoss(GV.ContentManager, "XML Documents/MiniBossAnimations", point));
                    break;
                case "imp":
                    sceneObjectsList.Add(new ImpFlock(GV.ContentManager, "XML Documents/ImpAnimations", point));
                    break;
                
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }


        }

        public static void Update(GameTime gameTime)
        {
            if (sceneObjectsList.Count > 0)
            {
                for (int i = 0; i < sceneObjectsList.Count; i++) // Loop through List with for each item in list
                {
                    Enemy enemy = sceneObjectsList[i];
                    if (!enemy.IsAlive)
                    {
                        sceneObjectsList.Remove(enemy);

                    }
                    else
                    {
                        enemy.Update(gameTime);
                    }

                }
            }
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in sceneObjectsList) // Loop through List with foreach
            {
                enemy.Draw(gameTime,spriteBatch);
            }
        }

    }
}
