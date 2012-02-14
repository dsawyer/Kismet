using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace KismetDataTypes
{
    public static class GV
    {
            public static GraphicsDeviceManager Graphic;
            public static SpriteBatch SpriteBatch;
            public static SpriteFont SpriteFont;
            public static ContentManager ContentManager;
            public static Level Level;
            public static Player Player;
            public static GameTime Gametime;
            public static string LEFT;
            public static string RIGHT;
            public static float GRAVITY;
            public static bool EDITING;
            public static bool ShowBoxes;
            public static bool ShowGrid = false;
    } 
}
