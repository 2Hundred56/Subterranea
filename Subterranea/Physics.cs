using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Subterranea {
    public static class Physics {
        public static void CheckCollision(PhysicsObject o1, PhysicsObject o2) {
            Vector2? overlap = Overlapping(o1.Shape, o2.Shape);
            if (overlap==null) {
                return;
            }
            else {
                Vector2 o = (Vector2)overlap;
                if (o1.Shape.hard) {    
                    
                    if (o2.Shape.hard) {
                        o1.Position += 0.5f * o;
                        o2.Position -= 0.5f * o;
                    }
                    else {
                        o2.Position -= o;
                    }
                }
                else if (o2.Shape.hard) {
                    o1.Position += o;
                }
            }
        }
        public static Vector2 gravity;
        public static Vector2 Rotate90(Vector2 vector, int direction=1) => new Vector2(vector.Y * direction, -vector.X * direction); //+1 = counterclockwise, -1 = clockwise
        public static Vector2 RefVector(Vector2 vector) => new Vector2(vector.Y==0?Math.Abs(vector.X):vector.X, Math.Abs(vector.Y));
        public static float Project(Vector2 vector, Vector2 axis) => Vector2.Dot(vector, axis / axis.Length());
        public static Vector2? Overlapping (Shape s1, Shape s2) {
            HashSet<Vector2> axes = new HashSet<Vector2>();
            axes.UnionWith(s1.Axes(s2.Position));
            axes.UnionWith(s2.Axes(s1.Position));
            Vector2 minAxis = axes.ElementAt<Vector2>(0);
            double minDist = 1000;
            foreach (Vector2 axis in axes) {
                double dist;
                double[] proj1 = s1.GetMinMax(axis);
                double[] proj2 = s2.GetMinMax(axis);
                if (proj2[0] < proj1[1] && proj2[0] > proj1[0]) { //2 is overlapping from the left
                    dist = proj1[1] - proj2[0];
                }
                else if (proj1[0] < proj2[1] && proj1[0]>proj2[0]) {
                    dist = proj2[1] - proj1[0];
                }
                else {
                    return null;
                }
                if (dist<minDist) {
                    minAxis = axis;
                    minDist = dist;
                }
            }
            return minAxis / (float) minAxis.Length() * (float) minDist;

        }
    }
}
