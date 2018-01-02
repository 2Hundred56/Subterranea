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
        public float bounce = 0;
        public float friction = 1f;
        public abstract Vector2 Position { get; set; }
        protected TileManager manager;
        protected Shape shape;
        public bool noPenetration = false;
        public Vector2? collisionAxis = null;

        public Shape Shape { get => shape; set => shape = value; }

        public PhysicsObject(TileManager mng) {
            manager = mng;
        }
        public virtual void Collide(float bounce, float friction, Vector2 axis) {
            
        }
    }
}
