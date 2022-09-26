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
        public enum pacstate { basic, floating, rotating }
        pacstate currentstate;
        KeyboardHandler keyboard;
        float rotationangle;
        public bool isonground;
        public int ground;

        public PacMan(Game game) : base(game)
        {
            texture = game.Content.Load<Texture2D>("PacmanSingle");
            ground = 475;
            jump = 20;
        }

        public override void Update(GameTime gt)
        {
            UpdateKeepPacManOnScreen();
            //UpdatePacManSpeed();
            UpdatePacManIsOnGround();
            UpdateKeyboardInput(gt);
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
            switch (currentstate)
            {
                case pacstate.basic:
                    if (keyboard.WasKeyPressed(Keys.Space) && this.isonground == true)
                    {
                        this.direction += new Vector2(0, this.jump);
                        this.isonground = false;
                    }

                    //
                    break;

                case pacstate.floating:
                    //
                    //
                    break;
                case pacstate.rotating:
                    //
                    //
                    break;
            }
        }

        public void UpdatePacManIsOnGround()
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

        private void UpdateKeyboardInput(GameTime gametime)
        {
            keyboard.Update();

            if (keyboard.WasKeyPressed(Keys.Down))
            {
                this.direction += new Vector2(0, 1);
            }
            if (keyboard.WasKeyPressed(Keys.Up))
            {
                this.direction += new Vector2(0, -1);
            }
            if (keyboard.WasKeyPressed(Keys.Right))
            {
                this.direction += new Vector2(1, 0);
            }
            if (keyboard.WasKeyPressed(Keys.Left))
            {
                this.direction += new Vector2(-1, 0);
            }

            if (keyboard.WasKeyPressed(Keys.B))
            {
                currentstate = pacstate.basic;
            }
            if (keyboard.WasKeyPressed(Keys.F))
            {
                currentstate = pacstate.floating;
            }
            if (keyboard.WasKeyPressed(Keys.R))
            {
                currentstate = pacstate.rotating;
            }
        }
    }
}