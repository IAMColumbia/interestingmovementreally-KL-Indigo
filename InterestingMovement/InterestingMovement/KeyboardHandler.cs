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
    public class KeyboardHandler
    {
        private KeyboardState previousstate;
        private KeyboardState currentstate;

        public KeyboardHandler()
        {
            previousstate = Keyboard.GetState();
        }

        public bool IsKeyDown(Keys key)
        {
            return (currentstate.IsKeyDown(key));
        }

        public bool IsHoldingKey(Keys key)
        {
            return (currentstate.IsKeyDown(key) && previousstate.IsKeyDown(key));
        }

        public bool WasKeyPressed(Keys key)
        {
            return (currentstate.IsKeyDown(key) && previousstate.IsKeyUp(key));
        }

        public bool HasReleasedKey(Keys key)
        {
            return (currentstate.IsKeyUp(key) && previousstate.IsKeyDown(key));
        }

        public void Update()
        {
            //set our previous state to our new state
            previousstate = currentstate;

            //get our new state
            currentstate = Keyboard.GetState();
        }

        public bool WasAnyKeyPressed()
        {
            Keys[] keyspressed = currentstate.GetPressedKeys();

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