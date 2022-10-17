using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MonogameInterestingMovement
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spritebatch;
        KeyboardHandler inputhandler;

        Vector2 gravitydirection;
        float gravityacceloration;
        float friction;
        string text;

        PacMan yellowpac;
        PacMan redpac;
        PacMan bluepac;
        PacMan blackpac;
        PacMan pinkpac;

        List<PacMan> pacmen;

        SpriteFont font;
        Vector2 directionsposition;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            inputhandler = new KeyboardHandler();

            yellowpac = new PacMan(this);
            redpac = new PacMan(this) { pacmancolor = Color.DarkRed, pacmankey = Keys.S};
            bluepac = new PacMan(this) { pacmancolor = Color.DarkBlue, pacmankey = Keys.A };
            blackpac = new PacMan(this) { pacmancolor = Color.Black, pacmankey = Keys.D };
            pinkpac = new PacMan(this) { pacmancolor = Color.DarkOrchid, pacmankey = Keys.F };

            pacmen = new List<PacMan>();

            pacmen.Add(yellowpac);
            pacmen.Add(redpac);
            pacmen.Add(bluepac);
            pacmen.Add(blackpac);
            pacmen.Add(pinkpac);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spritebatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            foreach (var item in pacmen)
            {
                item.pacman = Content.Load<Texture2D>("PacmanSingle");
                item.isonground = true;
            }

            yellowpac.pacmanposition = new Vector2(GraphicsDevice.Viewport.Width / 2, (yellowpac.ground - yellowpac.pacman.Height));
            redpac.pacmanposition = new Vector2(GraphicsDevice.Viewport.Width / 3, (yellowpac.ground - redpac.pacman.Height));
            bluepac.pacmanposition = new Vector2(GraphicsDevice.Viewport.Width / 5, (yellowpac.ground - bluepac.pacman.Height));
            blackpac.pacmanposition = new Vector2(GraphicsDevice.Viewport.Width - (blackpac.pacman.Width + 100), (yellowpac.ground - yellowpac.pacman.Height));
            pinkpac.pacmanposition = new Vector2(GraphicsDevice.Viewport.Width - (pinkpac.pacman.Width + 200), (yellowpac.ground - pinkpac.pacman.Height));

            font = Content.Load<SpriteFont>("Font");
            directionsposition = new Vector2(graphics.PreferredBackBufferWidth - 400, 10);
            text = "Use the Left and Right arrows to move.\nUse the Space bar to jump.\nTry to make them do a little Cha-Cha Slide.";

            gravitydirection = new Vector2(0, 1);
            gravityacceloration = 50.0f;
            friction = 20.0f;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // TODO: Add your update logic here
            foreach (var item in pacmen)
            {
                item.pacmandirection += (gravitydirection * gravityacceloration) * (time / 1000);
            }

            UpdateKeyboardInput(gameTime);
            UpdateKeepPacmenOnScreen();
            UpdatePacmenOnGround();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spritebatch.Begin();
            foreach (var item in pacmen)
            {
                spritebatch.Draw( item.pacman, item.pacmanposition, item.pacmancolor );
            }
            spritebatch.DrawString(font, text, directionsposition, Color.Black);
            spritebatch.End();

            base.Draw(gameTime);
        }

        private void UpdateKeyboardInput(GameTime gametime)
        {
            inputhandler.Update();
            float time = (float)gametime.ElapsedGameTime.TotalMilliseconds;
            foreach (var item in pacmen)
            {
                if(inputhandler.WasKeyPressed(Keys.Space) && item.isonground == true)
                {
                    item.pacmandirection += new Vector2(0, item.pacmanjump);
                    item.isonground = false;

                    //item.pacmanposition += new Vector2(50, 50);
                }

                if(item.isonground == false)
                {
                    item.pacmanposition += (item.pacmandirection * (time / 1000));
                }

                if(item.isonground == true)
                {
                    if (inputhandler.IsHoldingKey(Keys.Left))
                    {
                        item.pacmandirection.X = (item.pacmandirection.X - friction);
                        item.pacmanposition.X += (item.pacmandirection.X * (time / 1000));
                    }
                    if (inputhandler.IsHoldingKey(Keys.Right))
                    {
                        item.pacmandirection.X = (item.pacmandirection.X + friction);
                        item.pacmanposition.X += (item.pacmandirection.X * (time / 1000));
                    }
                }
            }
        }

        public void UpdateKeepPacmenOnScreen() //This might not be the correct place to put this but I've already gone this far
        {
            foreach (var item in pacmen)
            {
                if(item.pacmanposition.X > GraphicsDevice.Viewport.Width - item.pacman.Width || item.pacmanposition.X < 0)
                {
                    item.pacmandirection = item.pacmandirection * new Vector2(-1, 1);
                }
            }
        }

        public void UpdatePacmenOnGround()
        {
            foreach (var item in pacmen)
            {
                if (item.pacmanposition.Y >= (item.ground - item.pacman.Height))
                {
                    item.isonground = true;
                    item.pacmandirection = new Vector2(1, 0);
                }
            }
        }
    }
}