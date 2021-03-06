using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class EnemyComponent : DrawableGameComponent
    {
        public bool dead;
        public int health;
        public int speed;
        public int attackDamage;
        public float hitRange;

        public Vector2 position;
        public Vector2 dimensions;
        public float rotation;

        public Texture2D textureToDraw;

        public CooldownTimer dmgTimer;

        public EnemyComponent(Game game, string Path, Vector2 Position, Vector2 Dimensions) : base(game)
        {
            DrawOrder = 2;
            hitRange = 20f;
            position = Position;
            dimensions = Dimensions;
            dead = false;
            textureToDraw= Globals.content.Load<Texture2D>(Path);
            dmgTimer = new CooldownTimer(500);
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
        /// Calls the AI function and remove the component if it is dead
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            dmgTimer.Update();

            if (dead == true)
            {
                if (TPI_BattleBorn.Game.game.player != null)
                {
                    TPI_BattleBorn.Game.game.player.score++;
                    TPI_BattleBorn.Game.game.player.experience += 10;
                }

                TPI_BattleBorn.Game.game.Components.Remove(this);
            }
            AI();

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
        /// Rotate the enemy in the direction of the player, normalizes its trajectory and handle collisions between the player and the enemies
        /// </summary>
        public virtual void AI()
        {
            if (TPI_BattleBorn.Game.game.player != null)
            {
                position += Globals.RadialMovement(TPI_BattleBorn.Game.game.player.position, position, speed);
                rotation = Globals.RotateTo(position, TPI_BattleBorn.Game.game.player.position);

                if (Globals.GetDistance(position, TPI_BattleBorn.Game.game.player.position) < 15)
                {
                    if (dmgTimer.Test() == true)
                    {
                        TPI_BattleBorn.Game.game.player.GetHit(attackDamage);
                    }
                
                    dead = true;
                    dmgTimer.ResetTime();
                }
            }
           
        }

        /// <summary>
        /// simple function to damage an enemy
        /// </summary>
        /// <param name="damage"></param>
        public void GetHit(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                dead = true;
            }
        }

    }
}
