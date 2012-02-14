using System;
using Microsoft.Xna.Framework.Content;

namespace KismetDataTypes
{
    /// <summary>
    /// Base type for all data types that are loaded via the content pipeline
    /// </summary>
    public abstract class ContentObject
    {
        /// <summary>
        /// Name of the content pipeline asset that contained this object
        /// </summary>
        private string assetName;

        /// <summary>
        /// Name of the content pipeline asset that contained this object
        /// </summary>
        [ContentSerializerIgnore]
        public string AssetName
        {
            get { return assetName; }
            set { assetName = value; }
        }
    }
}
