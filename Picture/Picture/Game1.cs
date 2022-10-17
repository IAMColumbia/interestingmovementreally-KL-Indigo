using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Picture
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont font;
        private Texture2D spongebob;
        private Texture2D doomlogo;
        private Texture2D nerdshirt;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            doomlogo = Content.Load<Texture2D>("doomlogoresized");
            nerdshirt = Content.Load<Texture2D>("nerdshirtresized");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.DrawString(font, "Neh neh neh,\nI like Star Wars", new Vector2(450,100), Color.Black);
            _spriteBatch.DrawString(font, "Neh, I know what SDL is ", new Vector2(10, 5), Color.Black);
            

            _spriteBatch.Draw(spongebob, new Vector2(300, 125), Color.White);
            _spriteBatch.Draw(nerdshirt, new Vector2(10, 50), Color.White);
            _spriteBatch.Draw(doomlogo, new Vector2(10, 275), Color.White);

            _spriteBatch.DrawString(font, "What do you mean\nyou've 'never played\nDoom'?", new Vector2(415, 300), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}