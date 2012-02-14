using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KismetDataTypes
{
    /// <summary>
    /// Base class for objects that appear in a level
    /// </summary>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "KismetDataTypes.LevelObject")]
    [System.Xml.Serialization.XmlRootAttribute("LevelObject", Namespace = "KismetDataTypes.LevelObject", IsNullable = false)]
    public class LevelObject
    {

        #region Description

        /// <summary>
        /// Name of the object
        /// </summary>
        private string name;
        /// <summary>
        /// Name of the object
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// The object's position in the level
        /// </summary>
        private Vector2 position;
        /// <summary>
        /// The object's position in the level
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Position")]
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// The bounds of the object
        /// </summary>
        private Rectangle bounds;
        /// <summary>
        /// The bounds of the object
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("BoundingBox")]
        public Rectangle BoundingBox
        {
            get { return bounds; }
            set { bounds = value; }
        }

        #endregion

        #region Constructors

        public LevelObject() {}

        /// <summary>
        /// Base constructor, mainly used for the entrance object
        /// </summary>
        /// <param name="x">X position of the entrance</param>
        /// <param name="y">Y position of the entrance</param>
        public LevelObject(string name, int x, int y)
        {
            int posX = x - (32 / 2);
            int posY = y - (32 / 2);

            Name = name;
            Position = new Vector2(posX, posY);
            BoundingBox = new Rectangle(posX, posY, 32, 32);
        }

        /// <summary>
        /// Base constructor for level objects
        /// </summary>
        /// <param name="name">Name of the level object</param>
        /// <param name="x">X position of the level object</param>
        /// <param name="y">Y position of the level object</param>
        /// <param name="width">Width of the level object</param>
        /// <param name="height">Height of the level object</param>
        public LevelObject(string name, int x, int y, int width, int height)
        {
            int posX = x - (width / 2);
            int posY = y - (height / 2);

            Name = name;
            Position = new Vector2(posX, posY);
            BoundingBox = new Rectangle(posX, posY, width, height);
        }

        #endregion

        #region Graphics

        /// <summary>
        /// The name of the file used to represent the graphics of the object
        /// </summary>
        private string imageName;
        /// <summary>
        /// The name of the file used to represent the graphics of the object
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ImageName")]
        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }

        /// <summary>
        /// The area in the image file that represents the object
        /// </summary>
        private Rectangle imageBounds;
        /// <summary>
        /// The area in the image file that represents the object
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("ImageBounds")]
        public Rectangle ImageBounds
        {
            get { return imageBounds; }
            set { imageBounds = value; }
        }

        /*
        /// <summary>
        /// Says whether the object has more than one graphic 
        /// associated with it, has multiple frames
        /// </summary>
        private bool isAnimated;
        /// <summary>
        /// Says whether the object has more than one graphic 
        /// associated with it, has multiple frames
        /// </summary>
        public bool IsAnimated
        {
            get { return isAnimated; }
            set { isAnimated = value; }
        }

        private int numberOfFrames;
        public int NumberOfFrames
        {
            get
            {
                if (IsAnimated) { return numberOfFrames; }
                else { return 1; }
            }
            set { numberOfFrames = value; }
        }*/

        #endregion

        #region Draw

        public void Draw(SpriteBatch spriteBatch)
        {
            if (spriteBatch == null)
            {
                throw new ArgumentNullException("spriteBatch");
            }

            Rectangle destinationRect = BoundingBox;

            Rectangle source = ImageBounds;
            // A few nonsensical stand ins for the objects
            /*if (Name == "Warp")
            {
                source.Height = 64;
                destinationRect.Height = 64;
                source.X = 224;
            }
            else if (Name == "Spawner")
            {
                source.X = 224;
            }
            else if (Name == "Light")
            {
                source.X = 128;
                source.Y = 128;
            }*/

            spriteBatch.Draw(ResourceManager.Instance.Texture("Tiles"), destinationRect, source, Color.White);
        }

        #endregion

    }
}
