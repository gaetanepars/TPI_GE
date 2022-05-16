using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class LaserSlash : ProjectileComponent
    {
        public LaserSlash(Game game, Vector2 Position, PlayerComponent Owner, Vector2 Target) : base(game, "LaserSlash", Position, new Vector2(60, 60), Owner, Target)
        {
            projectileDamage = 5;
            projectileTravelTime = new CooldownTimer(400);
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
