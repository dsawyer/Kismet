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
    public class LevelWriter : GameWriter<Level>
    {
        protected override void Write(ContentWriter output, Level value)
        {
            output.Write(value.Name);
            output.Write(value.Width);
            output.Write(value.Height);
            output.Write(value.GroundLayerTexture);
            output.WriteObject(value.GroundLayerValues);
            output.Write(value.ForegroundLayerTexture);
            output.WriteObject(value.ForegroundLayerValues);
        }
    }
}
