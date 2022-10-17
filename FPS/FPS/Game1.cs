using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FPS
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager gdm;
        private SpriteBatch spritebatch;

        int offset = 20;
        int howmany = 1000;

        Texture2D PacMan;
        Vector2 initiallocation;
        SpriteFont font;
        FPSComponent fps;

        enum DrawState { expectedlow, expectedhigh }
        DrawState state;

        public Game1()
        {
            gdm = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            fps = new FPSComponent(this, false, false);
            this.Components.Add(fps);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            PacMan = Content.Load<Texture2D>("pacmanSingle");
            initiallocation = new Vector2(35, 35);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spritebatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("Font");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            UpdateDrawState();
            //UpdateMovePacManAtBorder();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spritebatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            spritebatch.DrawString(font, "expected worse outcome", new Vector2(10, 10), Color.Black);
            DrawMultiplePacMen(spritebatch, howmany);
            spritebatch.End();

            //spritebatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque);
            //spritebatch.DrawString(font, "expected better outcome", new Vector2(10, 10), Color.Black);
            //DrawMultiplePacMen(spritebatch, howmany);
            //spritebatch.End();

            base.Draw(gameTime);
        }

        public void UpdateDrawState()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if(state == DrawState.expectedlow)
                {
                    state = DrawState.expectedhigh;
                }
                if(state == DrawState.expectedhigh)
                {
                    state = DrawState.expectedlow;
                }
            }
        }

        int j = 10;
        //public void UpdateMovePacManAtBorder()
        //{
        //    if(initiallocation.X >= 300)
        //    {
        //        initiallocation = new Vector2(35, 35 + i);

        //        i = i + 10;
        //    }
        //}

        protected void DrawMultiplePacMen(SpriteBatch sb, int hm)
        {
            for (int i = 0; i < hm; i++)
            {
                Rectangle r = new Rectangle((int)initiallocation.X + i * offset, (int)initiallocation.Y + i, PacMan.Width, PacMan.Height);
                if (initiallocation.X >= 300)
                {
                    initiallocation = new Vector2(35, 35 + j);

                    j = j + 10;
                }
                spritebatch.Draw(PacMan, r, Color.White);
            }
        }
    }
}