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
    public class Player : LevelObject
    {

        #region Declarations

        private const string RIGHT = "right";
        private const string LEFT = "left";
        private const float GRAVITY = 1.0f;
        float time;
        float mannaUpdateTime;
        private KeyboardState keyboardState;

        private PlayerState state;
        private Sprite sprite;
        
        private Rectangle localBounds;
        
        private string direction;
        private Vector2 nextPosition;
        private Vector2 velocity;
        private bool isAlive;
        private int health;
        private int manna = 0;
        private Vector2 checkPoint;
        private bool isOnGround = false;
        private bool isHit = false;
        private float idleTime = 0.2f;
        private string currentMagicItem = "fire";
        private int currentMagicCount = 200;
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
        /// gets and sets the current magic item
        /// </summary>
        public string CurrentMagicItem
        {
            get { return currentMagicItem; }
            set { currentMagicItem = value; }
        }

        /// <summary>
        /// gets and sets the current magic count
        /// </summary>
        public int CurrentMagicCount
        {
            get { return currentMagicCount; }
            set { currentMagicCount = value; }
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
                //Console.WriteLine("reset ");
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
        /// Gets and Sets the check point of the player 
        /// </summary>
        public Vector2 CheckPoint { get { return checkPoint; }
            set { checkPoint = value; } }

        /// <summary>
        /// Gets and Sets the status of the Enemy object 
        /// </summary>
        public bool IsAlive { get { return isAlive; } set { isAlive = value; } }

        /// <summary>
        /// Gets and Sets the health of the player object 
        /// </summary>
        public int Health { get { if (health <= 0)IsAlive = false; return health; } set { health = value; } }
       
        private int mannaRate = 0;


        /// <summary>
        /// Gets and Sets the status of the Enemy object 
        /// </summary>
        public int MannaRate { get { return mannaRate; } set { mannaRate = value; } }
        /// <summary>
        /// Gets and Sets the manna for the player 
        /// </summary>
        /// 
        public int Manna
        {
            get
            {
                if (manna >= 600)
                    return 600;
                else
                    return manna;
            }
            set 
            { 
                manna = value; 
            } 
            
        }
        public int Damage { set { health -= value; } }
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

                return new Rectangle(left, bounds.Top +25, 70, 15);
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
            int min = 4 < GV.Level.NumLights ? 4 : GV.Level.NumLights;

            bool isinLight = false;
            LightSource[] lightarray = GV.Level.Lights;
            Vector2 positionvec = new Vector2(GV.Player.Position.X, GV.Player.Position.Y - (GV.Player.Bounds.Height / 3));

            int min1 = 4 < MagicItemManager.lightCount ? 4 : MagicItemManager.lightCount;
            Vector2[] lightSpells = MagicItemManager.GetLightMagicArray(min1);

            for (int i = 0; i < min1; i += 1)
            {
                Vector2 pVector = positionvec - lightSpells[i];
                float distance = (float)Math.Sqrt((Math.Pow((pVector.X), 2) + Math.Pow((pVector.Y), 2)));
                if (distance <= 200)
                {
                    isinLight = true;
                    break;
                }
                else
                { isinLight = false; }
            }
            
            for (int i = 0; i < min; i++)
            {
                Vector2 pVector = positionvec - lightarray[i].Centre;
                double distance = Math.Sqrt((Math.Pow((pVector.X),2) + Math.Pow((pVector.Y),2)));
                pVector.Normalize();
                // Had to make this change due to what the Direction property actually
                // does, a calculation each time, not returning a set value
                Vector2 normalisedDirection = lightarray[i].Direction;
                normalisedDirection.Normalize();
                float angle = Vector2.Dot(normalisedDirection, pVector);
                if (angle > lightarray[i].IlluminationAngle && (float)distance <= lightarray[i].Radius )
                {
                    isinLight = true;
                    
                }


            }

            if (isinLight)
            {
                MaxLightRadius = 400;
                Rate = 400;
                mannaRate = 20;
            }
            else
            {
                mannaRate = 1;
                MaxLightRadius = 100;
                if (lightRadius + Rate > MaxLightRadius)
                    lightRadius = MaxLightRadius;
            }
            
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
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            
            if (lastButtonState && (keyboardState.IsKeyDown(Keys.F) || gamePadState.IsButtonDown(Buttons.Y)))
            {
                if (CurrentMagicItem == "fire")
                {
                    CurrentMagicItem = "water";
                    CurrentMagicCount = WaterCount;
                }
                else if (CurrentMagicItem == "water")
                {
                    CurrentMagicItem = "earth";
                    CurrentMagicCount = EarthCount;
                }
                else if (CurrentMagicItem == "earth")
                {
                    CurrentMagicItem = "wind";
                    CurrentMagicCount = WindCount;
                }
                else if (CurrentMagicItem == "wind")
                {
                    CurrentMagicItem = "dark";
                    CurrentMagicCount = DarkCount;
                }
                else if (CurrentMagicItem == "dark")
                {
                    CurrentMagicItem = "fire";
                    CurrentMagicCount = FireCount;
                }
               
                lastButtonState = false;
            }
            else if (keyboardState.IsKeyUp(Keys.F) && gamePadState.IsButtonUp(Buttons.Y))
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
        /// resets the players health and coordinates from the checkpoint.
        /// </summary>
        public void ResetPlayer()
        {
            this.state = new IdleState(this);
            this.Direction = GV.RIGHT;
            Sprite.Scale = 1.0f;
            velocity = new Vector2(0, 0);
            Position = CheckPoint;
            IsAlive = true;
            health = 600;
           
        }


        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>
        public float AnalogState
        {
            
            get {
                    keyboardState = Keyboard.GetState();
                    GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
                    if (keyboardState.IsKeyDown(Keys.Right) || gamePadState.IsButtonDown(Buttons.DPadRight))
                    {
                        return 5.0f;
                    }
                    else if (keyboardState.IsKeyDown(Keys.Left) || gamePadState.IsButtonDown(Buttons.DPadLeft))
                    {
                        return -5.0f;
                    }
                    else if (gamePadState.IsButtonDown(Buttons.LeftThumbstickRight) || gamePadState.IsButtonDown(Buttons.LeftThumbstickLeft))
                    {
                        return gamePadState.ThumbSticks.Left.X * 5.0f;
                    }
                    else
                    {
                        return 0.0f;
                    }
            }
        }
        #endregion
        
        #region Inventory

        private int fireCount = 200, earthCount = 300, waterCount = 400, windCount = 500, darkCount = 600, lightCount = 100;
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
        /// <summary>
        /// Gets or Sets for fire Inventory.
        /// </summary>
        public int LightCount { get { return 1; } set { lightCount = value; } }

        public void AddToInventory(string type)
        {
            if (type == "pickupFire")
            {
                  Manna += FireCount; 
            }
            else if (type == "pickupEarth")
            {
                Manna += EarthCount;
            }
            else if (type == "pickupWater")
            {
                Manna += WaterCount;
            }
            else if (type == "pickupWind")
            {
                Manna += WindCount;
            }
            else if (type == "pickupDark")
            {
                Manna += DarkCount;
            }

            if (CurrentMagicItem == "fire")
            {
                CurrentMagicCount = FireCount;
            }
            else if (CurrentMagicItem == "water")
            {
               
                CurrentMagicCount = WaterCount;
            }
            else if (CurrentMagicItem == "earth")
            {
                CurrentMagicCount = EarthCount;
            }
            else if (CurrentMagicItem == "wind")
            {
                CurrentMagicCount = WindCount;
            }
            else if (CurrentMagicItem == "dark")
            {
                CurrentMagicCount = DarkCount;
            }
            
        }

        public bool CheckInventory()
        {
            if (CurrentMagicItem == "fire")
            {
                if (FireCount <= Manna)
                {
                    Manna -= FireCount;
                    CurrentMagicCount = FireCount;
                    return true;
                }
               
            }
            else if (CurrentMagicItem == "earth")
            {
                if (EarthCount <= Manna)
                {
                    Manna -= EarthCount;
                    CurrentMagicCount = EarthCount;
                    return true;
                }
            }
            else if (CurrentMagicItem == "water")
            {
                if (WaterCount <= Manna)
                {
                    Manna -= WaterCount;
                    CurrentMagicCount = WaterCount;
                    return true;
                }
            }
            else if (CurrentMagicItem == "wind")
            {
                if (WindCount <= Manna)
                {
                    Manna -= WindCount;
                    CurrentMagicCount = WindCount;
                    return true;
                }
            }
            else if (CurrentMagicItem == "dark")
            {
                if (DarkCount <= Manna)
                {
                    Manna -= DarkCount;
                    CurrentMagicCount = DarkCount;
                    return true;
                }
            }

            
            
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
            CheckPoint = initialPosition;
            IsAlive = true;
            health = 600;

            CurrentMagicCount = 200;

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
            if (screenLocX < 300)
            {
                Camera.Move(new Vector2(screenLocX - 300, 0));
            }
            if (screenLocY > 420)
            {
                Camera.Move(new Vector2(0, screenLocY - 420));
            }
            if (screenLocY < 320)
            {
                Camera.Move(new Vector2(0, screenLocY - 320));
            }
        }

        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            repositionCamera();
            DirectionCheck();
            ToggleMagicItems();
            int health = Health;
            Velocity = new Vector2(AnalogState, Velocity.Y + GV.GRAVITY);
            Vector2 nextPosition = Position + Velocity;
           
            UpdateRadius();
            state.Update(gameTime);
            Velocity = CollisionManager.ResolvePlayerStaticCollisions(nextPosition, Velocity, MagicItemManager.GetList(), PickUpItemManager.GetList());

            Position = Position + Velocity;
            PreviousBottom = Position.Y;
          
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            mannaUpdateTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (time > 0.5)
            {
                if (keyboardState.IsKeyDown(Keys.C) || gamePadState.IsButtonDown(Buttons.RightTrigger))
                {
                    State = new LightState(this);
                    time = 0;
                }
            }


            if (mannaUpdateTime > 1.0f)
            {
                Manna += MannaRate;
                mannaUpdateTime = 0;
            }
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
