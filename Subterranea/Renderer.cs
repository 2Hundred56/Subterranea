using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
namespace Subterranea {
    public class Renderer {
        public Color tint;
        public uint? sprite; // Sprite index (null if no sprite)
        public Object parent;
        public Renderer(Object parent, uint? sprite) {
            this.sprite = sprite;
            this.parent = parent;
        }
        public void Render(MainGame game) {
            if (this.sprite != null) {
                game.DrawSprite(game.spriteTable[(uint)sprite],
                           new Bounding(parent.position.X,
                                       parent.position.Y,
                                       parent.scale.X,
                                       parent.scale.Y),
                           tint, parent.rotation);
            }

        }
    }
}
