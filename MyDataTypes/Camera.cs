using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KismetDataTypes
{
    /// <summary>
    /// Class that takes care of the view in the level
    /// </summary>
    public static class Camera
    {

        #region Declarations

        private static Vector2 position = Vector2.Zero;
        private static Vector2 basePosition = Vector2.Zero;
        private static float zoomScale = 1.0f;
        private static Vector2 viewPortSize = Vector2.Zero;
        private static Rectangle worldRectangle = new Rectangle(0, 0, 0, 0);
        private static Rectangle defaultWorldRectangle = new Rectangle(0, 0, 0, 0);

        #endregion

        #region Properties

        /// <summary>
        /// The position of the camera, relative to the upper left corner of the view port
        /// </summary>
        public static Vector2 Position
        {
            get { return position; }
            set
            {
                position = new Vector2(MathHelper.Clamp(value.X, worldRectangle.X, worldRectangle.Width - ViewPortWidth),
                                       MathHelper.Clamp(value.Y, worldRectangle.Y, worldRectangle.Height - ViewPortHeight));
                if (zoomScale == 1.0f) { basePosition = position; }
                else { basePosition = Position / zoomScale; }
            }
        }

        /// <summary>
        /// The zoom level of the camera
        /// </summary>
        public static float Zoom
        {
            get { return zoomScale; }
            set
            {
                zoomScale = value;
                WorldRectangle = new Rectangle(WorldRectangle.X, WorldRectangle.Y,
                                               (int)(defaultWorldRectangle.Width * zoomScale),
                                               (int)(defaultWorldRectangle.Height * zoomScale));
                Position = basePosition * zoomScale;
            }
        }

        /// <summary>
        /// The size of the world
        /// </summary>
        public static Rectangle WorldRectangle
        {
            get { return worldRectangle; }
            set
            {
                worldRectangle = value;
                if (defaultWorldRectangle.Width == 0)
                {
                    defaultWorldRectangle = worldRectangle;
                }
            }
        }

        /// <summary>
        /// The width of the ViewPort
        /// </summary>
        public static int ViewPortWidth
        {
            get { return (int)viewPortSize.X; }
            set { viewPortSize.X = value; }
        }

        /// <summary>
        /// The height of the ViewPort
        /// </summary>
        public static int ViewPortHeight
        {
            get { return (int)viewPortSize.Y; }
            set { viewPortSize.Y = value; }
        }

        /// <summary>
        /// The ViewPort that is used as the bounds of what is seen
        /// </summary>
        public static Viewport Viewport
        {
            get { return new Viewport((int)Position.X, (int)Position.Y, ViewPortWidth, ViewPortHeight); }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Moves the viewport by the designated offset
        /// </summary>
        /// <param name="offset">The amount by which to offset the camera</param>
        public static void Move(Vector2 offset)
        {
            Position += offset;
        }

        /// <summary>
        /// Specifies whether an object is within the current ViewPort
        /// </summary>
        /// <param name="bounds">The bounds of the object</param>
        public static bool ObjectIsVisible(Rectangle bounds)
        {
            return (Viewport.Bounds.Intersects(bounds));
        }

        public static Vector2 WorldToScreen(Vector2 worldLocation)
        {
            return worldLocation - position;
        }

        public static Rectangle WorldToScreen(Rectangle worldRectangle)
        {
            return new Rectangle(
                worldRectangle.Left - (int)position.X,
                worldRectangle.Top - (int)position.Y,
                worldRectangle.Width,
                worldRectangle.Height);
        }

        public static Vector2 ScreenToWorld(Vector2 screenLocation)
        {
            return screenLocation + position;
        }

        public static Rectangle ScreenToWorld(Rectangle worldRectangle)
        {
            return new Rectangle(
                worldRectangle.Left + (int)position.X,
                worldRectangle.Top + (int)position.Y,
                worldRectangle.Width,
                worldRectangle.Height);
        }

        #endregion

    }
}
