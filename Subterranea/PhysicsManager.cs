using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Subterranea {
    public class PhysicsManager {
        public List<PhysicsObject> physicsObjects;
        public Vector2 gravity = new Vector2(0, 9.8f);
        public PhysicsManager() {
            physicsObjects = new List<PhysicsObject>();
        }
        public void Add(PhysicsObject obj) {
            physicsObjects.Add(obj);
        }
        public HashSet<PhysicsObject[]> TagCollisions()
        {
            return new HashSet<PhysicsObject[]>();
        }
        public void ResolveCollision(PhysicsObject[] pair) {
            Collision collision = Global.Overlapping(pair[0].polygon, pair[1].polygon);
            if (collision==null) {
                return;
            }
            float relativeVelocity = Global.Project(pair[0].velocity-pair[1].velocity, collision.axis);
            float e = Math.Max(pair[0].bouncy, pair[1].bouncy);
            Vector2 J = collision.axis*-relativeVelocity * (e + 1) / (1 / pair[0].mass + 1 / pair[1].mass);
            pair[0].AddForce(J);
            pair[1].AddForce(-J);
        }
        public void CheckPenetration(PhysicsObject[] pair) {
            Collision collision = Global.Overlapping(pair[0].polygon, pair[1].polygon);
            if (collision == null)
            {
                return;
            }
            float sum = pair[0].inverseMass + pair[1].inverseMass;
            Vector2 unit = collision.overlap / sum * collision.axis;
            pair[0].position += unit * pair[0].inverseMass;
            pair[1].position += unit * pair[1].inverseMass;
        }
        public void Update(GameTime delta) {
            float dt = (float)delta.ElapsedGameTime.TotalSeconds;
            HashSet<PhysicsObject[]> tags = TagCollisions();
            foreach (PhysicsObject[] tag in tags) {
                ResolveCollision(tag);
            }
            foreach (PhysicsObject physicsObject in physicsObjects) {
                physicsObject.AddForce(gravity*dt);
                physicsObject.PhysicsUpdate(delta);
            }

            foreach (PhysicsObject[] tag in tags) {
                CheckPenetration(tag);
            }
        }
    }
}
