using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using KismetDataTypes;

namespace LevelEditor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        IntPtr drawSurface;
        System.Windows.Forms.Form parentForm;
        System.Windows.Forms.PictureBox pictureBox;
        System.Windows.Forms.Control gameForm;

        System.Windows.Forms.VScrollBar vscroll;
        System.Windows.Forms.HScrollBar hscroll;

        bool followPlayer = true;

        public LevelObject currentObject = new LevelObject();
        public string currentObjectKey;
        public MouseState lastMouseState;
        public Vector2 currentMousePosition = Vector2.Zero;
        public Vector2 lastMousePosition = Vector2.Zero;
        public string CurrentCodeValue = "";
        public Vector2 mouseLocationLevel = Vector2.Zero;
        public string MonsterType = "";
        public int numberOfMonsters = 0;
        public int centreX = 0;
        public int centreY = 0;
        public int radius = 0;
        public int brightness = 0;
        public bool addObject = true;

        public int positionX = 0;
        public int positionY = 0;
        public int width = 0;
        public int height = 0;

        public Level level01;
        Player player1;

        public Game1(IntPtr drawSurface, System.Windows.Forms.Form parentForm,
                     System.Windows.Forms.PictureBox surfacePictureBox)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.drawSurface = drawSurface;
            this.parentForm = parentForm;
            this.pictureBox = surfacePictureBox;

            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
            
            Mouse.WindowHandle = drawSurface;

            gameForm = System.Windows.Forms.Control.FromHandle(this.Window.Handle);
            gameForm.VisibleChanged += new EventHandler(gameForm_VisibleChanged);
            gameForm.SizeChanged += new EventHandler(pictureBox_SizeChanged);

            vscroll = (System.Windows.Forms.VScrollBar)parentForm.Controls["vScrollBar1"];
            hscroll = (System.Windows.Forms.HScrollBar)parentForm.Controls["hScrollBar1"];
        }

        #region Event Handlers

        void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = drawSurface;
        }

        private void gameForm_VisibleChanged(object sender, EventArgs e)
        {
            if (gameForm.Visible == true)
            { gameForm.Visible = false; }
        }

        void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            if (parentForm.WindowState != System.Windows.Forms.FormWindowState.Minimized)
            {
                graphics.PreferredBackBufferWidth = pictureBox.Width;
                graphics.PreferredBackBufferHeight = pictureBox.Height;
                
                Camera.ViewPortWidth = pictureBox.Width;
                Camera.ViewPortHeight = pictureBox.Height;
                graphics.ApplyChanges();
            }
        }

        #endregion

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            //graphics.GraphicsDevice.SetRenderTarget(new RenderTarget2D(graphics.GraphicsDevice, 1280, 720));

            //ResourceManager.Instance.Texture("Tiles", Content.Load<Texture2D>(System.IO.Path.Combine(@"Tiles\", "Tiles")));
            GV.ContentManager = Content;
            TDManager.Initialize();
            //level01 = Level.Load("../../../../Level EditorContent/Levels/Level01_A.xml");
            level01 = Content.Load<Level>("Levels/Level_01A");
            level01.Initialise(Content);

            GV.Level = level01;
            GV.SpriteBatch = spriteBatch;

            GV.LEFT = "left";
            GV.RIGHT = "right";
            GV.GRAVITY = 1.0f;
            GV.ShowBoxes = true;

            player1 = new Player("XML Documents/DanAnimations", level01.PlayerStartingPosition);

            GV.Player = player1;

            // Setup the camera
            Camera.WorldRectangle = new Rectangle(0, 0, GV.Level.Width, GV.Level.Height);
            Camera.Position = new Vector2(0, 0);
            Camera.ViewPortWidth = pictureBox.Width;
            Camera.ViewPortHeight = pictureBox.Height;

            lastMouseState = Mouse.GetState();
            pictureBox_SizeChanged(null, null);

            GV.EDITING = true;
            followPlayer = false;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                level01.Save();
                this.Exit();
            }

            // Can zoom around
            if (Keyboard.GetState().IsKeyDown(Keys.I) && Camera.Zoom < 1.5f)
            { Camera.Zoom += 0.05f; }
            if (Keyboard.GetState().IsKeyDown(Keys.K) && Camera.Zoom > 0.5f)
            { Camera.Zoom -= 0.05f; }


            //CollisionManager.ResolvePlayerStaticCollisions(player1, player1.Level, gameTime);

            // Change so the camera follows the player or goes with the scroll bars
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            { followPlayer = true; }

            // if (followPlayer)
            //{ player1.Update(gameTime); }
            //else
            //{ Camera.Position = new Vector2(hscroll.Value, vscroll.Value); }

            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            if (followPlayer)
            {
                GV.Player.Update(gameTime);
                hscroll.Value = (int)Camera.Position.X;
                vscroll.Value = (int)Camera.Position.Y;
            }
            TDManager.Update(gameTime);
            MagicItemManager.Update(gameTime);
            PickUpItemManager.Update(gameTime);
            MouseState ms = Mouse.GetState();
            
            if ((ms.LeftButton == ButtonState.Pressed) && (Keyboard.GetState().IsKeyDown(Keys.LeftControl)))
            {
                // Don't follow the player
                followPlayer = false;
                currentMousePosition = new Vector2(ms.X, ms.Y);
                // Set the new last position
                if (lastMousePosition == Vector2.Zero)
                { lastMousePosition = currentMousePosition; }
                // If the position's are different, then move the camera
                // as well as the scroll bars
                if (currentMousePosition != lastMousePosition)
                {
                    Camera.Move(lastMousePosition - currentMousePosition);
                    lastMousePosition = currentMousePosition;
                    hscroll.Value = (int)Camera.Position.X;
                    vscroll.Value = (int)Camera.Position.Y;
                }
            }
            else if (ms.LeftButton == ButtonState.Released)
            {
                // Reset the last position
                lastMousePosition = Vector2.Zero;
            }
            else if ((ms.X > 0) && (ms.Y > 0) && (ms.X < Camera.ViewPortWidth) && (ms.Y < Camera.ViewPortHeight))
            {
                Vector2 mouseLoc = Camera.ScreenToWorld(new Vector2(ms.X, ms.Y));
                mouseLocationLevel = mouseLoc;
                
                if (Camera.WorldRectangle.Contains((int)mouseLoc.X, (int)mouseLoc.Y))
                {
                    int objectX = ms.X + (int)Camera.Position.X;
                    int objectY = ms.Y + (int)Camera.Position.Y;

                    if (ms.LeftButton == ButtonState.Pressed && addObject)
                    {
                        if (CurrentCodeValue == "Spawner")
                        {
                            //GV.Level.AddSpawnPoint((SpawnPoint)currentObject);
                        }
                        else if (CurrentCodeValue == "Light Source")
                        {
                            //GV.Level.AddLight((LightSource)currentObject);
                        }
                        else if (CurrentCodeValue == "Warp")
                        {
                            //GV.Level.AddWarp((Warp)currentObject);
                        }
                        else if (CurrentCodeValue == "Trigger Box")
                        {
                            //GV.Level.AddTriggerBox((TriggerBox)currentObject);
                        }
                    }
                    /*if (ms.LeftButton == ButtonState.Pressed && !addObject)
                    {
                        currentObjectKey = level01.SelectObject(objectX, objectY);
                        
                        if (currentObjectKey != null)
                        {
                            currentObject = level01.GetObject(currentObjectKey);

                            positionX = (int)currentObject.Position.X;
                            positionY = (int)currentObject.Position.Y;
                            width = currentObject.BoundingBox.Width;
                            height = currentObject.BoundingBox.Height;
                        }
                    }
                    if (ms.RightButton == ButtonState.Pressed)
                    {
                        GV.Level.RemoveObject(objectX, objectY);
                    }*/
                }
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            Matrix cameraTranslation = Matrix.CreateTranslation(-Camera.Position.X, -Camera.Position.Y, 0.0f);
            //Camera.Zoom = 1.25f;
            Matrix cameraZoom = Matrix.CreateScale(Camera.Zoom);
            Matrix cameraTransform = cameraTranslation * cameraZoom;
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default,
                              RasterizerState.CullCounterClockwise, null, cameraTransform);

            // Draw the layers and the player
            GV.Level.Draw(spriteBatch);
            NPCManager.Draw(gameTime, spriteBatch);
            GV.Player.Draw(gameTime, spriteBatch);
            MagicItemManager.Draw(gameTime, spriteBatch);
            PickUpItemManager.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
