using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace KismetDataTypes
{
    public class Warp : LevelObject
    {

        #region Declarations

        private string destinationLevel = "";
        private Vector2 targetPosition = Vector2.Zero;

        #endregion

        #region Properties

        /// <summary>
        /// The level that holds the other side of the warp point
        /// </summary>
        public string DestinationLevel
        {
            get { return destinationLevel; }
            set { destinationLevel = value; }
        }

        /// <summary>
        /// The position where the player is moved
        /// </summary>
        public Vector2 TargetPosition
        {
            get { return targetPosition; }
            set { targetPosition = value; }
        }

        #endregion

        public Warp() {}

        /// <summary>
        /// Basic constructor for a warp point
        /// </summary>
        /// <param name="x">X position in the world</param>
        /// <param name="y">Y position in the world</param>
        /// <param name="width">Width of the warp area</param>
        /// <param name="height">Height of the warp area</param>
        /// <param name="destLevel">The level that contains the warp point at the other end</param>
        /// <param name="destWarp">The warp point being targeted at the other end</param>
        public Warp(int x, int y, int width, int height, string destLevel, Vector2 destWarp)
        {
            Name = "Warp";
            Position = new Vector2(x - 16, y - 16);
            BoundingBox = new Rectangle(x - 16, y - 16, width, height);
            ImageName = "Tiles";
            ImageBounds = new Rectangle(224, 0, 32, 64);
            DestinationLevel = destLevel;
            TargetPosition = destWarp;
        }
    }
}
