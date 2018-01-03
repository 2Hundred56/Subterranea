using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Subterranea {
    public class Tile : PhysicsObject
    {
        public bool sloped;
        protected int slopeRotation;
        protected bool filled = false;
        protected Vector2 position;
        public override Vector2 Position
        {
            get => position;
            set {
                throw new FieldAccessException();
            }
        }
        public bool isnull = false;
        public HashSet<LivingObject> objects;
        public new bool noPenetration = true;
        public void Add(LivingObject obj) {
            objects.Add(obj);
            obj._Add(this);
        }
        public void Remove(LivingObject obj) {
            objects.Remove(obj);
            obj._Remove(this);
        }
        public void _Add(LivingObject obj) {
            objects.Add(obj);

        }
        public void _Remove(LivingObject obj) {
            objects.Remove(obj);

        }
        public void Fill() {
            filled = true;
        }
        public Boolean Filled => filled;
        public void Unfill() {
            filled = false;
        }


        public Tile() : base(null){
            isnull = true;
        }
        public int Slope {
            get => slopeRotation;
            set {
                sloped = true;
                slopeRotation = value;
                shape = Polygon.RightTriangle(this, value, 0.5f);
                shape.hard = true;
            }
        }
        public Tile(TileManager mng, bool filled, Vector2 pos) : base(mng) {
            sloped = false;
            slopeRotation = 0;
            position = pos;
            this.filled = filled;
            objects = new HashSet<LivingObject>();

            shape = Polygon.AABB(this, 0.5f, 0.5f);
            shape.hard = true;
        }
    }
}
