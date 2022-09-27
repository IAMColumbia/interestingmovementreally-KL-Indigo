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
    public class InputHandler
    {
        private KeyboardState previousstate;
        private KeyboardState currentkeyboardstate;

        public InputHandler()
        {
            previousstate = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            return (currentkeyboardstate.IsKeyDown(key));
        }

        public bool IsHoldingKey(Keys key)
        {
            return (currentkeyboardstate.IsKeyDown(key) && previousstate.IsKeyDown(key));
        }

        public bool WasKeyPressed(Keys key)
        {
            return (currentkeyboardstate.IsKeyDown(key) && previousstate.IsKeyUp(key));
        }

        public bool HasReleasedKey(Keys key)
        {
            return (currentkeyboardstate.IsKeyUp(key) && previousstate.IsKeyDown(key));
        }

        public void Update()
        {
            //set our previous state to our new state
            previousstate = currentkeyboardstate;

            //get our new state
            currentkeyboardstate = Keyboard.GetState();
        }

        public bool WasAnyKeyPressed()
        {
            Keys[] keyspressed = currentkeyboardstate.GetPressedKeys();

            if (keyspressed.Length > 0)
            {
                foreach (Keys k in keyspressed)
                {
                    if (previousstate.IsKeyUp(k))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}