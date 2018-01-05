using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace Subterranea {
    public class InputManager {
        public KeyboardState lastState;
        public bool IsKeyPressed(Keys key) {
            return Keyboard.GetState().IsKeyDown(key) && !lastState.IsKeyDown(key);
        }
        public void Update(GameTime delta) {
            lastState = Keyboard.GetState();
        }
    }
}
