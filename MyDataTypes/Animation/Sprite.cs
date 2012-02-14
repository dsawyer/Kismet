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
    public class Sprite
    {
        /// <Time>
        /// The amount of time in seconds that the current frame has been shown for.
        /// </summary>
        private float time;
        public float timePerFrame;
        /// <summary>
        /// Reference to animations from dictionary
        /// </summary>
        Dictionary<string, Animation> animationDictionary = new Dictionary<string, Animation>();
     
        /// <summary>
        /// Current frame of the animation.
        /// </summary>
        int currentFrame;
        public int CurrentFrame { get { return currentFrame; } set { currentFrame = value; } }

        /// <summary>
        /// Current animation of sprite
        /// </summary>
        Animation currentAnimation;
        public Animation CurrentAnimation {get { return currentAnimation; } set { currentAnimation = value; } }
        
        /// <summary>
        /// Add an animation to the dictionary, with the name of animation to be the key
        /// </summary>
        /// <param name="newAnimation"></param>
        private void AddAnimation(Animation newAnimation)
        {
            animationDictionary.Add(newAnimation.Name, newAnimation);
            
        }
        
        /// <summary>
        /// Sets the current animation to be from the dictionary based on name parameter
        /// </summary>
        /// <param name="name"></param>
        public void PlayAnimation(string name)
        { 
            CurrentAnimation = animationDictionary[name];
            this.TimePerFrame = this.CurrentAnimation.TimePerFrame; 
            CurrentFrame = 0;
            int index = CurrentFrame * 4;
            BoundingBox = new Rectangle(CurrentAnimation.CollisionBounds[index], CurrentAnimation.CollisionBounds[index + 1], CurrentAnimation.CollisionBounds[index + 2], CurrentAnimation.CollisionBounds[index + 3]);


        }

        /// <summary>
        /// Get/Set sprite position.
        /// </summary> 
        public Vector2 Position
        {
            get { return new Vector2(position.X - (CurrentAnimation.FrameWidth / 2), position.Y - (CurrentAnimation.FrameHeight) + (CurrentAnimation.FrameHeight -BoundingBox.Bottom)); }
            set { position = value; }
        }
        Vector2 position;
        

       // get { return new Vector2(position.X - (CurrentAnimation.FrameWidth/2),position.Y - CurrentAnimation.FrameHeight); }
        /// <summary>
        /// Get/Set sprite position.
        /// </summary> 
        public Rectangle BoundingBox
        {
            get { return boundingBox; }
            set { boundingBox = value; }
        }
        Rectangle boundingBox;

        /// <summary>
        /// Get/Set sprite position.
        /// </summary> 
        public float TimePerFrame
        {
            get { return timePerFrame; }
            set { timePerFrame = value; }
        }
        /// <summary>
        /// The sprite effect that is used in animation.
        /// </summary>
        public SpriteEffects SpriteEffect
        {
            get { return spriteEffect; }
            set { spriteEffect = value; }
        }
        SpriteEffects spriteEffect = SpriteEffects.None;

        /// <summary>
        /// Gets a texture origin at the bottom center of each frame.
        /// </summary>
        public Vector2 Origin
        {
            get { return new Vector2(0, 0); }
        }

        /// <summary>
        /// Gets a the content from the content manager.
        /// </summary> 
        ContentManager content;
        public ContentManager Content
        {
            get { return content; }
            set { content = value; }
        }
 
        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public Sprite(ContentManager p_Content, string p_XMLFile)
        {
            Content = p_Content;
            //loads the content from the xml file into animationArray
            Animation[] animationArray;
            animationArray = GV.ContentManager.Load<Animation[]>(p_XMLFile);

            //foreach item in xml add the animation to the dictionary
            foreach (Animation newAnimation in animationArray)
            {
                AddAnimation(newAnimation);
            }
        }//End Constructor

        /// <summary>
        /// Draws the sprite.
        /// </summary>
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Process passing time.
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (time > this.CurrentAnimation.TimePerFrame)
            {
                time -= this.TimePerFrame;

                // Advance the frame index; looping or clamping as appropriate.
                if (this.CurrentAnimation.Type == "loop")
                {
                    if (this.CurrentAnimation.EndFrame != 0)
                    { CurrentFrame = (CurrentFrame + 1) % this.CurrentAnimation.EndFrame + 1; }
                }
                else if (this.CurrentAnimation.Type == "playOnce")
                {
                    CurrentFrame = Math.Min(CurrentFrame+1, this.CurrentAnimation.EndFrame);
                }

                if (CurrentFrame == CurrentAnimation.EndFrame)
                {
                    if (CurrentAnimation.NextAnimation != "")
                    {
                        PlayAnimation(CurrentAnimation.NextAnimation);
                    }
                }

            }//End while loop
            int index = CurrentFrame*4;
         
            BoundingBox = new Rectangle(CurrentAnimation.CollisionBounds[index], CurrentAnimation.CollisionBounds[index + 1], CurrentAnimation.CollisionBounds[index + 2], CurrentAnimation.CollisionBounds[index + 3]);
            // Calculate the source rectangle of the current frame.
            Rectangle source = new Rectangle(CurrentFrame * this.CurrentAnimation.FrameWidth, 0, this.CurrentAnimation.FrameWidth, this.CurrentAnimation.FrameHeight);
    
            // Draw the current frame.
            spriteBatch.Draw(this.Content.Load<Texture2D>(this.CurrentAnimation.FilePath), Position, source, Color.White, 0.0f, this.Origin, 1.0f, this.SpriteEffect, 0.0f);

            if (GV.ShowBoxes)
            {
                Rectangle positionBox = new Rectangle((int)Position.X, (int)Position.Y, CurrentAnimation.FrameWidth, CurrentAnimation.FrameHeight);
                BoundingBox boundBox = new BoundingBox();
                boundBox.Draw(spriteBatch, positionBox, Color.Yellow);
         
                
            }
        }//End Draw
    }//End class
}//End namespace
