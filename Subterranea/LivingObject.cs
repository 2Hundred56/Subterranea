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
        public LivingObject(TileManager mng) : base(mng) {
        }

        public override Vector2 GetPosition() => position;

        public override void SetPosition(Vector2 pos) {
            if (!pos.Equals(position)) {
                collisionFlag = true;
            }
            position = pos;
            
        }
    }
}
