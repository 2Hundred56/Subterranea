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

        public new Vector2 Position
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
        }
        public void Update(GameTime delta)
        {
            velocity += Physics.gravity*(float)delta.ElapsedGameTime.TotalSeconds;
            Position += velocity * (float)delta.ElapsedGameTime.TotalSeconds;

        }
        public override void Collide(float bounce, float friction, Vector2 axis)
        {
            velocity = Physics.Project(velocity, axis) * axis * bounce+Physics.Project(velocity, Physics.Rotate90(axis)) * Physics.Rotate90(axis) * friction;
            base.Collide(bounce, friction, axis);
        }
        }            
}
