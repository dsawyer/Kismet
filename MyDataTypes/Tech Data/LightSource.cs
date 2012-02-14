using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace KismetDataTypes
{
    public class LightSource : LevelObject
    {

        #region Definitions

        private Vector2 centre = Vector2.Zero;
        private int radius = 0;
        private int brightness = 0;

        #endregion

        #region Properties

        /// <summary>
        /// The centre point used to calculate the amount of light on a given point
        /// </summary>
        public Vector2 Centre
        {
            get { return centre; }
            set { centre = value; }
        }

        /// <summary>
        /// The distance that light can travel from the centre point
        /// </summary>
        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        /// <summary>
        /// The brightness of the light
        /// </summary>
        public int Brightness
        {
            get { return brightness; }
            set { brightness = value; }
        }

        #endregion

        public LightSource() {}

        /// <summary>
        /// Basic Constructor for a light source
        /// </summary>
        /// <param name="x">X position in the world</param>
        /// <param name="y">Y position in the world</param>
        /// <param name="centreX">Centre of the light itself (X)</param>
        /// <param name="centreY">Centre of the light itself (Y)</param>
        /// <param name="lightRadius">The distance that the light affects</param>
        /// <param name="lightBright">The brightness of the light</param>
        public LightSource(int x, int y, int centreX, int centreY, int lightRadius, int lightBright)
        {
            Name = "Light";
            Position = new Vector2(x - 16, y - 16);
            BoundingBox = new Rectangle(x - 16, y - 16, 32, 32);
            Centre = new Vector2(centreX, centreY);
            Radius = lightRadius;
            Brightness = lightBright;
            ImageName = "Tiles";
            ImageBounds = new Rectangle(160, 128, 32, 32);
        }
    }
}
