using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Subterranea {
    public abstract class Shape {
        public abstract Rectangle GetBounds();
        protected PhysicsObject parent;
        public bool hard = false;
        public Vector2 Position {
            get => parent.GetPosition();
        }
        public Shape(PhysicsObject parent) {
            this.parent = parent;
        }
        public abstract HashSet<Vector2> Axes(Vector2 otherPos);
        public abstract double[] GetMinMax(Vector2 axis);
    }
}
