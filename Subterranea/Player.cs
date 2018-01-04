using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace Subterranea {
    public class Player : LivingObject {
        public float jumpSpeed = 8f;
        public float moveSpeed = 3f;
        public Keys jump = Keys.Space;
        public Keys left = Keys.A;
        public Keys right = Keys.D;
        public Player(TileManager mng, Vector2? pos = null) : base(mng) {
            if (pos == null) {
                pos = PhysicsObject.zero;
            }
            Position = (Vector2)pos;
        }
        public int Input() => (Keyboard.GetState().IsKeyDown(left) ? -1 : 0) + (Keyboard.GetState().IsKeyDown(right) ? 1 : 0);
        public override void Update(GameTime delta){
            shape.hard = 3;
            if (LastCollision!=null) {
                if (manager.IsKeyPressed(Keys.Space)) {
                    velocity += LastCollision.axis * jumpSpeed;
                }
                Vector2 axis = Global.Rotate90(LastCollision.axis);
                if (axis.X < 0) {
                    axis = -axis;
                }
                float velX = Global.Project(velocity, axis);
                float velY = Global.Project(velocity, LastCollision.axis);
                float targetVel = velX;
                if (Input() != 0) {
                    targetVel = Input() * moveSpeed;
                }
                velocity = axis * (velX + (targetVel - velX) * (float) Math.Pow(1 - LastCollision.getShape(shape).parent.friction, 1/4f)) + LastCollision.axis * velY;
            }
            base.Update(delta);
        
        }
        public override void Collide(float bounce, float friction, Vector2 axis) {
            Vector2 proj = Global.Project(velocity, axis) * axis;
            Vector2 proj2 = Global.Project(velocity, Global.Rotate90(axis)) * Global.Rotate90(axis);
            float fric = 1;
            if (Input() == 0) {
                fric = friction;
            }
            velocity = -(Global.Project(velocity, axis) * axis * bounce) + Global.Project(velocity, Global.Rotate90(axis)) * Global.Rotate90(axis) * fric;
            base.Collide(bounce, friction, axis);
        }
    }
}
