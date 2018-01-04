using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace Subterranea {
    public class Player : LivingObject {
        public float acceleration = 16f;
        public float maxSpeed = 8f;
        public float jumpSpeed = 8f;
        public float airAccel = 4f;
        public Player(TileManager mng, Vector2? pos = null) : base(mng) {
            if (pos == null) {
                pos = PhysicsObject.zero;
            }
            Position = (Vector2)pos;
        }
        public override void Update(GameTime delta){
            if (LastCollision!=null) {
                if (Keyboard.GetState().IsKeyDown(Keys.Space)) {
                    velocity += LastCollision.axis * jumpSpeed;
                }
                Vector2 axis = Global.Rotate90(LastCollision.axis);
                if (axis.X<0) {
                    axis = -axis;
                }

                Vector2 accel = manager.GetInput().X * axis * acceleration * (1 - LastCollision.getShape(shape).parent.friction) * (1/(1 - LastCollision.getShape(shape).parent.friction));
                velocity += accel * (float) delta.ElapsedGameTime.TotalSeconds;
                velocity *= (1 / LastCollision.getShape(shape).parent.friction);
            }
            else {
                Vector2 accel = manager.GetInput().X * new Vector2(1,0) * airAccel;
                velocity += accel * (float)delta.ElapsedGameTime.TotalSeconds;
            }
            base.Update(delta);
        }
    }
}
