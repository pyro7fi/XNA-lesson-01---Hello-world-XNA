// Up here are the using statements
// they just make it so you don't need to type, say, 
//
// Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch;
//
// you just need to type
//
// SpriteBatch spriteBatch;
// 
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

namespace Xbox360Game1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // This is where your global variables are placed
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        SpriteFont font;  // we need this for drawing text to screen (the "@" sign)
        Color xcolor = Color.Black;  // we need this to color the text
        
        float x = 800 / 2;  // we need this to positon the text on the screen
        float y = 480 / 2;  //  we could have gone with a Vector2, but we show
                            // that style for the image drawing instead


        Vector2 mPosition = new Vector2(50, 50); // this positions the image we draw
        Texture2D mSpriteTexture;  // this holds the image that will be drawn

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // You load your game content here

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // We need some kind of SpriteFont in order to draw text to the screen
            font = Content.Load<SpriteFont>("myFont");  
            // You have to right click your project's Content node (it looks like a 
            //  seperate project, below the main one) and choose...
            //  Add -> New Item -> SpriteFont
            //  And be sure to name it "myFont"

 
            // This is our very first texture, we draw this image to the screen!!!
            mSpriteTexture = this.Content.Load<Texture2D>("ArmosBrown1");   // omit the .png extension here
            // You have to right click your project's Content node and choose...
            //   Add -> Existing Item -> Browse to your image file
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
            // Your update logic goes here
            // That includes acting upond controller inputs

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // This code will make your character change colors as you press buttons on the controller
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                xcolor = Color.Green;
            if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
                xcolor = Color.DarkBlue;
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
                xcolor = Color.Red;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
                xcolor = Color.Yellow;
            if (GamePad.GetState(PlayerIndex.One).Buttons.RightStick == ButtonState.Pressed)
                xcolor = Color.Black;

            // This is the code for moving your character arround on the screen
            Vector2 joystick = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            x += joystick.X*8;
            y -= joystick.Y*8;



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Your drawing code goes here
            GraphicsDevice.Clear(Color.CornflowerBlue); // this set's the background color

            // before you can draw with a spriteBatch, you must do .Begin()
            spriteBatch.Begin();

            spriteBatch.DrawString(font, "Hello XNA on XBOX", new Vector2(300, 45), Color.Black);

            // This is where we draw the main character (an 'at' symbol)
            spriteBatch.DrawString(font, "@", new Vector2(x, y), xcolor);


            // Here's where we draw the image
            spriteBatch.Draw(mSpriteTexture, mPosition, Color.White);

            spriteBatch.End();
            // Don't forget to .End() when you're done drawing

            base.Draw(gameTime);
        }
    }
}
