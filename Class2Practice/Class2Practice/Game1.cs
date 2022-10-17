using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Class2Practice
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public SpriteFont font;
        public Texture2D spongebob;

        int wmax, hmax;

        public Vector2 spongeboblocation;
        public Vector2 spongebobdirection;
        int spongebobspeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            //TargetElapsedTime = TimeSpan.FromTicks(333333);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("Font");
            spongebob = Content.Load<Texture2D>("spongebobresized");
            spongeboblocation = new Vector2(100, 100);
            spongebobdirection = new Vector2(1, 0);
            spongebobspeed = 200;
            wmax = _graphics.PreferredBackBufferWidth;
            hmax = _graphics.PreferredBackBufferHeight;
        }

        float time;

        protected override void Update(GameTime gameTime)
        {
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            UpdateSpongebobMovement();
            UpdateKeepSpongebobOnScreen();



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, spongeboblocation.ToString(), new Vector2(0, 0), Color.Crimson); ;
            _spriteBatch.Draw(spongebob, spongeboblocation, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateSpongebobMovement()
        {
            spongeboblocation = spongeboblocation + (spongebobdirection * spongebobspeed * time/1000);
        }
        
        private void UpdateKeepSpongebobOnScreen()
        {
            if ((spongeboblocation.X < 0) || (spongeboblocation.X > wmax - spongebob.Width))
            {
                spongebobdirection *= -1;
            }
        }
    }
}