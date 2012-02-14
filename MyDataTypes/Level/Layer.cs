using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KismetDataTypes
{
    public class Layer
    {

        #region Collision Variables

        public const int Passable = 0;
        public const int Impassable = 1;
        public const int Platform = 2;
        public const int Dead = 3;

        #endregion

        #region Dimensions

        // Constants for how many tiles (32 x 32) there are
        public static int TileWidth = 32;
        public static int TileHeight = 32;

        private const int EmptyTile = 50;

        /// <summary>
        /// Width of the level (in pixels)
        /// </summary>
        private int width;
        /// <summary>
        /// Width of the level (in pixels)
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Height of the layer (in pixels)
        /// </summary>
        private int height;
        /// <summary>
        /// Height of the layer (in pixels)
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Number of tiles wide the layer is
        /// </summary>
        private int tilesWide;
        /// <summary>
        /// Number of tiles wide the layer is
        /// </summary>
        public int TilesWide
        {
            get { return tilesWide; }
            set { tilesWide = value; }
        }

        /// <summary>
        /// Number of tiles wide the layer is
        /// </summary>
        private int tilesHigh;
        /// <summary>
        /// Number of tiles wide the layer is
        /// </summary>
        public int TilesHigh
        {
            get { return tilesHigh; }
            set { tilesHigh = value; }
        }

        /// <summary>
        /// Offset in the x direction for the layer
        /// </summary>
        private int xOffset;
        /// <summary>
        /// Offset in the x direction for the layer
        /// </summary>
        public int XOffset
        {
            get { return xOffset; }
            set { xOffset = value; }
        }

        /// <summary>
        /// Offset in the y direction for the layer
        /// </summary>
        private int yOffset;
        /// <summary>
        /// Offset in the y direction for the layer
        /// </summary>
        public int YOffset
        {
            get { return yOffset; }
            set { yOffset = value; }
        }

        #endregion

        #region Layer Stuff

        private string textureName;
        public string TextureName
        {
            get { return textureName; }
            set { textureName = value; }
        }

        /// <summary>
        /// The type of layer this is
        /// </summary>
        private int typeOfLayer;
        /// <summary>
        /// The type of layer this is
        /// </summary>
        public int TypeOfLayer
        {
            get { return typeOfLayer; }
            set { typeOfLayer = value; }
        }

        /// <summary>
        /// The representation of each tile in the layer
        /// </summary>
        private int[] layerTiles;
        /// <summary>
        /// The representation of each tile in the layer
        /// </summary>
        public int[] LayerTiles
        {
            get { return layerTiles; }
            set { layerTiles = value; }
        }

        /// <summary>
        /// The tileset associated with a layer
        /// </summary>
        private TileSet<Texture2D> tiles;
        /// <summary>
        /// The tileset associated with a layer
        /// </summary>
        public TileSet<Texture2D> Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }
        
        /// <summary>
        /// A list of the objects that will appear
        /// </summary>
        private List<LevelObject> levelObjects;
        /// <summary>
        /// A list of the objects that will appear
        /// </summary>
        public List<LevelObject> LevelObjects
        {
            get { return levelObjects; }
            set { levelObjects = value; }
        }

        // Also include some kind of object array for things
        // like image files dropped in (providing coordinates
        // for them, as well as size).

        #endregion

        #region Make and Draw

        /// <summary>
        /// Constructor that sets up a layer
        /// </summary>
        /// <param name="screensWide"> The number of screens wide the layer is</param>
        /// <param name="screensHigh"> The number of screens high the layer is</param>
        /// <param name="layerType"> The logical type of the layer</param>
        /// <param name="texture"> The texture used for the layer</param>
        /// <param name="data"> The values for each tile in the layer</param>
        /// <param name="x"> The x offset value for the layer</param>
        /// <param name="y"> The y offset value for the layer</param>
        public Layer(int width, int height, int layerType, string texture, int[] data, int x, int y)
        {
            Width = width;
            Height = height;
            TypeOfLayer = layerType;

            //Console.WriteLine("Type: " + layerType + "\tWidth: " + Width + "\tHeight: " + Height);

            TextureName = texture;
            Tiles = new TileSet<Texture2D>(ResourceManager.Instance.Texture(TextureName), 10, 6);
            
            TilesWide = Width / TileWidth;
            TilesHigh = Height / TileHeight;

            XOffset = x;
            YOffset = y;

            LayerTiles = data;
        }

        /// <summary>
        /// The function that draws the level on the screen
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (spriteBatch == null)
            {
                throw new ArgumentNullException("spriteBatch");
            }

            Rectangle destinationRect = new Rectangle(0, 0, TileWidth, TileHeight);
            int tile = 0;
            
            // Draw all the tiles needed
            for (int y = 0; y < TilesHigh; y+=1)
            {
                for (int x = 0; x < TilesWide; x+=1)
                {
                    tile = LayerTiles[x + (y * tilesWide)];

                    // Check to see if the tile is empty, if so, don't bother drawing it
                    if (tile != EmptyTile)
                    {
                        destinationRect.X = (x * TileWidth) + XOffset;
                        destinationRect.Y = (y * TileHeight) + YOffset;

                        spriteBatch.Draw(ResourceManager.Instance.Texture(TextureName), destinationRect, tiles.Tiles[tile], Color.White);
                    }
                    // Shows a grid around all the tiles in the editor
                    if (GV.EDITING && GV.ShowGrid)
                    {
                        destinationRect.X = (x * TileWidth) + XOffset;
                        destinationRect.Y = (y * TileHeight) + YOffset;

                        spriteBatch.Draw(ResourceManager.Instance.Texture(TextureName), destinationRect, new Rectangle(32, 160, 32, 32), Color.White);
                    }
                }
            }
        }

        #endregion

    }
}
