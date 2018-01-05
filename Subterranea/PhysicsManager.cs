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
        public void Update(GameTime delta) {
            float dt = (float)delta.ElapsedGameTime.TotalSeconds;
            //Tag possible collisions
            //Solve collisions
            foreach (PhysicsObject physicsObject in physicsObjects) {
                physicsObject.AddForce(gravity*dt);
                physicsObject.PhysicsUpdate(delta);
            }
            //Fix penetration
        }
    }
}
