using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class SpawnerComponent : DrawableGameComponent
    {
        public bool dead;
        public int health;
        public float hitRange;
        
        public CooldownTimer spawnTimer;
        public SpawnerComponent(Game game) : base(game)
        {
            dead = false;
            health = 3;
            hitRange = 20.0f;

            //spawnTimer=new CooldownTimer(1000);
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
            //updates the timer and if the cd is up => SpawnEnemies();
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {

            base.LoadContent();
        }

        public virtual void SpawnEnemies()
        {

        }

        public virtual void GetHit(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                dead = true;
            }
        }
    }
}
