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
        private Vector2 anchor = Vector2.Zero;
        private float swingAngle = 0;
        private float speed = 0;
        private float attenuation = GV.DefaultAttenuation;
        private float illuminationAngle;
        private int radius = 0;
        private int brightness = 0;
        private Vector3 colour = Vector3.Zero;

        private const int Left = 0;
        private const int Right = 1;

        private int swingDirection = Left;
        private float elapsedTime = 0.0f;

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
            get
            {
                direction = Centre - Anchor;
                return direction;
            }
            set { direction = value; }
        }

        /// <summary>
        /// The anchor point from which the light swings
        /// </summary>
        public Vector2 Anchor
        {
            get { return anchor; }
            set { anchor = value; }
        }

        /// <summary>
        /// The cosine of the maximum angle formed by a vertical vector
        /// and the direction the light is pointing
        /// </summary>
        public float SwingAngle
        {
            get { return swingAngle; }
            set { swingAngle = value; }
        }

        /// <summary>
        /// The speed at which the light is swinging from side to side
        /// </summary>
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
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

        /// <summary>
        /// The colour of the light
        /// </summary>
        public Vector3 Colour
        {
            get { return colour; }
            set { colour = value; }
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
        /// Updates the position of the light (causing it to swing) as time goes on
        /// </summary>
        /// <param name="gameTime"></param>
        public void UpdatePosition(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedTime >= 0.01f)
            {
                // Reset the elapsed time
                elapsedTime = 0.0f;

                // Calculate offsets
                Vector2 oldOffset = Centre - Anchor;
                Vector2 newOffset;

                // Modify the new offset based on what direction the light is swinging
                if (swingDirection == Left)
                {
                    newOffset = new Vector2(oldOffset.X - Speed / 4, oldOffset.Y);
                }
                else
                {
                    newOffset = new Vector2(oldOffset.X + Speed / 4, oldOffset.Y);
                }

                // Do calculations based on the normals
                Vector2 normalOffset = newOffset;
                normalOffset.Normalize();
                float cosAngleBetween = Vector2.Dot(normalOffset, new Vector2(0, 1));

                // Check to see if the light has swung as far as it can go
                if (cosAngleBetween <= SwingAngle && swingDirection == Left)
                {
                    swingDirection = Right;
                    return;
                }
                else if (cosAngleBetween <= SwingAngle && swingDirection == Right)
                {
                    swingDirection = Left;
                    return;
                }

                // Calculate the new x and y positions
                float yTranslation = oldOffset.Length() * cosAngleBetween;
                float sinAngleBetween = (float)Math.Sqrt(1 - (cosAngleBetween * cosAngleBetween));
                float xTranslation = oldOffset.Length() * sinAngleBetween;

                // Make sure the the x is being set properly
                if (Anchor.X + newOffset.X < Anchor.X)
                { xTranslation *= -1; }

                // Move the light and the lantern image associated with it
                Centre = new Vector2(Anchor.X + xTranslation, Anchor.Y + yTranslation);
                BoundingBox = new Rectangle((int)(Centre.X) - 16, (int)(Centre.Y) - 16, 32, 32);
            }
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
