using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class Spawner2 : SpawnerComponent
    {
        public CooldownTimer wavetimer;
        public Spawner2(Game game, Vector2 Position) : base(game, "Spawner2", Position, new Vector2(60, 60))
        {
            health = 10;
            spawnTimer = new CooldownTimer(500);
            spawnCounter = 0;
            wavetimer = new CooldownTimer(10000);
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
            wavetimer.Update();
            if (wavetimer.Test() == true)
            {
                spawnCounter = 0;
                wavetimer.ResetTime();
            }

            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// If the cooldown is up and the spawn limit isnt reached then adds an enemy to the components list
        /// </summary>
        public override void SpawnEnemies()
        {
            if (spawnTimer.Test() == true && spawnCounter != 3)
            {
                TPI_BattleBorn.Game.game.Components.Add(new Enemy2(TPI_BattleBorn.Game.game, new Vector2(position.X, position.Y)));
                spawnCounter++;
                spawnTimer.ResetTime();
            }

            base.SpawnEnemies();
        }
    }
}
