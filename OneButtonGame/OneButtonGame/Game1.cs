//Just so you know, I am using your Sprite class

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace OneButtonGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spritebatch;
        SpriteFont font;
        Random random;
        Vector2 middlesquare;
        Vector2 middlecircle;
        Keys button;
        int score;
        bool madecontact;
        float time;

        Sprite square;
        Sprite circle;

        int squareplacementback;
        int squareplacementforward;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            button = Keys.Space;
            score = 0;
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
            font = this.Content.Load<SpriteFont>("Font");

            square = new Sprite(this) { texture = this.Content.Load<Texture2D>("RedSquare"), Speed = 50 };
            circle = new Sprite(this) { texture = this.Content.Load<Texture2D>("BlackRing"), Speed = 50, Direction = new Vector2(1, 0) };

            squareplacementback = this.GraphicsDevice.Viewport.Width + square.texture.Width;
            squareplacementforward = this.GraphicsDevice.Viewport.Width - square.texture.Width;

            middlesquare = new Vector2(this.GraphicsDevice.Viewport.Width / 2, this.GraphicsDevice.Viewport.Height - square.texture.Height);
            middlecircle = new Vector2(this.GraphicsDevice.Viewport.Width / 2, 100);

            square.position = middlesquare;
            circle.position = middlecircle;
        }

        protected override void Update(GameTime gametime)
        {
            time = (float)gametime.ElapsedGameTime.TotalMilliseconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            circle.KeepMovingAcrossScreen(this);
            UpdateCircleMovement();
            CheckForCollision();
            
            base.Update(gametime);
        }

        protected override void Draw(GameTime gametime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);

            // TODO: Add your drawing code here
            spritebatch.Begin();
            spritebatch.DrawString(font, "test text", new Vector2(10, 10), Color.Black);
            spritebatch.DrawString(font, circle.position.ToString(), new Vector2(10, 30), Color.Black); //test
            spritebatch.DrawString(font, square.position.ToString(), new Vector2(10, 50), Color.Black); //test
            spritebatch.Draw(square.texture, middlesquare, Color.White);
            spritebatch.Draw(circle.texture, middlecircle, Color.White);
            //CheckForCollision();
            if (Keyboard.GetState().IsKeyDown(button))
            {
                square.position = square.position + (new Vector2(0, -1) * square.Speed * (time / 1000));
            }
            spritebatch.End();

            base.Draw(gametime);
        }

        public Vector2 PlaceSquare()
        {
            square.position = new Vector2( random.Next(squareplacementback, squareplacementforward), this.GraphicsDevice.Viewport.Height - square.texture.Height);

            return square.position;
        }

        public void Reset()
        {
            square.position = PlaceSquare();
            score++;
            madecontact = false;
            //Draw(); ?
        }

        public void GameReset()
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);
            square.position = middlesquare;
            circle.position = middlecircle;
            score = 0;
        }

        public void GameOver()
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);
            //Draw Game Over Instructions
            if (Keyboard.GetState().IsKeyDown(button))
            {
                GameReset();
            }
        }

        public void CheckForCollision()
        {
            if (Keyboard.GetState().IsKeyDown(button))
            {
                square.position = square.position + (new Vector2(0, -1) * square.Speed * (time / 1000));

                if (square.Intersects(circle))
                {
                    madecontact = true;
                    Reset();
                }
                else if (square.position.Y <= 0)
                {
                    GameOver();
                }
                else
                {
                    GameOver();
                }
            }
        }

        public void UpdateCircleMovement()
        {
            circle.position = circle.position + (circle.Direction * circle.Speed * (time/1000));
        }
    }
}