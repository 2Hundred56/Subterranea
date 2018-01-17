using Microsoft.Xna.Framework;
namespace Subterranea {
    public class PhysicsObject : Object{
        public Polygon polygon;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 force;
        public float mass;
        public float friction;
        public float bouncy;
        public void SetStatic() {
            mass = 0;
        }
        public float inverseMass {
            get {
                if (mass == 0) return 0;
                else return 1 / mass;
            }
        }
        public PhysicsObject() {
            force = new Vector2();
        }
        public void PhysicsUpdate(GameTime delta) {
            float dt = (float) delta.ElapsedGameTime.TotalSeconds;
            velocity += (inverseMass * force) * dt;
            position += velocity * dt;
            force = new Vector2();
        }
        public void AddForce(Vector2 force) {
            this.force += force;
        }
    }
}
