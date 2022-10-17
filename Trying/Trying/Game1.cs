using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Trying
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spritebatch;
        SpriteFont font;
        PacMan pac;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            pac = new PacMan(this);
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
            font = Content.Load<SpriteFont>("Font");
            pac.LoadContent();
        }

        protected override void Update(GameTime gametime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            pac.Update(gametime);

            base.Update(gametime);
        }

        protected override void Draw(GameTime gametime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spritebatch.Begin();
            pac.Draw(spritebatch);
            spritebatch.DrawString(font, $"Check Left Key: {pac.keyboard.WasKeyPressed(Keys.Left)} {pac.keyboard.IsKeyDown(Keys.Left)}\nCheck Speed: {pac.speed}\nCheck Direction: {pac.direction}\nCheck Position: {pac.location}", new Vector2(10, 10), Color.Black);
            spritebatch.End();

            base.Draw(gametime);
        }
    }
}