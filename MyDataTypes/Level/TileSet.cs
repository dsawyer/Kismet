using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace KismetDataTypes
{
    public class TileSet<T>
    {
        // Constants that set the width and height of tiles
        public const int tileWidth = 32;
        public const int tileHeight = 32;

        #region Description

        /// <summary>
        /// Number of tiles wide the tileset is
        /// </summary>
        private int tilesWide;
        /// <summary>
        /// Number of tiles wide the tileset is
        /// </summary>
        public int TilesWide
        {
            get { return tilesWide; }
            set { tilesWide = value; }
        }

        /// <summary>
        /// Number of tiles high the tileset is
        /// </summary>
        private int tilesHigh;
        /// <summary>
        /// Number of tiles high the tileset is
        /// </summary>
        public int TilesHigh
        {
            get { return tilesHigh; }
            set { tilesHigh = value; }
        }

        #endregion

        #region Tileset

        /// <summary>
        /// The texture used for the tileset
        /// </summary>
        private T tileset;
        /// <summary>
        /// The texture used for the tileset
        /// </summary>
        public T Tileset
        {
            get { return tileset; }
            set { tileset = value; }
        }

        /// <summary>
        /// The array of rectangles that form the tiles
        /// </summary>
        private Rectangle[] tiles;
        /// <summary>
        /// The array of rectangles that form the tiles
        /// </summary>
        public Rectangle[] Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }


        #endregion 

        /// <summary>
        /// Creates a new tileset
        /// </summary>
        /// <param name="texture">The texture used as the tileset</param>
        public TileSet(T texture, int width, int height)
        {
            // Get the tileset image into a texture
            Tileset = texture;

            // Number of tiles wide and high the image is
            TilesWide = width;
            TilesHigh = height;

            // Make the array of rectangles that will denote
            // the position of each tile in the tileset
            Tiles = new Rectangle[TilesWide * TilesHigh];

            for (int y = 0; y < TilesHigh; y+=1)
            {
                for (int x = 0; x < TilesWide; x += 1)
                {
                    Tiles[x + (y * TilesWide)] = new Rectangle((x * tileWidth), (y * tileHeight), tileWidth, tileHeight);
                }
            }
        }
    }
}
