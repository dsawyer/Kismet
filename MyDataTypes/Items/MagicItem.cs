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
    public class MagicItem : LevelObject
    {
        private MagicState state;
        private Sprite sprite;
        private string itemType;
        private int duration;
        private bool active;
        public Vector2 velocity;
        private const float GRAVITY = 1.0f;
        private string owner;
        LightSource light;
        float effectRadius;
        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public MagicItem(string filePath,string owner, string p_ItemType, int p_Duration, Enemy enemy)
        {
            Enemy = enemy;
            Owner = owner;
            sprite = new Sprite(GV.ContentManager, filePath);
            Sprite.Scale = 1.0f;
            if (Owner != "player")
            {
                if (p_ItemType == "arrow")
                {
                    this.state = new ArrowState(this);
                    Position = new Vector2(enemy.Position.X, enemy.Position.Y -9) ;
                    Velocity = new Vector2((GV.Player.Position.X - enemy.Position.X) / 20, (GV.Player.Position.Y - enemy.Position.Y)/20); 
                    Direction = enemy.Direction;
                    Sprite.Rotation = 0.0f;
                    itemType = p_ItemType;
                    
                }
                else if (p_ItemType == "fireRow")
                {
                        this.state = new FireState(this);
                        //Position = new Vector2(enemy.Position.X, enemy.Position.Y);
                        //Direction = enemy.Direction;
                        light = new LightSource((int)Position.X, (int)Position.Y, (int)Position.X, (int)Position.Y, 200, 2);
                        itemType = p_ItemType;
                }
                else if (p_ItemType == "egg")
                {
                        Position = Enemy.Position;
                        this.state = new EggState(this);
                        
                        light = new LightSource((int)Position.X, (int)Position.Y, (int)Position.X, (int)Position.Y, 200, 2);
                        

                        itemType = "light";
                    
                    //Position = new Vector2(enemy.Position.X, enemy.Position.Y);
                    //Direction = enemy.Direction;
                }
            }
            else
            {
                this.state = new InAirState(this);
                Position = GV.Player.Position;

               if (p_ItemType == "light")
               {
                    light = new LightSource((int)Position.X, (int)Position.Y, (int)Position.X, (int)Position.Y, 200, 2);
                    EffectRadius = light.Radius;
                }
                else if (p_ItemType == "dark")
                {
                    EffectRadius = 100.0f;
                }
                else
                    EffectRadius = 0.0f;

                //this.state = new InAirState(this);
                //Position = GV.Player.Position;
                itemType = p_ItemType;
            }

            
           
            Duration = p_Duration; 
            active = true;
        }


        /// <summary>
        /// The level the players is on at a point in time
        /// </summary>
        public LightSource Light
        {
            get { return light; }
            set { light = value; }
        }
        private Enemy enemy;
        /// <summary>
        /// The level the players is on at a point in time
        /// </summary>
        public Enemy Enemy
        {
            get { return enemy; }
            set { enemy = value; }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
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
        /// The level the players is on at a point in time
        /// </summary>
        public int Duration
        {
            get { return duration; }
            set {  duration = value; }
        }
        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>
        public MagicState State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>
        public Sprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
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

        /// <summary>
        /// Gets or Sets effect radius of the magic item
        /// </summary>
        public float EffectRadius
        {
            get { return effectRadius; }
            set { effectRadius = value; }
        }

        // The bounding box of the image
        private Rectangle localBounds;


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
        /// Handles input, and animates the player sprite.
        /// </summary>

        public void Update(GameTime gameTime)
        {
            Velocity = new Vector2(Velocity.X, Velocity.Y + GV.GRAVITY);
            Vector2 nextPosition = Position + Velocity;
            state.Update(gameTime);
            

            Velocity = CollisionManager.ResolveMagicStaticCollisions(this, nextPosition, Velocity, MagicItemManager.GetList());

            Position = Position + Velocity;

            if (itemType == "light")
            {
                light.Position = Position;
                light.Centre = Position;
                light.Centre = new Vector2(Position.X, Position.Y - 32);
                //Console.WriteLine("light x" + light.Position.X + " y " + light.Position.X);

            }
            
            PreviousBottom = Position.Y;

            //if (IsCollision)
            //{
            //    Active = false;
            //} 
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

                if (itemType == "light")
                {
                    Circle boundcircle = new Circle(new Vector2(Position.X, Position.Y - (((float)Sprite.BoundingBox.Bottom - (float)Sprite.BoundingBox.Top)) / 2), Light.Radius);
                    boundcircle.Draw(spriteBatch, Color.Green);
                }
            }
        }
    }
}
