using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Subterranea {
    public class Bounding {
        public float X;
        public float Y;
        public float Width;
        public float Height;
        public Bounding(float X, float Y, float Width, float Height) {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }
        public Bounding Scaled(float s) {
            return new Bounding(X * s, Y * s, Width * s, Height * s);
        }
        public Bounding Translated(Vector2 offset) {
            return new Bounding(X + offset.X, Y + offset.Y, Width, Height);
        }
        public Rectangle ToRectangle() {
            return new Rectangle((int)Math.Round(X), (int)Math.Round(Y), (int)Math.Round(Width), (int)Math.Round(Height));
        }
    }
}
