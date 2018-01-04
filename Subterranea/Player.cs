using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Subterranea {
    public class Player : LivingObject {
        public float movement = 0;
        public float acceleration = 0.25f;
        public float maxSpeed = 8f;
        public Player(TileManager mng, Vector2? pos = null) : base(mng) {
            if (pos == null) {
                pos = PhysicsObject.zero;
            }
            Position = (Vector2)pos;
        }
        public override void Update(GameTime delta){
            
        }
        public override void Collide(float bounce, float friction, Vector2 axis) {
            movement *= friction;
            base.Collide(bounce, friction, axis);
        }
    }
}
