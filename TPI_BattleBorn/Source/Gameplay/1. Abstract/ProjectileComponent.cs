using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Game = TPI_BattleBorn.Game;

namespace TPI_BattleBorn
{
    public class ProjectileComponent : DrawableGameComponent
    {
        public int speed;
        public int projectileDamage;

        public Vector2 position;
        public Vector2 dimensions;
        public Vector2 direction;
        public float rotation;

        public Texture2D textureToDraw;
        public PlayerComponent owner;

        public CooldownTimer projectileTravelTime;
        public ProjectileComponent(Game game, string Path, Vector2 Position, Vector2 Dimensions, PlayerComponent Owner,  Vector2 Target) : base(game)
        {
            position = Position;
            dimensions = Dimensions;
            speed = 2;
            owner = Owner;

            direction = Target - owner.position;
            direction.Normalize();

            rotation = Globals.RotateTo(position, new Vector2(Target.X, Target.Y));

            textureToDraw = Globals.content.Load<Texture2D>(Path);

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
            position += direction * speed;
            projectileTravelTime.Update();

            if (projectileTravelTime.Test() == true)
            {
                TPI_BattleBorn.Game.game.Components.Remove(this);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Draw(textureToDraw, new Rectangle((int)(position.X), (int)(position.Y), (int)dimensions.X, (int)dimensions.Y), null, Color.White, rotation, new Vector2(textureToDraw.Bounds.Width / 2, textureToDraw.Bounds.Height / 2), new SpriteEffects(), 0);

            base.Draw(gameTime);
        }

        public virtual bool collidingEnemies()
        {
            foreach (EnemyComponent enemies in TPI_BattleBorn.Game.game.Components)
            {   
                    if (Globals.GetDistance(position, enemies.position) < enemies.hitRange)
                    {
                        enemies.GetHit(projectileDamage);
                        return true;
                    }
            }
            return false;
        }

        public virtual bool collidingSpawners()
        {
            foreach (SpawnerComponent spawners in TPI_BattleBorn.Game.game.Components)
            {
                if (Globals.GetDistance(position, spawners.position) < position.hitRange)
                {
                    position.GetHit(projectileDamage);
                    return true;
                }
            }
            return false;
        }
    }
}
