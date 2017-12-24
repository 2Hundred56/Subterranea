using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Subterranea {
    public abstract class Shape {
        public abstract Rectangle GetBounds();
        public PhysicsObject parent;
        public bool hard = false;
        public Vector2 Position {
            get => parent.Position;
        }
        public Shape(PhysicsObject parent) {
            this.parent = parent;
            parent.Shape = this;
        }
        public abstract HashSet<Vector2> Axes(Vector2 otherPos);
        public abstract double[] GetMinMax(Vector2 axis);
    }
}
