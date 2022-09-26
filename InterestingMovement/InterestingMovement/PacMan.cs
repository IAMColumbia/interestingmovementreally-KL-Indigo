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
    public class PacMan : Sprite
    {
        enum pacstate { }
        float rotationangle;
        
        public PacMan(Game game) : base(game)
        {

        }

        public override void Update(GameTime gt)
        {
            UpdateKeepPacManOnScreen();
            UpdatePacManSpeed();
            UpdatePacManState();
            base.Update(gt);
        }

        private void UpdateKeepPacManOnScreen()
        {
            if ((this.location.X > this.game.GraphicsDevice.Viewport.Width - this.texture.Width) || (this.location.X < 0))
            {
                this.direction *= new Vector2(-1, 0);
            }
            if ((this.location.Y > this.game.GraphicsDevice.Viewport.Height - this.texture.Height) || (this.location.Y < 0))
            {
                this.direction *= new Vector2(0, -1);
            }
        }

        private void UpdatePacManSpeed()
        {

        }

        private void UpdatePacManState()
        {

        }
    }
}