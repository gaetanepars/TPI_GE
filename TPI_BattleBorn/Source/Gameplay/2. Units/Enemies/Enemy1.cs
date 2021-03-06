using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class Enemy1 : EnemyComponent
    {
        public Enemy1(Game game, Vector2 Position) : base(game,"Enemy1", Position, new Vector2(60,60))
        {
            attackDamage = 1;
            health = 5;
            speed = 2;
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
