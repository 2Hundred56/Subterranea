using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
namespace Subterranea {
    public static class Global {
        public static int CAVEINDEX = 75; //Lower = more caves
        public static int MINCAVESIZE = 3;
        public static int MAXCAVESIZE = 10;
        public static int ppu;
        public static void CheckCollision(PhysicsObject o1, PhysicsObject o2) {
            Collision collision = Overlapping(o1.Shape, o2.Shape);
            if (collision == null) {
                return;
            }
            else {
                if (o1.Shape.hard) {
                    o2.Collide(o1.bounce, o1.friction, collision.axis);
                    o2.LastCollision = collision;
                    if (o2.Shape.hard) {
                        o1.LastCollision = collision;
                        o1.Collide(o2.bounce, o2.friction, collision.axis);
                        o1.Position += 0.5f * collision.offset;
                        o2.Position -= 0.5f * collision.offset;
                    }
                    else {
                        o2.Position -= collision.offset;
                    }
                }
                else if (o2.Shape.hard) {
                    o1.LastCollision = collision;
                    o1.Position += collision.offset;
                    o1.Collide(o2.bounce, o2.friction, collision.axis);
                }
            }
        }
        
        
        public static Vector2 gravity = new Vector2(0, 9.8f);
        public static Vector2 Rotate90(Vector2 vector, int direction=1) => new Vector2(vector.Y * direction, -vector.X * direction); //+1 = counterclockwise, -1 = clockwise
        public static Vector2 RefVector(Vector2 vector) {
            if (vector.Y>0) {
                return vector;
            }
            if (vector.Y == 0) {
                return new Vector2(Math.Abs(vector.X),0);
            }
            if (vector.Y < 0) {
                return -vector;
            }
            return vector;
        }
        public static float Project(Vector2 vector, Vector2 axis) => Vector2.Dot(vector, axis / axis.Length());
        public static Vector2 ProjectVec(Vector2 vector, Vector2 axis) => axis/axis.Length()*Project(vector, axis);
        public static Collision Overlapping (Shape s1, Shape s2) {
            HashSet<Vector2> axes = new HashSet<Vector2>();
            axes.UnionWith(s1.Axes(s2.Position));
            axes.UnionWith(s2.Axes(s1.Position));
            Vector2 minAxis = axes.ElementAt<Vector2>(0);
            double minDist = 1000;
            foreach (Vector2 axis in axes) {
                double dist;
                double[] proj1 = s1.GetMinMax(axis);
                double[] proj2 = s2.GetMinMax(axis);
                if (proj2[0] <= proj1[1] && proj2[0] >= proj1[0]) { //2 is overlapping from the left
                    dist = proj1[1] - proj2[0];
                }
                else if (proj1[0] < proj2[1] && proj1[0]>=proj2[0]) {
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
            if (minDist == 0) {
                return null;
            }
            minAxis = minAxis / minAxis.Length();
            minAxis = Global.RefVector(minAxis) * Math.Sign(Global.Project(s1.Position - s2.Position, minAxis));
            return new Collision(s1, s2, (float)minDist, minAxis);

        }
    }
}
