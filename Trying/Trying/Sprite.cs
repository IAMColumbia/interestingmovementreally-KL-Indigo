using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Trying
{
    public class Sprite
    {
        protected Game game;

        public float speed;
        public float rotation;
        public int weight;
        public int jump;
        public int ground;
        public bool isonground;
        public Vector2 location, direction, origin;
        public Rectangle defaultrectangle;
        public Texture2D texture;
        public string texturename;

        public Sprite(Game game) 
        {
            this.game = game;
            ground = 490;
            isonground = true;
        }
        
        public virtual void LoadContent()
        {
            if (string.IsNullOrEmpty(texturename))
            {
                texturename = "PacmanSingle";
            }
            texture = game.Content.Load<Texture2D>(texturename);

            this.location = new Vector2(game.GraphicsDevice.Viewport.Width / 2, ground - texture.Height);
            this.direction = new Vector2(1, 0);
            this.origin = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
            defaultrectangle = new Rectangle((int)this.location.X, (int)this.location.Y, (int)this.texture.Width, (int)this.texture.Height);
        }

        float time;

        public virtual void Update(GameTime gt)
        {
            time = (float)gt.ElapsedGameTime.TotalMilliseconds;

            location += (direction * speed) * (time / 1000);
            direction = direction * (time / 1000);
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(this.texture, defaultrectangle, null, Color.White, MathHelper.ToRadians(this.rotation), this.origin, SpriteEffects.None, 0);
        }
    }
}