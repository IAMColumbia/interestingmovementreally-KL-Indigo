using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace InterestingMovement
{
    public class Sprite
    {
        private string TextureName;

        public string texturename
        {
            get
            {
                return TextureName;
            }
            set
            {
                TextureName = value;
            }
        }
        protected Game game;
        protected float speed;
        protected float rotation;
        protected Vector2 location;
        protected Vector2 direction;
        protected Vector2 origin;
        protected Rectangle defaultrectangle;
        protected Texture2D texture;

        public Sprite(Game game)
        {
            this.game = game;
            defaultrectangle = new Rectangle((int)this.location.X, (int)this.location.Y, (int)this.texture.Width, (int)this.texture.Height);
        }

        public virtual void LoadContent()
        {
            if (string.IsNullOrEmpty(TextureName))
            {
                texture = game.Content.Load<Texture2D>(TextureName);
            }

            this.location = new Vector2(game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2);
            this.direction = new Vector2(0, 0);
            this.origin = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
        }

        float time;
        
        public virtual void Update(GameTime gt)
        {
            time = (float)gt.ElapsedGameTime.TotalMilliseconds;
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(this.texture, defaultrectangle, null, Color.White, MathHelper.ToRadians(this.rotation), this.origin, SpriteEffects.None, 0);
        }
    }
}