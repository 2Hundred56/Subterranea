using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Subterranea {
    public abstract class Object {
        public Scene scene = null;
        public Vector2 scale = new Vector2(1,1);
        public Vector2 position = new Vector2(1, 1);
        public float rotation = 0;
        Renderer renderer;
        public void Update(GameTime delta) {
            //FIX THIS
        }
    }
}
