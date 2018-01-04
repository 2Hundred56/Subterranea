﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Subterranea {
    public abstract class PhysicsObject {
        public float bounce = 0;
        public float friction = 1f;
        public static Vector2? zero = new Vector2(0, 0);
        public abstract Vector2 Position { get; set; }
        protected TileManager manager;
        public Shape shape;
        public bool noPenetration = false;
        public Vector2? collisionAxis = null;

        public Shape Shape { get => shape; set => shape = value; }

        public PhysicsObject(TileManager mng) {
            manager = mng;
        }
        public virtual void Collide(float bounce, float friction, Vector2 axis) {
            
        }
    }
}
