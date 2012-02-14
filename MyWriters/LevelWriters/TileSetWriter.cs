using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using KismetDataTypes;

namespace MyWriters
{
    /// <summary>
    /// Added piece for the XNA Framework Content Pipeline
    /// to write the data into a binary .xnb format.
    /// </summary>
    [ContentTypeWriter]
    public class TileSetWriter : GameWriter<TileSet<Texture2DContent>>
    {
        protected override void Write(ContentWriter output, TileSet<Texture2DContent> value)
        {
            output.Write(value.TilesWide);
            output.Write(value.TilesHigh);
            output.WriteRawObject(value.Tileset);
            output.WriteObject(value.Tiles);
        }
    }
}
