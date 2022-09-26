using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InterestingMovement
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spritebatch;
        //KeyboardHandler keyboard;
        SpriteFont font;
        PacMan pac;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spritebatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gametime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }  

            float time = (float)gametime.ElapsedGameTime.TotalMilliseconds;
            //UpdateKeyboardInput(gametime);

            base.Update(gametime);
        }

        protected override void Draw(GameTime gametime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spritebatch.Begin();
            //
            _spritebatch.End();

            base.Draw(gametime);
        }

        
    }
}