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
    public class Enemy : LevelObject
    {


        #region Properties

        private bool isAlive;
        private Sprite sprite;
        private EnemyState state;
        private StateMachine stateMachine;
        public Vector2 velocity;
        protected string direction;
        private Vector2 jumpVelocity;
        private int health;
        public bool animationReversed = false;



        /// <summary>
        /// Gets and Sets the status of the Enemy object 
        /// </summary>
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }

        /// <summary>
        /// Gets and Sets the health of the Enemy object 
        /// </summary>
        public int Health { get { if (health <= 0)IsAlive = false; return health; } set { health = value; } }
        public int Damage { set { health -= value; } }
        /// <summary>
        /// Gets and Sets the Spriteof the Enemy object 
        /// </summary>
        public Sprite Sprite { get { return sprite; } set { sprite = value; } }
        /// <summary>
        /// Gets and Sets the State of the Enemy object.
        /// </summary>
        public EnemyState State { get { return state; } set { state = value; } }
        /// <summary>
        /// Gets and Sets the StateMachine of the object.
        /// </summary>
        public StateMachine StateMachine { get { return stateMachine; } set { stateMachine = value; } }
        /// <summary>
        /// Gets and Sets the Velocity of the object.
        /// </summary>
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
        /// <summary>
        /// Gets and Sets the Direction of the object.
        /// </summary>
        public string Direction {   get { return direction; } 
                                    set
                                    {

                                        if (AnimationReversed)
                                        {
                                            if (this.GetType().ToString() != "KismetDataTypes.ImpFlock")
                                            {
                                                if (value == GV.LEFT)
                                                    Sprite.SpriteEffect = SpriteEffects.None;
                                                else if (value == GV.RIGHT)
                                                    Sprite.SpriteEffect = SpriteEffects.FlipHorizontally;
                                            }
                                            direction = value;
                                        }
                                        else if (!AnimationReversed)
                                        {
                                            if (this.GetType().ToString() != "KismetDataTypes.ImpFlock")
                                            {
                                                if (value == GV.LEFT)
                                                    Sprite.SpriteEffect = SpriteEffects.FlipHorizontally;
                                                else if (value == GV.RIGHT)
                                                    Sprite.SpriteEffect = SpriteEffects.None;
                                            }
                                            direction = value;
                                        }

                                    }
        }

        public bool AnimationReversed { get { return animationReversed; } set { animationReversed = value; } }

        public Vector2 JumpVelocity { get { return jumpVelocity; } set { jumpVelocity = value; } }
        

        #endregion

        #region Static Collisions
        //static collisions
        private float previousBottom;
        // Properties
        public float PreviousBottom { get { return previousBottom; } set { previousBottom = value; } }

    
        #endregion

        #region AI Collisions
        //AI collisions
        private bool collisionDetected = false;
        private bool sightDetected = false;
        private bool isOnGround = false;
        private bool wallDetected = false;
        private bool isHit = false; 
        private bool backStabber = false;
        private bool faceOff = false;

        public bool CollisionDetected
        {
            get
            {
                bool newCollision = collisionDetected;
                collisionDetected = false;
                return newCollision;
            }
            set { collisionDetected = value; }
        }

        public bool SightDetected
        {
            get
            {
                bool newCollision = sightDetected;
                sightDetected = false;
                return newCollision;
            }
            set { sightDetected = value; }
        }

        /// <summary>
        /// Gets or Sets if player is view of enemy.
        /// </summary>
        public bool IsOnGround { get { return isOnGround; } set { isOnGround = value; } }

        /// <summary>
        /// Gets or Sets if player is view of enemy.
        /// </summary>
        public bool WallDetected { get { return wallDetected; } set { wallDetected = value; } }
        /// <summary>
        /// Gets or Sets if player is is hit by an enemy.
        /// </summary>
        public bool IsHit { get { return isHit; } set { isHit = value; } }
        /// <summary>
        /// Gets or Sets if player is is hit by an enemy.
        /// </summary>
        public bool BackStabber { get { return backStabber; } set { backStabber = value; } }
        /// <summary>
        /// Gets or Sets if player is is hit by an enemy.
        /// </summary>
        public bool FaceOff { get { return faceOff; } set { faceOff = value; } }


        #endregion

        #region Constructor
        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public Enemy()
        {}
        #endregion;

        #region Bounds

        private int range;
        /// <summary>
        /// gets and sets the range the enemy can view for a collision
        /// </summary>
        public int Range { get { return range; } set { range = value; } }

       
        /// <summary>
        /// The physical bounding box for the Enemy
        /// </summary>
        public Rectangle getBounds(Vector2 p_Position)
        {
            int left = (int)Math.Round(p_Position.X - Sprite.Origin.X) - (Sprite.CurrentAnimation.FrameWidth / 2) + Sprite.BoundingBox.Left;
            int top = (int)Math.Round(p_Position.Y - sprite.Origin.Y) - (Sprite.CurrentAnimation.FrameHeight) + Sprite.BoundingBox.Top + (Sprite.CurrentAnimation.FrameHeight - Sprite.BoundingBox.Bottom); ;
            return new Rectangle(left, top, Sprite.BoundingBox.Width, Sprite.BoundingBox.Height);
        }

        /// <summary>
        /// The physical bounding box for the enemy
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                int left = (int)Math.Round(Position.X - Sprite.Origin.X) - (Sprite.CurrentAnimation.FrameWidth / 2) + Sprite.BoundingBox.X;
                int top = (int)Math.Round(Position.Y - sprite.Origin.Y) - (Sprite.CurrentAnimation.FrameHeight) + Sprite.BoundingBox.Y + (Sprite.CurrentAnimation.FrameHeight - Sprite.BoundingBox.Bottom); ;
                return new Rectangle(left, top, Sprite.BoundingBox.Width, Sprite.BoundingBox.Height);
            }
        }
        public Rectangle SightRange
        {
            get
            {
                Rectangle bounds = Bounds;
                int left = bounds.Left;
                //int width = left;
                if (Direction == GV.LEFT)
                    left -= Range;
                else if (Direction == GV.RIGHT)
                    left += (bounds.Width);

                return new Rectangle(left, bounds.Top, Range, bounds.Height);
            }


        }


        //float sightRangee;
        /// <summary>
        /// gets and sets the range the enemy can view for a collision
        /// </summary>
       // public int SightRangee { get { return sightRangee; } set { sightRangee = value; } }


        #endregion

        #region Methods
        /// <summary>
        /// function to toggle the direction of the enemy
        /// </summary>
        public void ToggleDirections()
        {
            if (Direction == "left")
                Direction = GV.RIGHT;
            else if (Direction == "right")
                Direction = GV.LEFT;
        }

        public void PositionInTile(Vector2 coordinate)
        {
            Rectangle tileBounds = GV.Level.GetBounds((int)coordinate.X, (int)coordinate.Y);
            Position =  new Vector2(tileBounds.Right + ((tileBounds.Right - tileBounds.Left) / 2), tileBounds.Bottom);
        }

        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>
        /// <param name="p_GameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            int health = Health;
           Velocity = new Vector2(Velocity.X, Velocity.Y + GV.GRAVITY);
            Vector2 nextPosition = Position + Velocity;
            state.Update(gameTime);
            Velocity = CollisionManager.ResolveCollisions(this,nextPosition,Velocity, MagicItemManager.GetList());
            //state.Update(gameTime);
            Position = Position + Velocity;
            PreviousBottom = Position.Y;
           // state.Update(gameTime);
<<<<<<< HEAD
            /*Console.WriteLine(Name + ":");
            Console.WriteLine("X: " + Position.X + "\tY: " + Position.Y);
            Console.WriteLine("" + Velocity.X + " " +  Velocity.Y);*/
=======

           // Console.WriteLine("" + Velocity.X + " " +  Velocity.Y);
>>>>>>> 9596670ad749c1b4f9ce2c5fb1b6a941d267d543
            
        }
        /// <summary>
        /// Handles the drawing of the enemy sprite.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Position = Position;
            sprite.Draw(gameTime, spriteBatch);
            if (GV.ShowBoxes)
            {
                BoundingBox boundBox = new BoundingBox();
                boundBox.Draw(spriteBatch, Bounds, Color.Green);
                boundBox.Draw(spriteBatch, SightRange, Color.Red);


                Circle boundcircle = new Circle(new Vector2 (Position.X, Position.Y - (((float)Sprite.BoundingBox.Bottom - (float)Sprite.BoundingBox.Top))/2), 100);
                boundcircle.Draw(spriteBatch, Color.Green);
     
            }
        }

        #endregion
    }
}
