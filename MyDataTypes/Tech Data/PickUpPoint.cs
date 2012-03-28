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
    public class PickUpPoint : LevelObject
    {
        //private Vector2 initialPoint;
        private string type;// style of object
        private string pointID;


        /// <summary>
        /// Initial point of the game object
        /// </summary>
        /*public Vector2 InitialPoint
        {
            get { return Position; }
            set { Position = value; }
        }*/

        /// <summary>
        /// Initial point of the game object
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Initial point of the game object
        /// </summary>
        public string PointID
        {
            get { return pointID; }
            set { pointID = value; }
        }
        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public PickUpPoint(string p_Type, string p_PointID, Vector2 p_InitialPoint)
        {
            Type = p_Type;
            PointID = p_PointID;
            Position = p_InitialPoint;
            Name = PointID;
            Console.WriteLine("PickupPoint Created: " + Name + "\t" + Type);

        }

        public PickUpPoint()
        { }

    }
}
