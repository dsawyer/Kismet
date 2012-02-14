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
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Level level01;
        Player player;
        Enemy goblin;
        Enemy goblin1;
        Enemy goblin2;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            level01 = Content.Load<Level>("Levels/Level_01");
            level01.Initialise(Content);
            player = new Player(this.Content, "XML Documents/DanAnimations", level01);
            goblin = new Enemy(this.Content, "XML Documents/GoblinAnimations", level01);
            goblin1 = new Enemy(this.Content, "XML Documents/GoblinAnimations", level01);
            goblin2 = new Enemy(this.Content, "XML Documents/GoblinAnimations", level01);
            player.Position = new Vector2(0.0f, 420.0f);

            goblin.Position = new Vector2(500.0f, 420.0f);
            goblin1.Position = new Vector2(1000.0f, 420.0f);
            goblin2.Position = new Vector2(200.0f, 420.0f);
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            // TODO: Add your update logic here
            CollisionManager.ResolvePlayerStaticCollisions(player, player.Level, gameTime);
            CollisionManager.ResolveCollisions(player, goblin, player.Level, gameTime);
            CollisionManager.ResolveCollisions(player, goblin1, player.Level, gameTime);
            //CollisionManager.ResolveCollisions(player, goblin2, player.Level, gameTime);
            player.Update(gameTime); 
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // Draw the layers and the player
            level01.DrawGround(spriteBatch);
            level01.DrawSurGround(spriteBatch);
            player.Draw(gameTime, spriteBatch);
            goblin.Draw(gameTime, spriteBatch);
            goblin1.Draw(gameTime, spriteBatch);
            //goblin2.Draw(gameTime, spriteBatch);
            level01.DrawForeground(spriteBatch);
           
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
