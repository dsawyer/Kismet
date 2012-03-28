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
    public class Reward : LevelObject
    {
        private int amount;
        private string text;
        private string type;
        SpriteFont Font1;
        Vector2 FontPos;
        private Vector2 velocity;
        private bool active;
        float time;
        Vector2 previousCameraPosition;
        float vely = 0;
        
        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public Reward(string p_Type, int p_Amount, Vector2 p_Point)
        {


            Position = p_Point - Camera.Position;
            previousCameraPosition = Camera.Position;
            type = p_Type;
            amount = p_Amount;
            //state = new ActiveState(this);
            active = true;
            Font1 = GV.ContentManager.Load<SpriteFont>("SpriteFont1");

            if (type == "health")
                Text = "+" + amount + " Health";
            else
                Text = "+" + amount + " Manna";
            Random randvel = new Random();
            vely = randvel.Next(1, 3);
            Velocity = new Vector2(0.0f, 0.0f);

        }
         // Properties
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        
      
        /// <summary>
        /// The level the players is on at a point in time
        /// </summary>
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        /// <summary>
        /// The level the players is on at a point in time
        /// </summary>
        public string Type
        {
            get { return type; }
        }

           /// <summary>
        /// The level the players is on at a point in time
        /// </summary>
        public Vector2 Velocity
        {
            get { return velocity; }
             set { velocity = value; }
        }

        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>

        public void Update(GameTime gameTime)
        {
            //Position = new Vector2(Velocity.X, Velocity.Y - vely);
             time += (float)gameTime.ElapsedGameTime.TotalSeconds;
             if (time < 2.0f)
             {
                 Velocity = new Vector2(previousCameraPosition.X - Camera.Position.X, previousCameraPosition.Y - Camera.Position.Y - vely);
                 Position = Position + Velocity;
                 Velocity = new Vector2(0.0f, 0.0f);
                 previousCameraPosition = Camera.Position;
             }
             else
                 Active = false;
        }



        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 FontOrigin = Font1.MeasureString(Text)/ 2;
            // Draw the string
            spriteBatch.DrawString(Font1, Text, Position, Color.White, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
        }
    }
}
