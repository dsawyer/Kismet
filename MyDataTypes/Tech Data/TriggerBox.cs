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
    public class TriggerBox : LevelObject
    {
        private string type;
        private Rectangle triggerbox;
        private string target;
        
        
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        
        public Rectangle Triggerbox
        {
            get { return triggerbox; }
            set { triggerbox = value; }
        }
         
         public string Target
        {
            get { return target; }
            set { target = value; } 
        }
        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
         public TriggerBox(string p_Type, string p_Target, Rectangle p_Triggerbox)
        {   
             Type = p_Type;
             Target = p_Target;
             Triggerbox = p_Triggerbox;
             ImageBounds = new Rectangle(32, 160, 32, 32);
        }

         public TriggerBox()
         { }
    }
}
