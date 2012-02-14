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
    public class LevelObjectWriter : GameWriter<LevelObject>
    {
        protected override void Write(ContentWriter output, LevelObject value)
        {
            output.Write(value.Name);
            output.WriteObject<Vector2>(value.Position);
            output.WriteObject<Rectangle>(value.BoundingBox);
            output.Write(value.ImageName);
            output.WriteObject(value.ImageBounds);
            //output.Write(value.IsAnimated);
            //output.Write(value.NumberOfFrames);
        }
    }
}
