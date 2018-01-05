using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Subterranea {
    public class PhysicsManager {
        public List<PhysicsObject> physicsObjects;
        public PhysicsManager() {
            physicsObjects = new List<PhysicsObject>();
        }
        public void Add(PhysicsObject obj) {
            physicsObjects.Add(obj);
        }
        public void Update(GameTime delta) {
            //Tag possible collisions
            //Solve collisions
            foreach (PhysicsObject physicsObject in physicsObjects) {
                physicsObject.PhysicsUpdate(delta);
            }
            //Fix penetration
        }
    }
}
