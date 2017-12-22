using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Subterranea {
    public class Polygon : Shape {
        private Rectangle bounds;
        public Polygon(PhysicsObject parent, Vector2[] points) : base(parent) {
        }
        public void UpdatePoints(Vector2[] points) {
            int minx = -100;
            int miny = -100;
            int maxx = 100;
            int maxy = 100;
            foreach (Vector2 point in points) {
                if (point.X<minx) {
                    minx = (int) point.X;
                }
                if (point.X > maxx) {
                    maxx = (int) point.X;
                }
                if (point.Y < miny) {
                    miny = (int) point.Y;
                }
                if (point.Y > maxy) {
                    maxy = (int) point.Y;
                }
            }
            bounds = new Rectangle(minx, miny, maxx - minx, maxy - miny);
        }
        public override Rectangle getBounds() {
            Rectangle rect = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
            rect.Offset(parent.GetPosition());
            return rect;
        }
    }
}
