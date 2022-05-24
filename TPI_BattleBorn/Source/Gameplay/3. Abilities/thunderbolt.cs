using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class Thunderbolt : ProjectileComponent
    {
        public Thunderbolt(Game game, Vector2 Position, PlayerComponent Owner, Vector2 Target) : base(game, "Thunderbolt", Position, new Vector2(60, 60), Owner, Target)
        {
            projectileDamage = 10;
            speed = 8;
            projectileTravelTime = new CooldownTimer(1000);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
