using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Subterranea {
    public class LivingObject : PhysicsObject {
        protected Vector2 position;
        public HashSet<Tile> tiles;
        public bool collisionFlag = false;
        public Vector2 velocity = new Vector2(0, 0);

        public override Vector2 Position
        {
            get => position;
            set
            {
                if (!value.Equals(position))
                {
                    collisionFlag = true;
                }
                position = value;
            }
        }
        public void Add(Tile obj) {
            tiles.Add(obj);
            obj.Add(this);
        }
        public void Remove(Tile obj) {
            tiles.Remove(obj);
            obj.Remove(this);
        }
        public void _Add(Tile obj) {
            tiles.Add(obj);
            
        }
        public void _Remove(Tile obj) {
            tiles.Remove(obj);
           
        }
        public LivingObject(TileManager mng) : base(mng)
        {
            tiles = new HashSet<Tile>();
        }
        public void Update(GameTime delta)
        {
            velocity += Global.gravity*(float)delta.ElapsedGameTime.TotalSeconds;
            Position += velocity * (float)delta.ElapsedGameTime.TotalSeconds;

        }
        public override void Collide(float bounce, float friction, Vector2 axis)
        {
            Vector2 proj = Global.Project(velocity, axis) * axis;
            Vector2 proj2 = Global.Project(velocity, Global.Rotate90(axis)) * Global.Rotate90(axis);
            velocity = -(Global.Project(velocity, axis) * axis * bounce)+Global.Project(velocity, Global.Rotate90(axis)) * Global.Rotate90(axis) * friction;
            base.Collide(bounce, friction, axis);
        }
        }            
}
