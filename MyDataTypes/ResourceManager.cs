using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace KismetDataTypes
{
    public class ResourceManager
    {

        #region Singleton Handle

        /// <summary>
        /// Handle to the singleton
        /// </summary>
        private static ResourceManager instance;
        /// <summary>
        /// Empty constructor
        /// </summary>
        private ResourceManager() {}
        /// <summary>
        /// Handle to the singleton
        /// </summary>
        public static ResourceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceManager();
                }

                return instance;
            }
        }

        #endregion

        #region Graphics

        /// <summary>
        /// A list of textures that are referred to by a name
        /// </summary>
        private Dictionary<string, Texture2D> textures = new Dictionary<string,Texture2D>();

        /// <summary>
        /// Returns a desired texture
        /// </summary>
        /// <param name="key">The name of the texture</param>
        public Texture2D Texture(string key)
        {
            if (key != null) { return textures[key]; }
            else { return null; }
        }

        /// <summary>
        /// Adds a new texture to the list
        /// </summary>
        /// <param name="key">The name of the new texture</param>
        /// <param name="texture">The texture to be added</param>
        public void Texture(string key, Texture2D texture)
        { textures.Add(key, texture); }

        /// <summary>
        /// Finds out if a certain texture is within the list of textures
        /// </summary>
        /// <param name="key">The key associated with a texture</param>
        public bool ContainsTexture(string key)
        {
            if (textures.ContainsKey(key))
            { return true; }
            else
            { return false; }
        }

        #endregion

        #region Level Objects

        /// <summary>
        /// The player that is currently in use
        /// </summary>
        private Player player;
        /// <summary>
        /// The player that is currently in use
        /// </summary>
        public Player PlayerOne
        {
            get { return player; }
            set { player = value; }
        }

        /// <summary>
        /// A list of levels that are referred to by a name
        /// </summary>
        private Dictionary<string, Level> levels;

        /// <summary>
        /// Returns a desired level
        /// </summary>
        /// <param name="key">The name of the level</param>
        public Level Level(string key)
        { return levels[key]; }

        /// <summary>
        /// The current level being played/modified
        /// </summary>
        private Level level;
        /// <summary>
        /// The current level being played/modified
        /// </summary>
        public Level CurrentLevel
        {
            get { return level; }
            set { level = value; }
        }

        /// <summary>
        /// The current layer being edited
        /// </summary>
        private Layer currentLayer;
        /// <summary>
        /// The current layer being edited
        /// </summary>
        public Layer CurrentLayer
        {
            get { return currentLayer; }
            set { currentLayer = value; }
        }

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialises the singleton's values
        /// </summary>
        /// <param name="currentPlayer">The player object</param>
        /// <param name="currentLevel">The level currently being used</param>
        public void Initialise(Player currentPlayer, Level currentLevel)
        {
            textures = new Dictionary<string, Texture2D>();
            levels = new Dictionary<string, Level>();
            player = currentPlayer;
            level = currentLevel;
        }

        #endregion

    }
}
