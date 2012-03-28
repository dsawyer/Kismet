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
    public class PickUpItem : LevelObject
    {
        private PickUpState state;
        private Sprite sprite;
        private string itemType;

        private bool active;
        public Vector2 velocity;
        private const float GRAVITY = 1.0f;


        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public PickUpItem(string filePath, string p_ItemType, Vector2 p_Point)
        {
            sprite = new Sprite(GV.ContentManager, filePath);
            Sprite.Scale = 0.40f;
            Position = p_Point;
            itemType = p_ItemType;
            state = new ActiveState(this);
            active = true;
        }

        protected string direction;
        public bool animationReversed = false;

        public string Direction
        {
            get { return direction; }
            set
            {
                if (AnimationReversed)
                {
                    if (value == GV.LEFT)
                        Sprite.SpriteEffect = SpriteEffects.None;
                    else if (value == GV.RIGHT)
                        Sprite.SpriteEffect = SpriteEffects.FlipHorizontally;
                    direction = value;
                }
                else if (!AnimationReversed)
                {
                    if (value == GV.LEFT)
                        Sprite.SpriteEffect = SpriteEffects.FlipHorizontally;
                    else if (value == GV.RIGHT)
                        Sprite.SpriteEffect = SpriteEffects.None;
                    direction = value;
                }

            }
        }
        public bool AnimationReversed
        {
            get { return animationReversed; }
            set
            {
                animationReversed = value;
            }
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
        public string ItemType
        {
            get { return itemType; }
        }

        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>
        public Sprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>
        public PickUpState State
        {
            get { return state; }
            set { state = value; }
        }

        private float previousBottom;
        // Properties
        public float PreviousBottom
        {
            get { return previousBottom; }
            set { previousBottom = value; }
        }


        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        private bool isOnGround = false;
        /// <summary>
        /// Gets or Sets if player is on the ground.
        /// </summary>
        public bool IsOnGround
        {
            get { return isOnGround; }
            set { isOnGround = value; }
        }

        private bool isCollision = false;
        /// <summary>
        /// Gets or Sets if player is on the ground.
        /// </summary>
        public bool IsCollision
        {
            get { return isCollision; }
            set { isCollision = value; }
        }

        public bool isLit = false;


        /// <summary>
        /// The physical bounding box for the Enemy
        /// </summary>
        public Rectangle getBounds(Vector2 p_Position)
        {
            int left = (int)Math.Round(p_Position.X - Sprite.Origin.X) - (Sprite.CurrentAnimation.FrameWidth / 2) + Sprite.BoundingBox.Left;
            int top = (int)Math.Round(p_Position.Y - sprite.Origin.Y) - (Sprite.CurrentAnimation.FrameHeight) + Sprite.BoundingBox.Top + (Sprite.CurrentAnimation.FrameHeight - Sprite.BoundingBox.Bottom);
            return new Rectangle(left, top, Sprite.BoundingBox.Width, Sprite.BoundingBox.Height);
        }

        /// <summary>
        /// The physical bounding box for the player
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                int left = (int)Math.Round(Position.X - Sprite.Origin.X) - (Sprite.CurrentAnimation.FrameWidth / 2) + Sprite.BoundingBox.X;
                int top = (int)Math.Round(Position.Y - sprite.Origin.Y) - (Sprite.CurrentAnimation.FrameHeight) + Sprite.BoundingBox.Y + (Sprite.CurrentAnimation.FrameHeight - Sprite.BoundingBox.Bottom);
                return new Rectangle(left, top, Sprite.BoundingBox.Width, Sprite.BoundingBox.Height);
            }
        }

        /// <summary>
        /// function to toggle the direction of the item
        /// </summary>
        public void ToggleDirections()
        {
            if (Direction == "left")
            {
                Direction = GV.RIGHT;

            }
            else if (Direction == "right")
            {
                Direction = GV.LEFT;
            }

        }
        /// <summary>
        /// Handles input, and animates the pickup sprite state etc.
        /// </summary>

        public void Update(GameTime gameTime)
        {
        }



        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Position = Position;

            //new Vector2(positionX, -positionY + 280);
            sprite.Draw(gameTime, spriteBatch);
            if (GV.ShowBoxes)
            {
                BoundingBox boundBox = new BoundingBox();
                boundBox.Draw(spriteBatch, Bounds, Color.Green);

            }
        }
    }
}
