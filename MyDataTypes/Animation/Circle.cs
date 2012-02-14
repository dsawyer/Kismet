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
    class Circle
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

        public float Radius 
        {

            get { return radius; }
            set { radius = value; }
        }
        float radius;

        public Vector2 Position
        {

            get { return position; }
            set { position = value; }
        }
        Vector2 position;

        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public Circle(Vector2 p_Position, float p_Radius)
        {
            Position = p_Position;
            Radius = p_Radius;
            texture = GV.ContentManager.Load<Texture2D>("Sprites/WhitePixel");
        }//End Constructor


        /// <summary>
        /// Draw a rectangle. 
        /// </summary>
        /// <param name="rectangle">The rectangle to draw.</param>
        /// <param name="color">The draw color.</param>
        public void Draw(SpriteBatch spriteBatch, Color color)
        {

            for (int x = -(int)Radius; x <= (int)Radius; x++)
            {
                double y = (Math.Sqrt((Math.Pow(Radius, 2)) - (Math.Pow((float)x, 2)))+ 0.5);

                spriteBatch.Draw(Tex, new Rectangle((int)Position.X - x, (int)Position.Y - (int)y ,1, 1), color);
                spriteBatch.Draw(Tex, new Rectangle((int)Position.X - x, (int)Position.Y + (int)y, 1, 1), color);
            }
           // spriteBatch.Draw(Tex, new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, 1), color);
           // spriteBatch.Draw(Tex, new Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, 1), color);
            //spriteBatch.Draw(Tex, new Rectangle(rectangle.Left, rectangle.Top, 1, rectangle.Height), color);
           // spriteBatch.Draw(Tex, new Rectangle(rectangle.Right, rectangle.Top, 1, rectangle.Height + 1), color);
        }




    }
}
