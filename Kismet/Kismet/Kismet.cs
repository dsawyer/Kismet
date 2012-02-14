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

namespace Kismet
{
    /// <summary>
    /// This is the main type for the game
    /// </summary>
    public class Kismet : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Effect shaders;

        public Kismet()
        {
            graphics = new GraphicsDeviceManager(this);
            // Sets the graphics to be in 720p
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            // Opens the game in full screen
            //graphics.IsFullScreen = true;

            Content.RootDirectory = "Content";
        }

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
            GV.ContentManager = Content;
            TDManager.Initialize();
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Old loading method
            GV.Level = GV.ContentManager.Load<Level>("Levels/Level_01");
            // New loading method
            //level = Level.Load("../../../../Kismet Content/Levels/Level01_A.xml");
            GV.Level.Initialise(GV.ContentManager);

            // Load the shaders in the effect file (.fx) and set everything up
            shaders = GV.ContentManager.Load<Effect>("LightEffects");

            GV.SpriteBatch = spriteBatch;

            GV.LEFT = "left";
            GV.RIGHT = "right";
            GV.GRAVITY = 1.0f;
            GV.ShowBoxes = false;

            GV.Player = new Player("XML Documents/DanAnimations", GV.Level.PlayerStartingPosition);
            
            Camera.WorldRectangle = new Rectangle(0, 0, GV.Level.Width, GV.Level.Height);
            Camera.Position = new Vector2(0, 0);
            Camera.ViewPortWidth = 1280;
            Camera.ViewPortHeight = 720;

            GV.EDITING = false;
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
                //level.Save();
                this.Exit();
            }

            // Get the state of the keyboard or the game pad and update the player
            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            GV.Player.Update();
            TDManager.Update();
            MagicItemManager.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // Setup the transform matrix that is used in the shader
            Matrix cameraTranslation = Matrix.CreateTranslation(-Camera.Position.X, -Camera.Position.Y, 0.0f);
            Matrix cameraZoom = Matrix.CreateScale(Camera.Zoom);
            Matrix cameraTransform = cameraTranslation * cameraZoom;

            // Set all the shader's parameters based on the lights in the level
            shaders.Parameters["lightPositions"].SetValue(GV.Level.GetLightPositions());
            shaders.Parameters["lightRadii"].SetValue(GV.Level.GetLightRadii());
            shaders.Parameters["lightBrightness"].SetValue(GV.Level.GetLightBrightness());
            shaders.Parameters["numLights"].SetValue(GV.Level.NumLights);

            //spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default,
            //                  RasterizerState.CullCounterClockwise, null, cameraTransform);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default,
                              RasterizerState.CullCounterClockwise, shaders, cameraTransform);

            // Draw the layers and the player
            GV.Level.Draw(spriteBatch);
            NPCManager.Draw(gameTime, spriteBatch);
            GV.Player.Draw(gameTime, spriteBatch);
            MagicItemManager.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
