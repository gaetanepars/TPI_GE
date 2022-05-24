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

        /// <summary>
        /// How long the projectile will stay on the screen
        /// </summary>
        public CooldownTimer projectileTravelTime;
        public ProjectileComponent(Game game, string Path, Vector2 Position, Vector2 Dimensions, PlayerComponent Owner,  Vector2 Target) : base(game)
        {
            DrawOrder = 3;

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

        /// <summary>
        /// Update the movement of the projectile and checks if it collides with other units and if so removes it from the list of components
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            position += direction * speed;
            projectileTravelTime.Update();

            if (projectileTravelTime.Test() == true || collidingEnemies()==true || collidingSpawners()==true)
            {
                TPI_BattleBorn.Game.game.Components.Remove(this);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(textureToDraw, new Rectangle((int)(position.X), (int)(position.Y), (int)dimensions.X, (int)dimensions.Y), null, Color.White, rotation, new Vector2(textureToDraw.Bounds.Width / 2, textureToDraw.Bounds.Height / 2), new SpriteEffects(), 0);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Function that goes through all the game components and if they're an enemy check if it's close enough to get hit
        /// </summary>
        /// <returns></returns>
        public virtual bool collidingEnemies()
        {
            foreach (GameComponent component in TPI_BattleBorn.Game.game.Components)
            {
                if (component is EnemyComponent)
                {
                    if (Globals.GetDistance(position, ((EnemyComponent)component).position) < ((EnemyComponent)component).hitRange)
                    {
                        ((EnemyComponent)component).GetHit(projectileDamage);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Function that goes through all the game components and if they're an enemy check if it's close enough to get hit
        /// </summary>
        /// <returns></returns>
        public virtual bool collidingSpawners()
        {
            for (int i = 0; i < TPI_BattleBorn.Game.game.Components.Count; i++)
            {
                if (TPI_BattleBorn.Game.game.Components[i] is SpawnerComponent)
                {
                    if (Globals.GetDistance(position, ((SpawnerComponent)(TPI_BattleBorn.Game.game.Components[i])).position) < ((SpawnerComponent)(TPI_BattleBorn.Game.game.Components[i])).hitRange)
                    {
                        ((SpawnerComponent)(TPI_BattleBorn.Game.game.Components[i])).GetHit(projectileDamage);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
