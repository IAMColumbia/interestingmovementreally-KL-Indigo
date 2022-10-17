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
    public class PacMan : Sprite
    {
        public enum pacstate { basic, floating, rotating }
        pacstate currentstate;
        public InputHandler keyboard;

        public PacMan(Game game) : base(game)
        {
            keyboard = new InputHandler();
            speed = 20;
            jump = 20;
            weight = 10;
            currentstate = pacstate.basic;
        }

        public override void Update(GameTime gt)
        {
            //UpdatePacManState();
            UpdateKeepPacManOnScreen();
            UpdateIsOnGround();
            UpdateKeyboardInput(gt);
            UpdatePacmanSpeed();

            base.Update(gt);
        }

        public void UpdatePacManState()
        {

        }

        public void UpdateKeepPacManOnScreen()
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

        public void UpdateKeyboardInput(GameTime gt)
        {
            float time = (float)gt.ElapsedGameTime.TotalMilliseconds;

            keyboard.Update();
            
            if (keyboard.WasKeyPressed(Keys.Down) || keyboard.IsKeyDown(Keys.Down))
            {
                this.direction += new Vector2(0, 1);
                this.location.Y += this.direction.Y * (time / 1000);
            }
            if (keyboard.WasKeyPressed(Keys.Up) || keyboard.IsKeyDown(Keys.Up))
            {
                this.direction += new Vector2(0, -1);
                this.location.Y += this.direction.Y * (time / 1000);
            }
            if (keyboard.WasKeyPressed(Keys.Right) || keyboard.IsKeyDown(Keys.Right))
            {
                this.direction += new Vector2(1, 0);
                this.location.X += this.direction.X * (time / 1000);
            }
            if (keyboard.WasKeyPressed(Keys.Left) || keyboard.IsKeyDown(Keys.Left))
            {
                this.direction += new Vector2(-1, 0);
                this.location.X += this.direction.X * (time / 1000);
            }

            //normalize vector
            if (this.direction.Length() >= 1.0)
            {
                this.direction.Normalize();
            }
        }

        public void UpdatePacmanSpeed()
        {
            if (keyboard.WasAnyKeyPressed() == true)
            {
                this.speed = 200;
            }
            else
            {
                this.speed = 0;
            }
        }

        public void UpdateIsOnGround()
        {
            if (this.location.Y == ground - this.texture.Height)
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