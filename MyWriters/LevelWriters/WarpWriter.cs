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
    [ContentTypeWriter]
    public class WarpWriter : GameWriter<Warp>
    {
        protected override void Write(ContentWriter output, Warp value)
        {
            output.Write(value.Name);
            output.WriteObject<Vector2>(value.Position);
            output.WriteObject<Rectangle>(value.BoundingBox);
            output.Write(value.ImageName);
            output.WriteObject(value.ImageBounds);
            output.Write(value.DestinationLevel);
            output.WriteObject<Vector2>(value.TargetPosition);
        }
    }
}
