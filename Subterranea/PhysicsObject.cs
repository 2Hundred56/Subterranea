using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Subterranea {
    public abstract class PhysicsObject {
        public abstract Vector2 GetPosition();
        public abstract void SetPosition(Vector2 pos);
        protected TileManager manager;
        public Shape shape;
        public bool noPenetration = false;
        public PhysicsObject(TileManager mng) {
            manager = mng;
        }
        public void Update (GameTime delta) {

        }
    }
}
