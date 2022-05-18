using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class Spawner1 : SpawnerComponent
    {
        public Spawner1(Game game, Vector2 Position) : base(game, "Spawner1", Position, new Vector2(60, 60))
        {
            health = 5;
            spawnTimer = new CooldownTimer(1000);
            spawnCounter = 10;
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

        /// <summary>
        /// If the cooldown is up and the spawn limit isnt reached then adds an enemy to the components list
        /// </summary>
        public override void SpawnEnemies()
        {
            if (spawnTimer.Test() == true && spawnCounter != 3)
            {
                TPI_BattleBorn.Game.game.Components.Add(new Enemy1(TPI_BattleBorn.Game.game, new Vector2(position.X, position.Y)));
                spawnCounter++;
                spawnTimer.ResetTime();
            }
            base.SpawnEnemies();
        }


    }
}
