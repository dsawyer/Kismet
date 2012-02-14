using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace KismetDataTypes
{
    public class Animation
    {
        public string Name;
        public int StartFrame;
        public int EndFrame;
        public string Type;
        public string FilePath;
        public string NextAnimation;
        public int FrameWidth;
        public int FrameHeight;
        public float TimePerFrame;
        public int[] CollisionBounds;
    }
}

