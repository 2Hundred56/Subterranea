using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace Subterranea {
    public class Player : LivingObject {
        public float acceleration = 10f;
        public float maxSpeed = 8f;
        public float jumpSpeed = 8f;
        public float airAccel = 0.01f;
        public bool doubleJump = false;
        public float movement = 0;
        public Keys left = Keys.A;
        public Keys right = Keys.D;
        public Keys jump = Keys.Space;
        public Player(TileManager mng, Vector2? pos = null) : base(mng) {
            if (pos == null) {
                pos = PhysicsObject.zero;
            }
            Position = (Vector2)pos;
        }
        public override void Update(GameTime delta) {
            float friction = airAccel;
            if (LastCollision != null && LastCollision.axis.Y != 0) {
                friction = 1 - LastCollision.getShape(shape).parent.friction;
            }
            if (Keyboard.GetState().IsKeyDown(left) && (movement>-maxSpeed)) {
                movement -= acceleration*friction;
            }
            if (Keyboard.GetState().IsKeyDown(right) && (movement < maxSpeed)) {
                movement += acceleration*friction;
            }
            if (LastCollision!=null && LastCollision.axis.Y!=0) {
                doubleJump = true;
                if (manager.IsKeyPressed(jump)) {
                    velocity += LastCollision.axis * jumpSpeed;
                }
                Vector2 axis = Global.Rotate90(LastCollision.axis);
                if (axis.X<0) {
                    axis = -axis;
                }

                velocity = axis * movement + Global.ProjectVec(velocity, LastCollision.axis);
                velocity *= (1 / LastCollision.getShape(shape).parent.friction);
            }
            else {
                if (manager.IsKeyPressed(Keys.Space) && doubleJump) {
                    if (velocity.Y>0) {
                        velocity -= new Vector2(0, velocity.Y);
                    }
                    velocity += new Vector2(0, -1) * jumpSpeed / 2;
                    doubleJump = false;
                }
                Vector2 accel = manager.GetInput().X * new Vector2(1,0) * airAccel;
                velocity += accel * (float)delta.ElapsedGameTime.TotalSeconds;
            }
            base.Update(delta);
        }
    }
}
