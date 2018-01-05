using Microsoft.Xna.Framework;
namespace Subterranea {
    public abstract class PhysicsObject : Object{
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
        public void PhysicsUpdate(GameTime delta) {
            //TODO - Write this
        }
    }
}
