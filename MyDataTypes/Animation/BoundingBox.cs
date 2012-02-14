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
    class BoundingBox
    {

        /// <summary>
        /// Get/Set texture.
        /// </summary> 
        public Texture2D Tex
        {
            get { return texture; }
            //set { texture = value; }
        }
        Texture2D texture;

        public Rectangle Box
        {

            get { return box; }
            set { box = value; }
        }
        Rectangle box;

         /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public BoundingBox()
        {
            texture = GV.ContentManager.Load<Texture2D>("Sprites/WhitePixel");
        }//End Constructor


        /// <summary>
        /// Draw a rectangle. 
        /// </summary>
        /// <param name="rectangle">The rectangle to draw.</param>
        /// <param name="color">The draw color.</param>
        public void Draw(SpriteBatch spriteBatch, Rectangle rectangle, Color color)
        {
            spriteBatch.Draw(Tex, new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, 1), color);
            spriteBatch.Draw(Tex, new Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, 1), color);
            spriteBatch.Draw(Tex, new Rectangle(rectangle.Left, rectangle.Top, 1, rectangle.Height), color);
            spriteBatch.Draw(Tex, new Rectangle(rectangle.Right, rectangle.Top, 1, rectangle.Height + 1), color);
        }




    }
}
