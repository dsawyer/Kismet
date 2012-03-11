using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KismetDataTypes
{
    /// <summary>
    /// Models a light source. Can be a point source or a spotlight.
    /// </summary>
    public class LightSource : LevelObject
    {

        #region Definitions

        private Vector2 centre = Vector2.Zero;
        private Vector2 direction = Vector2.Zero;
        private float attenuation = GV.DefaultAttenuation;
        private float illuminationAngle;
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
        /// The direction vector of the light
        /// </summary>
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        /// <summary>
        /// The attenuation value of the light
        /// </summary>
        public float Attenuation
        {
            get { return attenuation; }
            set { attenuation = value; }
        }

        /// <summary>
        /// The effective angle of the spot light
        /// </summary>
        public float IlluminationAngle
        {
            get { return illuminationAngle; }
            set { illuminationAngle = value; }
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
            // This makes it point down
            Direction = new Vector2(0, 1);
            Radius = lightRadius;
            Brightness = lightBright;
        }

        /// <summary>
        /// Basic Constructor for a light source
        /// </summary>
        /// <param name="x">X position in the world</param>
        /// <param name="y">Y position in the world</param>
        /// <param name="centreX">Centre of the light itself (X)</param>
        /// <param name="centreY">Centre of the light itself (Y)</param>
        /// <param name="lightRadius">The distance that the light affects</param>
        /// <param name="lightBright">The brightness of the light</param>
        /// <param name="attenuationFactor">The attenuation value being specified for the spot light</param>
        public LightSource(int x, int y, int centreX, int centreY, int lightRadius, int lightBright, float attenuationFactor)
        {
            Name = "Light";
            Position = new Vector2(x - 16, y - 16);
            BoundingBox = new Rectangle(x - 16, y - 16, 32, 32);
            Centre = new Vector2(centreX, centreY);
            // This makes it point down
            Direction = new Vector2(0, Centre.Y + 1);
            Attenuation = attenuationFactor;
            Radius = lightRadius;
            Brightness = lightBright;
        }

        /// <summary>
        /// A specific drawing code for drawing a light source (the image of it,
        /// not the effect it has on its surroundings)
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawLightSource(SpriteBatch spriteBatch)
        {
            Rectangle destinationRect = BoundingBox;

            Rectangle source = ImageBounds;

            spriteBatch.Draw(ResourceManager.Instance.Texture("Tiles"), destinationRect, source, Color.White);

            if (GV.ShowBoxes)
            {
                Circle boundcircle = new Circle(Centre, Radius);
                boundcircle.Draw(spriteBatch, Color.Green);
            }
        }
    }
}
