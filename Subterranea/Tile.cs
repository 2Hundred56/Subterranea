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
        protected Vector2 _position;
        public Vector2 position
        {
            get => _position;
            set {
                throw new FieldAccessException();
            }
        }
        public bool isnull = false;
        public void Fill() {
            filled = true;
        }
        public Boolean Filled => filled;
        public void Unfill() {
            filled = false;
        }


        public Tile() {
            isnull = true;
        }
        public int Slope {
            get => slopeRotation;
            set {
                sloped = true;
                slopeRotation = value;
            }
        }
        public Tile(TileManager mng, bool filled, Vector2 pos) {
            sloped = false;
            slopeRotation = 0;
            _position = pos;
            this.filled = filled;
        }
    }
}
