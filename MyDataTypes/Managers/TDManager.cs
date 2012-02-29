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
    public static class TDManager
    {

        public static List<TriggerBox> TriggerboxList  = new List<TriggerBox>();
        public static Dictionary<string, Object> DataList = new Dictionary<string, Object>();

        public static void Initialize()
        {
            TriggerboxList.Add(new TriggerBox("spawn", "pickupFire1", new Rectangle(250, 440, 500, 300)));
            DataList.Add("pickupFire1", new PickUpPoint("pickupFire", "pickupFire1", new Vector2(100, 440)));
            TriggerboxList.Add(new TriggerBox("spawn", "pickupWater1", new Rectangle(250, 440, 500, 300)));
            DataList.Add("pickupWater1", new PickUpPoint("pickupWater", "pickupWater1", new Vector2(250, 440)));
            TriggerboxList.Add(new TriggerBox("spawn", "pickupWind1", new Rectangle(250, 440, 500, 300)));
            DataList.Add("pickupWind1", new PickUpPoint("pickupWind", "pickupWind1", new Vector2(450, 440)));
            TriggerboxList.Add(new TriggerBox("spawn", "pickupEarth1", new Rectangle(250, 440, 500, 300)));
            DataList.Add("pickupEarth1", new PickUpPoint("pickupEarth", "pickupEarth1", new Vector2(650, 440)));
            TriggerboxList.Add(new TriggerBox("spawn", "pickupHeal1", new Rectangle(250, 440, 500, 300)));
            DataList.Add("pickupHeal1", new PickUpPoint("pickupHeal", "pickupHeal1", new Vector2(850, 440)));
            TriggerboxList.Add(new TriggerBox("spawn", "pickupDark1", new Rectangle(250, 440, 500, 300)));
            DataList.Add("pickupDark1", new PickUpPoint("pickupDark", "pickupDark", new Vector2(1050, 440)));
           
<<<<<<< HEAD
            /*TriggerboxList.Add(new TriggerBox("spawn", "goblin100", new Rectangle(250, 440, 500, 300)));
            DataList.Add("goblin100", new SpawnPoint("goblin", "goblin100", new Vector2(18.0f, 15.0f)));*/
=======
            TriggerboxList.Add(new TriggerBox("spawn", "goblin100", new Rectangle(250, 440, 500, 300)));
            DataList.Add("goblin100", new SpawnPoint("goblin", "goblin100", new Vector2(18.0f, 15.0f)));
            TriggerboxList.Add(new TriggerBox("spawn", "fireMage1", new Rectangle(250, 440, 500, 300)));
            DataList.Add("fireMage1", new SpawnPoint("fireMage", "fireMage1", new Vector2(500.0f, 440.0f)));

            TriggerboxList.Add(new TriggerBox("spawn", "imp1", new Rectangle(250, 440, 500, 300)));
            DataList.Add("imp1", new SpawnPoint("imp", "imp1", new Vector2(300.0f, 300.0f)));

            TriggerboxList.Add(new TriggerBox("checkPoint", "checkpoint1", new Rectangle(250, 440, 500, 300)));
            DataList.Add("checkpoint1", new CheckPoint());


>>>>>>> 9596670ad749c1b4f9ce2c5fb1b6a941d267d543
            //TriggerboxList.Add(new TriggerBox("spawn", "goblin100", new Rectangle(250, 440, 500, 300)));
            //DataList.Add("goblin100", new SpawnPoint("goblin", "goblin100", new Vector2(6,18)));
            /*
            //TriggerboxList.Add(new TriggerBox("spawn", "demon1", new Rectangle(400, 300, 200, 100)));
           
            //TriggerboxList.Add(new TriggerBox("spawn", "miniboss", new Rectangle(250, 440, 500, 300)));
            //DataList.Add("goblin1",new SpawnPoint("goblin","goblin1",new Vector2(500.0f, 440.0f)));
            TriggerboxList.Add(new TriggerBox("spawn", "demon1", new Rectangle(250, 440, 500, 300)));
            DataList.Add("goblin1", new SpawnPoint("goblin", "goblin1", new Vector2(400.0f, 300.0f)));
            //DataList.Add("demon1", new SpawnPoint("demon", "demon1", new Vector2(400.0f, 300.0f)));
            //DataList.Add("miniboss", new SpawnPoint("miniboss", "miniboss", new Vector2(1000.0f, 440.0f)));
            //DataList.Add("fireMage1", new SpawnPoint("fireMage", "fireMage1", new Vector2(1000.0f, 440.0f)));
            DataList.Add("demon1", new SpawnPoint("demon", "demon1", new Vector2(1000.0f, 440.0f)));*/
        }

        public static void Add(TriggerBox p_TriggerBox)
        {
            string type = p_TriggerBox.Type;
            string target = p_TriggerBox.Target;
            //get object from list 
            Object point = DataList[target];
            string objectType = point.GetType().ToString(); ;

            switch (objectType)
            {
                
                case "KismetDataTypes.SpawnPoint":
                     SpawnPoint newObject = (SpawnPoint)point;
                     NPCManager.SpawnObject(newObject.Type, newObject.Position);
                     // Remove the trigger box for a spawn point
                     TriggerboxList.Remove(p_TriggerBox);
                     DataList.Remove(target);
                    break;
                case "KismetDataTypes.PickUpPoint":
                    PickUpPoint newPickUpObject = (PickUpPoint)point;
                    PickUpItemManager.CreatePickUpItem(newPickUpObject.Type, newPickUpObject.Position);
                    // Remove the trigger box for a spawn point
                    TriggerboxList.Remove(p_TriggerBox);
                    DataList.Remove(target);
                    break;

                case "KismetDataTypes.CheckPoint":
                    GV.Player.CheckPoint = target;
                    TriggerboxList.Remove(p_TriggerBox);
                    DataList.Remove(target);
                    break;
                case "KismetDataTypes.Warp":
                    Warp warp = (Warp)point;
                    if (GV.Level.Name == warp.DestinationLevel)
                    {
                        GV.Player.Position = warp.TargetPosition;
                        GV.Player.Velocity = Vector2.Zero;
                    }
                    // Change the level
                    else
                    {
                        // Load and initialise the new level
                        GV.Level = GV.ContentManager.Load<Level>("Level/" + warp.DestinationLevel);
                        GV.Level.Initialise(GV.ContentManager);
                        // Put the player in the new level
                        GV.Player.Position = warp.TargetPosition;
                        GV.Player.Velocity = Vector2.Zero;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }

        /// <summary>
        /// updates the TDManager to check all the triggerboxes in the list.
        /// </summary>
        public static void Update(GameTime gameTime)
        {
            NPCManager.Update(gameTime);
            if (TriggerboxList.Count > 0)
            {
                for (int i = 0; i < TriggerboxList.Count; i++) // Loop through List with for each item in list
                {
                    TriggerBox box = TriggerboxList[i];
                    Vector2 Depth = RectangleExtensions.GetIntersectionDepth(GV.Player.Bounds, box.Triggerbox);
                    if (Depth != Vector2.Zero)
                    {
                        Add(box);
                        // Don't want to remove it if it belongs to a warp point
                        //TriggerboxList.Remove(box);
                    }
                }
            } 
        }
    }
}
