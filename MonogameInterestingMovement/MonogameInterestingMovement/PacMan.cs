using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameInterestingMovement
{
    public class PacMan
    {
        public Texture2D pacman;
        public Vector2 pacmanposition, pacmandirection, pacmanorigin;
        public float pacmanspeed;
        public int pacmanjump;
        public Color pacmancolor;
        public Keys pacmankey;
        public bool isonground;
        public int ground;
        public string TextureName { get; set; }

        protected Game game;

        public PacMan(Game game)
        {
            this.game = game;
            pacmanjump = -50;
            pacmanspeed = 50;
            pacmancolor = Color.White;
            pacmankey = Keys.Space;
            isonground = true;
            ground = 475; //I know this is bad but I don't know what else to do right now
        }

        public virtual void LoadContent()
        {
            if (string.IsNullOrEmpty(TextureName))
            {
                TextureName = "PacmanSingle";
            }
            pacman = game.Content.Load<Texture2D>(TextureName);

            this.pacmanposition = new Vector2(game.GraphicsDevice.Viewport.Width / 2, (400 - pacman.Height));
            this.pacmandirection = new Vector2(1, 0);
        }

        float time;

        public virtual void Update(GameTime gameTime)
        {
            //Elapsed time since last update will be used to correct movement speed
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            UpdateIsOnGround();
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(pacman, pacmanposition, pacmancolor);
        }

        public void UpdateIsOnGround()
        {
            if (this.pacmanposition.Y == ground - pacman.Height)
            {
                isonground = true;
            }
            else
            {
                isonground = false;
            }
        }
    }
}