using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class SpawnerComponent : DrawableGameComponent
    {
        public bool dead;

        public int health;
        public int attackDamage;
        public int spawnCounter;

        public float hitRange;

        public Vector2 position;
        public Vector2 dimensions;

        //basic texture placeholder while waiting for animations
        public Texture2D textureToDraw;

        public CooldownTimer spawnTimer;
        public SpawnerComponent(Game game, string Path, Vector2 Position, Vector2 Dimensions) : base(game)
        {
            DrawOrder = 4;

            spawnCounter = 0;
            position = Position;
            dimensions = Dimensions;
            dead = false;
            health = 3;
            attackDamage = 1;
            hitRange = 20.0f;
            textureToDraw = Globals.content.Load<Texture2D>(Path);

            spawnTimer =new CooldownTimer(1000);
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(textureToDraw, new Rectangle((int)(position.X), (int)(position.Y), (int)dimensions.X, (int)dimensions.Y), null, Color.White,0, new Vector2(textureToDraw.Bounds.Width / 2, textureToDraw.Bounds.Height / 2), new SpriteEffects(), 0);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Calls spawnEnemies() and remove the spawner if it is dead
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (dead == true)
            {
                TPI_BattleBorn.Game.game.Components.Remove(this);
            }

            SpawnEnemies();
            spawnTimer.Update();
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
