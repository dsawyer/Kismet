﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace KismetDataTypes
{
    /// <summary>
    /// Models a level in the game
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="KismetDataTypes.Level")]
    [System.Xml.Serialization.XmlRootAttribute("Level", Namespace="KismetDataTypes.Level", IsNullable=false)]
    public class Level : ContentObject
#if WINDOWS
, ICloneable
#endif
    {

        #region Description

        /// <summary>
        /// The name of this level
        /// </summary>
        private string name;

        /// <summary>
        /// The name of this level
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Width of the level (in pixels)
        /// </summary>
        private int width;
        /// <summary>
        /// Width of the level (in pixels)
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Width")]
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
        [System.Xml.Serialization.XmlElementAttribute("Height")]
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Gets the bounding rectangle of a tile in world space.
        /// </summary>        
        public Rectangle GetBounds(int x, int y)
        {
            return new Rectangle(x * Layer.TileWidth, y * Layer.TileHeight,
                                 Layer.TileWidth, Layer.TileHeight);
        }

        private Vector2 playerPosition = Vector2.Zero;
        /// <summary>
        /// Starting position of the player in the level
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("PlayerStartingPosition")]
        public Vector2 PlayerStartingPosition
        {
            get { return playerPosition; }
            set { playerPosition = value; }
        }

        #endregion

        #region Layer Information

        #region Object layer

        [System.Xml.Serialization.XmlElementAttribute("NumWarps")]
        // the number of warps in a level
        public int NumWarps = 0;
        // The number of spawners in the level
        [System.Xml.Serialization.XmlElementAttribute("NumSpawners")]
        public int NumSpawners = 0;
        // The number of trigger boxes in the level
        [System.Xml.Serialization.XmlElementAttribute("NumTriggers")]
        public int NumTriggers = 0;
        // The number of light sources in the level
        [System.Xml.Serialization.XmlElementAttribute("NumLights")]
        public int NumLights = 0;

        [System.Xml.Serialization.XmlElementAttribute("Warps")]
        public Warp[] Warps;
        [System.Xml.Serialization.XmlElementAttribute("Spawners")]
        public SpawnPoint[] Spawners;
        [System.Xml.Serialization.XmlElementAttribute("Triggers")]
        public TriggerBox[] Triggers;
        [System.Xml.Serialization.XmlElementAttribute("Lights")]
        public LightSource[] Lights;

        /// <summary>
        /// Contains the objects in the level
        /// </summary>
        //[System.Xml.Serialization.XmlElementAttribute("Objects")]
        private Dictionary<string, LevelObject> objects = new Dictionary<string,LevelObject>();
        /// <summary>
        /// Get an object out of the level
        /// </summary>
        /// <param name="key">The name of the object to be returned</param>
        public LevelObject GetObject(string key)
        { return objects[key]; }
        /// <summary>
        /// Put a new object into the objects list
        /// </summary>
        /// <param name="key">Name of the new object</param>
        /// <param name="obj">The new object to be added</param>
        public void SetObject(string key, LevelObject obj)
        {
            if (!objects.ContainsKey(key))
            {
                objects.Add(key, obj);
            }
            else
            {
                objects[key] = obj;
            }
        }

        #endregion

        /// <summary>
        /// A list of the layers used in the level
        /// </summary>
        private Dictionary<string, Layer> layers = new Dictionary<string, Layer>();
        /// <summary>
        /// A way to get the layers
        /// </summary>
        public Layer GetLayer(string key)
        { return layers[key]; }
        /// <summary>
        /// Adds a layer to the list
        /// </summary>
        /// <param name="key">Name of the layer</param>
        /// <param name="layer">The layer to be added</param>
        public void SetLayer(string key, Layer layer)
        {
            if (!layers.ContainsKey(key))
            {
                layers.Add(key, layer);
            }
        }

        #region Ground Layer

        /// <summary>
        /// The name of the texture for the ground layer
        /// </summary>
        private string groundLayerTexture;
        /// <summary>
        /// A texture used as a base tileset for a ground layer
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("GroundLayerTexture")]
        public string GroundLayerTexture
        {
            get { return groundLayerTexture; }
            set { groundLayerTexture = value; }
        }

        /// <summary>
        /// The values for the ground layer's tiles
        /// </summary>
        private int[] groundLayerValues;
        /// <summary>
        /// The values for the ground layer's tiles
        /// </summary>
        [XmlArray ("GroundLayerValues"), XmlArrayItem (typeof(int))]
        public int[] GroundLayerValues
        {
            get { return groundLayerValues; }
            set { groundLayerValues = value; }
        }

        /// <summary>
        /// The ground layer in the level
        /// </summary>
        private Layer groundLayer;

        #endregion

        #region SurGround Layer

        /// <summary>
        /// The name of the texture for the ground layer
        /// </summary>
        private string surGroundLayerTexture;
        /// <summary>
        /// A texture used as a base tileset for a ground layer
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("SurGroundLayerTexture")]
        public string SurGroundLayerTexture
        {
            get { return surGroundLayerTexture; }
            set { surGroundLayerTexture = value; }
        }

        /// <summary>
        /// The values for the ground layer's tiles
        /// </summary>
        private int[] surGroundLayerValues;
        /// <summary>
        /// The values for the ground layer's tiles
        /// </summary>
        [XmlArray("SurGroundLayerValues"), XmlArrayItem(typeof(int))]
        public int[] SurGroundLayerValues
        {
            get { return surGroundLayerValues; }
            set { surGroundLayerValues = value; }
        }

        /// <summary>
        /// The ground layer in the level
        /// </summary>
        private Layer surGroundLayer;

        #endregion

        #region Foreground Layer

        /// <summary>
        /// The name of the texture for the foreground layer
        /// </summary>
        private string foregroundLayerTexture;
        /// <summary>
        /// A texture used as a base tileset for a foreground layer
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ForegroundLayerTexture")]
        public string ForegroundLayerTexture
        {
            get { return foregroundLayerTexture; }
            set { foregroundLayerTexture = value; }
        }

        /// <summary>
        /// The values for the foreground layer's tiles
        /// </summary>
        private int[] foregroundLayerValues;
        /// <summary>
        /// The values for the foreground layer's tiles
        /// </summary>
        [XmlArray("ForegroundLayerValues"), XmlArrayItem(typeof(int))]
        public int[] ForegroundLayerValues
        {
            get { return foregroundLayerValues; }
            set { foregroundLayerValues = value; }
        }

        /// <summary>
        /// The foreground layer in the level
        /// </summary>
        private Layer foregroundLayer;

        #endregion

        #region Collision Layer

        /// <summary>
        /// The name of the texture for the collision layer
        /// </summary>
        private string collisionLayerTexture;
        /// <summary>
        /// A texture used as a base tileset for a collision layer
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("CollisionLayerTexture")]
        public string CollisionLayerTexture
        {
            get { return collisionLayerTexture; }
            set { collisionLayerTexture = value; }
        }

        /// <summary>
        /// The values for the collision layer's tiles
        /// </summary>
        private int[] collisionLayerValues;
        /// <summary>
        /// The values for the collision layer's tiles
        /// </summary>
        [XmlArray("CollisionLayerValues"), XmlArrayItem(typeof(int))]
        public int[] CollisionLayerValues
        {
            get { return collisionLayerValues; }
            set { collisionLayerValues = value; }
        }

        /// <summary>
        /// Gets the collision value of a given tile from the collision layer
        /// </summary>
        /// <param name="x">X position in the layer</param>
        /// <param name="y">Y position in the layer</param>
        public int GetCollision(int x, int y)
        {
            if (x + (y * collisionLayer.TilesWide) < Width * Height / (32 * 32))
            {
                if (x + (y * collisionLayer.TilesWide) > 0)
                {
                    return collisionLayerValues[x + (y * collisionLayer.TilesWide)];
                }
                else
                {
                    return Layer.Passable;
                }
            }
            else
            {
                return Layer.Dead;
            }
        }

        /// <summary>
        /// The collision layer in the level
        /// </summary>
        private Layer collisionLayer;

        #endregion

        #endregion

        #region Initialise and Drawing

        /// <summary>
        /// Initialises the layers in the level
        /// </summary>
        public void Initialise(ContentManager contentManager)
        {
            // Initialise the ground layer
            if (!ResourceManager.Instance.ContainsTexture(GroundLayerTexture))
            {
                ResourceManager.Instance.Texture(GroundLayerTexture, contentManager.Load<Texture2D>(System.IO.Path.Combine(@"Tiles\", GroundLayerTexture)));
            }
            groundLayer = new Layer(Width, Height, 0, GroundLayerTexture, GroundLayerValues, 0, 0);
            // Initialise the surGroundlayer
            if (!ResourceManager.Instance.ContainsTexture(SurGroundLayerTexture))
            {
                ResourceManager.Instance.Texture(SurGroundLayerTexture, contentManager.Load<Texture2D>(System.IO.Path.Combine(@"Tiles\", SurGroundLayerTexture)));
            }
            /*surGroundLayer = new Layer(Width, Height, 0, SurGroundLayerTexture, SurGroundLayerValues, 0, 0);
            // Initialise the foreground layer
            if (!ResourceManager.Instance.ContainsTexture(ForegroundLayerTexture))
            {
                ResourceManager.Instance.Texture(ForegroundLayerTexture, contentManager.Load<Texture2D>(System.IO.Path.Combine(@"Tiles\", ForegroundLayerTexture)));
            }
            foregroundLayer = new Layer(Width, Height, 0, ForegroundLayerTexture, ForegroundLayerValues, 0, 0);
            // Initialise the collision layer
            if (!ResourceManager.Instance.ContainsTexture(CollisionLayerTexture))
            {
                ResourceManager.Instance.Texture(CollisionLayerTexture, contentManager.Load<Texture2D>(System.IO.Path.Combine(@"Tiles\", CollisionLayerTexture)));
            }*/
            collisionLayer = new Layer(Width, Height, 0, CollisionLayerTexture, CollisionLayerValues, 0, 0);

            // Add all the spawnpoints to the tech data manager
            for (int i = 0; i < NumSpawners; i += 1)
            {
                TDManager.DataList.Add(Spawners[i].PointID, Spawners[i]);
            }

            // Add all the warps to the tech data manager
            for (int i = 0; i < NumWarps; i += 1)
            {
                TDManager.DataList.Add(Warps[i].Name, Warps[i]);
            }

            // Add all the trigger boxes to the tech data manager
            for (int i = 0; i < NumTriggers; i += 1)
            {
                TDManager.TriggerboxList.Add(Triggers[i]);
            }

            // Testing values and printing them to the console

            /*Console.WriteLine("Number of Warp Points: " + NumWarps);
            Console.WriteLine("X: " + Warps[0].Position.X + "\tY: " + Warps[0].Position.Y);
            Console.WriteLine("Width: " + Warps[0].BoundingBox.Width + "\tHeight: " + Warps[0].BoundingBox.Height);
            Console.WriteLine("Image: " + Warps[0].ImageName);
            Console.WriteLine("ImageX: " + Warps[0].ImageBounds.X + "\tImageY: " + Warps[0].ImageBounds.Y);
            Console.WriteLine("ImageWidth: " + Warps[0].ImageBounds.Width + "\tImageHeight: " + Warps[0].ImageBounds.Height);
            */
        }

        /// <summary>
        /// Draws the the part of the level that is visible
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            groundLayer.Draw(spriteBatch);
            //surGroundLayer.Draw(spriteBatch);
            if (GV.EDITING)
            { DrawObjects(spriteBatch); }
            //foregroundLayer.Draw(spriteBatch);
        }

        // Draw the warps in the level (used in the editor and for testing)
        public void DrawWarps(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < NumWarps; i += 1)
            {
                Warps[i].Draw(spriteBatch);
            }
        }

        // Draws the spawners in the level (used for the editor and testing)
        public void DrawSpawners(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < NumSpawners; i += 1)
            {
                Spawners[i].Draw(spriteBatch);
            }
        }

        // Draws the trigger boxes in the level (used in the editor and for testing)
        public void DrawTriggerBoxes(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < NumTriggers; i += 1)
            {
                Triggers[i].Draw(spriteBatch);
            }
        }

        // Draws the lights in the level (used in the editor and for testing)
        public void DrawLights(SpriteBatch spriteBatch)
        {
            // Empty for now
        }

        /// <summary>
        /// Draws the objects in the level
        /// </summary>
        public void DrawObjects(SpriteBatch spriteBatch)
        {
            // Draw in the warp points
            DrawWarps(spriteBatch);

            // And the spawners
            //DrawSpawners(spriteBatch);

            // And the trigger boxes
            DrawTriggerBoxes(spriteBatch);

            // And finally the light sources
            //DrawLights(spriteBatch);

            /*if (objects.Count > 0)
            {
                // Draw all the warps in the level
                for (int i = 0; i < NumWarps; i += 1)
                {
                    if (objects.ContainsKey("Warp" + i))
                    {
                        objects["Warp" + i].Draw(spriteBatch);
                    }
                }

                // Have to figure out how to move the spawners around,
                // to try and save on time...
                for (int i = 0; i < NumSpawners; i += 1)
                {
                    if (objects.ContainsKey("Spawner" + i))
                    {
                        objects["Spawner" + i].Draw(spriteBatch);
                    }
                }

                // Draw all the light sources
                for (int i = 0; i < NumLights; i += 1)
                {
                    if (objects.ContainsKey("Light" + i))
                    {
                        objects["Light" + i].Draw(spriteBatch);
                    }
                }
            }*/
        }

        #endregion

        #region Update

        /// <summary>
        /// Method called during update process
        /// </summary>
        public void Update()
        {
        }

        /// <summary>
        /// Adds a warp point to the level
        /// </summary>
        public void AddWarp(Warp warp)
        {
            // Check to see if there is already a warp with the same
            // name/tag, if so, change it for the new one
            for (int i = 0; i < NumWarps; i += 1)
            {
                if (Warps[i].Name == warp.Name)
                {
                    Warps[i] = warp;
                    return;
                }
            }

            // If it really is a new warp, then add it to the list
            NumWarps += 1;
            Warp[] temp = new Warp[NumWarps];
            for (int i = 0; i < NumWarps - 1; i += 1)
            {
                temp[i] = Warps[i];
            }
            temp[NumWarps - 1] = warp;
            Warps = temp;

            TDManager.DataList.Add(warp.Name, warp);
        }

        /// <summary>
        /// Adds a spawner to the level
        /// </summary>
        public void AddSpawnPoint(SpawnPoint spawner)
        {
            // Check to see if there is already a spawn point with the same
            // name/tag, if so, change it for the new one
            for (int i = 0; i < NumSpawners; i += 1)
            {
                if (Spawners[i].Name == spawner.Name)
                {
                    Spawners[i] = spawner;
                    return;
                }
            }

            // If it really is a new spawn point, then add it to the list
            NumSpawners += 1;
            SpawnPoint[] temp = new SpawnPoint[NumSpawners];
            for (int i = 0; i < NumSpawners - 1; i += 1)
            {
                temp[i] = Spawners[i];
            }
            temp[NumSpawners - 1] = spawner;
            Spawners = temp;

            TDManager.DataList.Add(spawner.Name, spawner);
        }

        /// <summary>
        /// Adds a light source to the level
        /// </summary>
        public void AddLight(LightSource light)
        {
            // Check to see if there is already a light source with the same
            // name/tag, if so, change it for the new one
            for (int i = 0; i < NumLights; i += 1)
            {
                if (Lights[i].Name == light.Name)
                {
                    Lights[i] = light;
                    return;
                }
            }

            // If it really is a new light source, then add it to the list
            NumLights += 1;
            LightSource[] temp = new LightSource[NumLights];
            for (int i = 0; i < NumLights - 1; i += 1)
            {
                temp[i] = Lights[i];
            }
            temp[NumLights - 1] = light;
            Lights = temp;
        }

        /// <summary>
        /// Add a trigger box to the level
        /// </summary>
        public void AddTriggerBox(TriggerBox trigger)
        {
            // Check to see if there is already a trigger box with the same
            // name/tag, if so, change it for the new one
            for (int i = 0; i < NumTriggers; i += 1)
            {
                if (Triggers[i].Name == trigger.Name)
                {
                    Triggers[i] = trigger;
                    return;
                }
            }

            // If it really is a new trigger box, then add it to the list
            NumTriggers += 1;
            TriggerBox[] temp = new TriggerBox[NumTriggers];
            for (int i = 0; i < NumTriggers - 1; i += 1)
            {
                temp[i] = Triggers[i];
            }
            temp[NumTriggers - 1] = trigger;
            Triggers = temp;

            TDManager.TriggerboxList.Add(trigger);
        }

        /// <summary>
        /// Removes an object form the level
        /// </summary>
        public void RemoveObject(int x, int y)
        {
            // The area clicked to check for an intersection
            Rectangle remove = new Rectangle(x, y, 2, 2);
            // Remove a spawner
            for (int i = 0; i < NumSpawners; i += 1)
            {
                if (Spawners[i].BoundingBox.Intersects(remove))
                {
                    NumSpawners -= 1;
                    SpawnPoint[] temp = new SpawnPoint[NumSpawners];
                    for (int j = 0; j < i; j += 1)
                    {
                        temp[j] = Spawners[j];
                    }
                    for (int j = i; j < NumSpawners; j += 1)
                    {
                        temp[j] = Spawners[j + 1];
                    }
                    Spawners = temp;
                    return;
                }
            }

            // Remove a Warp Point
            for (int i = 0; i < NumWarps; i += 1)
            {
                if (Warps[i].BoundingBox.Intersects(remove))
                {
                    NumWarps -= 1;
                    Warp[] temp = new Warp[NumWarps];
                    for (int j = 0; j < i; j += 1)
                    {
                        temp[j] = Warps[j];
                    }
                    for (int j = i; j < NumWarps; j += 1)
                    {
                        temp[j] = Warps[j + 1];
                    }
                    Warps = temp;
                    return;
                }
            }

            // Remove a Light Source
            for (int i = 0; i < NumLights; i += 1)
            {
                if (Lights[i].BoundingBox.Intersects(remove))
                {
                    NumLights -= 1;
                    LightSource[] temp = new LightSource[NumLights];
                    for (int j = 0; j < i; j += 1)
                    {
                        temp[j] = Lights[j];
                    }
                    for (int j = i; j < NumLights; j += 1)
                    {
                        temp[j] = Lights[j + 1];
                    }
                    Lights = temp;
                    return;
                }
            }

            // Remove a trigger box
            for (int i = 0; i < NumTriggers; i += 1)
            {
                if (Triggers[i].BoundingBox.Intersects(remove))
                {
                    NumTriggers -= 1;
                    TriggerBox[] temp = new TriggerBox[NumTriggers];
                    for (int j = 0; j < i; j += 1)
                    {
                        temp[j] = Triggers[j];
                    }
                    for (int j = i; j < NumTriggers; j += 1)
                    {
                        temp[j] = Triggers[j + 1];
                    }
                    Triggers = temp;
                    return;
                }
            }
        }

        /// <summary>
        /// Selects an object based on where the mouse clicked
        /// </summary>
        public string SelectObject(int x, int y)
        {
            Rectangle select = new Rectangle(x, y, 2, 2);
            
            // Check spawn points
            for (int i = 0; i < NumSpawners; i += 1)
            {
                if (Spawners[i].BoundingBox.Intersects(select))
                {
                    return Spawners[i].Name;
                }
            }

            // And warps
            for (int i = 0; i < NumWarps; i += 1)
            {
                if (Warps[i].BoundingBox.Intersects(select))
                {
                    return Warps[i].Name;
                }
            }

            // And light sources
            for (int i = 0; i < NumLights; i += 1)
            {
                if (Lights[i].BoundingBox.Intersects(select))
                {
                    return Lights[i].Name;
                }
            }

            // and finally trigger boxes
            for (int i = 0; i < NumTriggers; i += 1)
            {
                if (Triggers[i].BoundingBox.Intersects(select))
                {
                    return Triggers[i].Name;
                }
            }

            return null;
        }

        /// <summary>
        /// Empty's the level of content
        /// </summary>
        public void ClearLevel()
        {
            groundLayer.LayerTiles = new int[groundLayer.Width * groundLayer.Height / 32];
            objects.Clear();
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            Level level = new Level();

            level.AssetName = AssetName;
            level.Width = Width;
            level.Height = Height;
            level.GroundLayerTexture = GroundLayerTexture;
            level.groundLayer = groundLayer;

            return level;
        }

        #endregion

        #region XML Serialisation

        public void Save()
        {
            SaveToDocumentFormat(this, null, "../../../../Level EditorContent/Levels/" + this.Name + ".xml", null);
        }

        public static Level Load(string path)
        {
            return LoadFromDocumentFormat(null, path, null);
        }

        private static Level LoadFromBinaryFormat(string path,
                 IsolatedStorageFile isolatedStorageFolder)
        {
            Level serializableObject = null;

            using (FileStream fileStream =
                   CreateFileStream(isolatedStorageFolder, path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                serializableObject = binaryFormatter.Deserialize(fileStream) as Level;
            }

            return serializableObject;
        }

        private static Level LoadFromDocumentFormat(System.Type[] extraTypes,
                string path, IsolatedStorageFile isolatedStorageFolder)
        {
            Level serializableObject = null;

            using (TextReader textReader =
                   CreateTextReader(isolatedStorageFolder, path))
            {
                XmlSerializer xmlSerializer = CreateXmlSerializer(extraTypes);
                serializableObject = xmlSerializer.Deserialize(textReader) as Level;

            }

            return serializableObject;
        }

        private static void SaveToBinaryFormat(Level serializableObject,
                string path, IsolatedStorageFile isolatedStorageFolder)
        {
            using (FileStream fileStream =
                   CreateFileStream(isolatedStorageFolder, path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, serializableObject);
            }
        }

        private static void SaveToDocumentFormat(Level serializableObject,
                System.Type[] extraTypes, string path,
                IsolatedStorageFile isolatedStorageFolder)
        {
            using (TextWriter textWriter =
                   CreateTextWriter(isolatedStorageFolder, path))
            {
                XmlSerializer xmlSerializer = CreateXmlSerializer(extraTypes);
                xmlSerializer.Serialize(textWriter, serializableObject);
            }
        }

        private static FileStream CreateFileStream(IsolatedStorageFile
                                    isolatedStorageFolder, string path)
        {
            FileStream fileStream = null;

            if (isolatedStorageFolder == null)
                fileStream = new FileStream(path, FileMode.OpenOrCreate);
            else
                fileStream = new IsolatedStorageFileStream(path,
                             FileMode.OpenOrCreate, isolatedStorageFolder);

            return fileStream;
        }

        private static TextReader CreateTextReader(IsolatedStorageFile
                                    isolatedStorageFolder, string path)
        {
            TextReader textReader = null;

            if (isolatedStorageFolder == null)
                textReader = new StreamReader(path);
            else
                textReader = new StreamReader(new IsolatedStorageFileStream(path,
                                          FileMode.Open, isolatedStorageFolder));

            return textReader;
        }

        private static TextWriter CreateTextWriter(IsolatedStorageFile
                                    isolatedStorageFolder, string path)
        {
            TextWriter textWriter = null;

            if (isolatedStorageFolder == null)
                textWriter = new StreamWriter(path);
            else
                textWriter = new StreamWriter(new IsolatedStorageFileStream(path,
                                  FileMode.OpenOrCreate, isolatedStorageFolder));

            return textWriter;
        }

        private static XmlSerializer CreateXmlSerializer(System.Type[] extraTypes)
        {
            Type ObjectType = typeof(Level);

            XmlSerializer xmlSerializer = null;

            if (extraTypes != null)
                xmlSerializer = new XmlSerializer(ObjectType, extraTypes);
            else
                xmlSerializer = new XmlSerializer(ObjectType);

            return xmlSerializer;
        }

        #endregion

    }
}
