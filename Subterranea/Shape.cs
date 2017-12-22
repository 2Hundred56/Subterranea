using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Subterranea {
    public abstract class Shape {
        public abstract Rectangle getBounds();
        protected PhysicsObject parent;
        public Shape(PhysicsObject parent) {
            this.parent = parent;
        }
    }
}
