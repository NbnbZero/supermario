﻿using SuperMario.Interfaces;
using SuperMario.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FlugelMario;

namespace SuperMario.Sprites.Koopa
{
    class DeadKoopaSprite : Sprite
    {
        public DeadKoopaSprite(Texture2D texture, Vector2 location) : base(texture, location)
        {
            Width = EnemySpriteFactory.Instance.KoopaWidth;
            Height = EnemySpriteFactory.Instance.KoopaHeight;

            TextureX = (int)EnemySpriteFactory.Instance.KoopaDeadCord.X;
            TextureY = (int)EnemySpriteFactory.Instance.KoopaDeadCord.Y;
        }

        public override void Update(Viewport viewport, Vector2 marioLocation)
        {
            Destination = MakeDestinationRectangle(Location);
        }
    }
}
