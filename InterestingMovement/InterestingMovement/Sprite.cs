using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        protected Texture2D texture;

        public Sprite(Game game)
        {
            this.game = game;
        }

        public virtual void Draw()
        {

        }

        public virtual void LoadContent()
        {

        }

        public virtual void Update()
        {

        }
    }
}