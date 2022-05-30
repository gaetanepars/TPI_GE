using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class Fireball : ProjectileComponent
    {
        public Fireball(Game game, Vector2 Position, PlayerComponent Owner, Vector2 Target) : base(game, "Fireball", Position, new Vector2(60,60),Owner,Target)
        {
            projectileDamage = 2;
            speed = 4;
            projectileTravelTime = new CooldownTimer(800);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
