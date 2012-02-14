﻿using System;
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
    public class Player : LevelObject
    {

        #region Declarations

        private const string RIGHT = "right";
        private const string LEFT = "left";
        private const float GRAVITY = 1.0f;

        private KeyboardState keyboardState;

        private PlayerState state;
        private Sprite sprite;
        
        private Rectangle localBounds;
        
        private string direction;
        private Vector2 nextPosition;
        private Vector2 velocity;
         

        
        private bool isOnGround = false;
        private bool isHit = false;
        private float idleTime = 0.2f;
        private string currentMagicItem = "fire";
        private bool lastButtonState;
        
        // Used to help with testing for platform collision
        private float previousBottom;

        #endregion

        #region Properties

        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>
        public PlayerState State
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
        
         /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>
        public string CurrentMagicItem
        {
            get { return currentMagicItem; }
            set { currentMagicItem = value; }
        }
        
        // Properties
        public string Direction
        {
            get { return direction; }
            set
            {
                if (value == GV.LEFT)
                {
                    Sprite.SpriteEffect = SpriteEffects.FlipHorizontally;
                }
                else if (value == GV.RIGHT)
                {
                    Sprite.SpriteEffect = SpriteEffects.None;
                }
                direction = value;

            }
        }

        // used with the isOnground static collision
        public float PreviousBottom
        {
            get { return previousBottom; }
            set { previousBottom = value; }
        }

        /// <summary>
        /// Sets the Idle time.
        /// </summary>
        public float ResetIdleTime
        {
            set
            {
                Console.WriteLine("reset ");
                idleTime = value; }
        }

        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>
        public bool IdleCheck()
        {
            //is there movement not movement on the thumbstick
            if (AnalogState == 0.0f)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets or Sets if player is on the ground.
        /// </summary>
        public bool IsOnGround
        {
            get { return isOnGround; }
            set { isOnGround = value; }
        }


        /// <summary>
        /// Gets or Sets if player is is hit by an enemy.
        /// </summary>
        public bool IsHit
        {
            get { return isHit; }
            set { isHit = value; }
        }

        /// <summary>
        /// Gets or Sets for player velocity.
        /// </summary>
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

       
        /// <summary>
        /// gets the bounds for the next position.  Used for collisions
        /// </summary>
        /// <param name="p_Position"></param>
        /// <returns></returns>
        public Rectangle getBounds(Vector2 p_Position)
        {
            int left = (int)Math.Round(p_Position.X - Sprite.Origin.X) - (Sprite.CurrentAnimation.FrameWidth / 2) + Sprite.BoundingBox.Left;
            int top = (int)Math.Round(p_Position.Y - sprite.Origin.Y) - (Sprite.CurrentAnimation.FrameHeight) + Sprite.BoundingBox.Top + (Sprite.CurrentAnimation.FrameHeight - Sprite.BoundingBox.Bottom); ;
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
                int top = (int)Math.Round(Position.Y - sprite.Origin.Y) - (Sprite.CurrentAnimation.FrameHeight) + Sprite.BoundingBox.Y + (Sprite.CurrentAnimation.FrameHeight - Sprite.BoundingBox.Bottom); ;
                return new Rectangle(left, top, Sprite.BoundingBox.Width, Sprite.BoundingBox.Height);
            }
        }
        
        public Rectangle AttackBounds
        {
            get
            {
                Rectangle bounds = Bounds;
               
                int left = bounds.Left;
                if (Direction == LEFT)
                    left -= 70;
                else if (Direction == RIGHT)
                    left += (Bounds.Width);

                return new Rectangle(left, bounds.Top, 70, bounds.Height);
            }

        }

        /// <summary>
        /// Gets or Sets for players visability circle bases on this radius.
        /// </summary>
        public float LightRadius {
            get {
                if (lightRadius <= 0)
                    lightRadius = 0;
                
                    
                return lightRadius;
            
            } 
            set {
                lightRadius = value;
            }
        }
        private float lightRadius = 0;

        public void UpdateRadius()
        {
            if ((lightRadius + Rate) < MaxLightRadius)
            {
                lightRadius += Rate;
            }
            else if (lightRadius < MaxLightRadius && lightRadius + Rate > MaxLightRadius)
                lightRadius += MaxLightRadius - lightRadius;

            else 
                lightRadius--;

        }

        /// <summary>
        /// Gets or Sets for player velocity.
        /// </summary>
        public float Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        private float rate;
        /// <summary>
        /// Gets or Sets for players visability circle bases on this radius.
        /// </summary>
        public float MaxLightRadius { get { return maxRadius; } set { maxRadius = value; } }
        private float maxRadius;

        public void ToggleMagicItems()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            
            if (lastButtonState && keyboardState.IsKeyUp(Keys.F))
            {
                if (CurrentMagicItem == "fire")
                {
                    CurrentMagicItem = "earth";
                }
                else if (CurrentMagicItem == "earth")
                {
                    CurrentMagicItem = "water";
                }
                else if (CurrentMagicItem == "water")
                {
                    CurrentMagicItem = "wind";
                }
                else if (CurrentMagicItem == "wind")
                {
                    CurrentMagicItem = "dark";
                }
                else if (CurrentMagicItem == "dark")
                {
                    CurrentMagicItem = "light";
                }
                else if (CurrentMagicItem == "light")
                {
                    CurrentMagicItem = "fire";
                }
                lastButtonState = false;
            }
            else if (keyboardState.IsKeyDown(Keys.F))
            {
                lastButtonState = true;
            }
            else 
            {
                lastButtonState = false;
            }

        }



        public void DirectionCheck()
        {
            if (this.AnalogState > 0.0 && Direction == GV.LEFT )
            {
                this.Direction = GV.RIGHT;
            }
            else if (this.AnalogState < 0.0 && Direction == GV.RIGHT)
            {
                this.Direction = GV.LEFT;
            }
        }


        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>
        public float AnalogState
        {
            
            get { 
                    keyboardState = Keyboard.GetState();
                    if (keyboardState.IsKeyDown(Keys.Right))
                    {
                        return 5.0f;
                    }
                    else if (keyboardState.IsKeyDown(Keys.Left))
                    {
                        return -5.0f;
                    }
                    else
                    {
                        return 0.0f;
                    }
            }
        }
        #endregion
       


        #region Inventory

        private int fireCount = 100, earthCount = 100, waterCount = 100, windCount = 100, darkCount = 100;
        /// <summary>
        /// Gets or Sets for fire Inventory.
        /// </summary>
        public int FireCount { get { return fireCount; } set { fireCount = value; } }
        /// <summary>
        /// Gets or Sets for fire Inventory.
        /// </summary>
        public int EarthCount { get { return earthCount; } set { earthCount = value; } }
        /// <summary>
        /// Gets or Sets for fire Inventory.
        /// </summary>
        public int WaterCount { get { return waterCount; } set { waterCount = value; } }
        /// <summary>
        /// Gets or Sets for fire Inventory.
        /// </summary>
        public int WindCount { get { return windCount; } set { windCount = value; } }
        /// <summary>
        /// Gets or Sets for fire Inventory.
        /// </summary>
        public int DarkCount { get { return darkCount; } set { darkCount = value; } }

        public void AddToInventory(string type)
        {
            if (type == "pickupFire")
            {
                  FireCount +=1; 
            }
            else if (type == "pickupEarth")
            {
                   EarthCount+=1;
            }
            else if (type == "pickupWater")
            {
                    WaterCount+=1;
            }
            else if (type == "pickupWind")
            {
                   WindCount +=1;
            }
            else if (type == "pickupDark")
            {
                    DarkCount +=1;
            }
        }

        public bool CheckInventory(string type)
        {
            if (CurrentMagicItem == "fire")
            {
                if (FireCount > 0)
                {
                    FireCount -= 1;
                    return true;
                }
                else
                {
                    FireCount = 0;
                    return false;
                }
            }
            else if (CurrentMagicItem == "earth")
            {
                if (EarthCount > 0)
                {
                    EarthCount -= 1;
                    return true;
                }
                else
                {
                    EarthCount = 0;
                    return false;
                }
            }
            else if (CurrentMagicItem == "water")
            {
                if (WaterCount > 0)
                {
                    WaterCount -= 1;
                    return true;
                }
                else
                {
                    WaterCount = 0;
                    return false;
                }
            }
            else if (CurrentMagicItem == "wind")
            {
                if (WindCount > 0)
                {
                    WindCount -= 1;
                    return true;
                }
                else
                {
                    WindCount = 0;
                    return false;
                }
            }
            else if (CurrentMagicItem == "dark")
            {
                if (DarkCount > 0)
                {
                    DarkCount -= 1;
                    return true;
                }
                else
                {
                    DarkCount = 0;
                    return false;
                }
            }
            else
                return false;
        }



        #endregion
        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public Player(string p_XMLFile, Vector2 initialPosition)
        {

            sprite = new Sprite(GV.ContentManager, p_XMLFile);
            this.state = new IdleState(this);
            this.Direction = GV.RIGHT;
            Sprite.Scale = 1.0f;
            velocity = new Vector2(0,0);
            Position = initialPosition;


            localBounds = new Rectangle(Sprite.BoundingBox.Left, Sprite.BoundingBox.Top, Sprite.BoundingBox.Width, Sprite.BoundingBox.Height);
        }

        // Repositions the camera based on the player's position in the world
        private void repositionCamera()
        {
            int screenLocX = (int)Camera.WorldToScreen(Position).X;
            int screenLocY = (int)Camera.WorldToScreen(Position).Y;
            if (screenLocX > 540)
            {
                Camera.Move(new Vector2(screenLocX - 540, 0));
            }
            if (screenLocX < 240)
            {
                Camera.Move(new Vector2(screenLocX - 240, 0));
            }
            if (screenLocY > 100)
            {
                Camera.Move(new Vector2(0, screenLocY - 100));
            }
            if (screenLocY < 60)
            {
                Camera.Move(new Vector2(0, screenLocY - 60));
            }
        }

        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>

        public void Update(GameTime gameTime)
        {
            repositionCamera();
            DirectionCheck();
            ToggleMagicItems();

            Velocity = new Vector2(AnalogState, Velocity.Y + GV.GRAVITY);
            Vector2 nextPosition = Position + Velocity;
            //localBounds = new Rectangle(Sprite.BoundingBox.Left, Sprite.BoundingBox.Top, Sprite.BoundingBox.Width, Sprite.BoundingBox.Height);
            UpdateRadius();
            state.Update(gameTime);
            Velocity = CollisionManager.ResolvePlayerStaticCollisions(nextPosition, Velocity, MagicItemManager.GetList(), PickUpItemManager.GetList());
            //IsHit = false;
            //we want to look at the next move.  Adjusts velocity accordingly
            //NextPosition = Position + Velocity;
            Position = Position + Velocity;
            PreviousBottom = Position.Y;
            
            
            

           
          
            //Velocity = new Vector2(this.Velocity.X, this.Velocity.Y + GV.GRAVITY);
            //state.Update();
        }



        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            sprite.Position = Position;

            //new Vector2(positionX, -positionY + 280);
            sprite.Draw(gameTime, spriteBatch);
            if (GV.ShowBoxes)
            {
                Rectangle positionBox = new Rectangle((int)Position.X, (int)Position.Y,10,10);
                BoundingBox boundBox = new BoundingBox();
                //boundBox.Draw(spriteBatch, Bounds, Color.Green);
                boundBox.Draw(spriteBatch, AttackBounds, Color.Blue);
                boundBox.Draw(spriteBatch, getBounds(Position+Velocity), Color.Blue);
                boundBox.Draw(spriteBatch, positionBox, Color.Yellow);


                Circle boundcircle = new Circle(new Vector2(Position.X, Position.Y - (((float)Sprite.BoundingBox.Bottom - (float)Sprite.BoundingBox.Top)) / 2), lightRadius);
                boundcircle.Draw(spriteBatch, Color.Green);
            }
        }
    }
}
