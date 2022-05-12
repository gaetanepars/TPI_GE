using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class PlayerComponent : DrawableGameComponent
    {
        public bool dead;
        public int maxHealth;
        public int health;
        public int speed;

        public int potions;

        public Vector2 position;
        public Vector2 dimensions;
        public float rotation;

        public string path;

        //basic texture placeholder while waiting for animations
        public Texture2D textureToDraw;
        public AnimationComponent idleAnimation;
        public AnimationComponent runningAnimation;
        public AnimationComponent deathAnimation;

        CooldownTimer attackTimer = new CooldownTimer();
        CooldownTimer spellTimer = new CooldownTimer();

        public PlayerComponent(Game game, string Path, Vector2 Position, Vector2 Dimensions):base(game)
        {
            dead = false;
            health = 5;
            maxHealth = health;
            speed = 2;
            potions = 2;
            ResetPlayer(Position);
        }

        public void ResetPlayer(Vector2 Position)
        {
            Position = position;
            potions = 2;
            health = 5;
            speed = 2;
            dead = false;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            textureToDraw = Globals.content.Load<Texture2D>("Player");
            base.LoadContent();
        }

        public void Update()
        {
            if (Globals.keyboard.IsKeyDown(Keys.W))
            {
                position = new Vector2(position.X, position.Y - speed);
            }
            if (Globals.keyboard.IsKeyDown(Keys.S))
            {
                position = new Vector2(position.X, position.Y + speed);
            }
            if (Globals.keyboard.IsKeyDown(Keys.A))
            {
                position = new Vector2(position.X - speed, position.Y);
            }
            if (Globals.keyboard.IsKeyDown(Keys.D))
            {
                position = new Vector2(position.X + speed, position.Y);
            }

            if (Globals.mouse.LeftButton == ButtonState.Pressed)
            {

            }

            if (Globals.mouse.RightButton == ButtonState.Pressed)
            {

            }

            if (Globals.keyboard.IsKeyDown(Keys.Q))
            {
                if (potions != 0)
                {
                    health += health;
                }
                
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Draw(textureToDraw, new Rectangle((int)(position.X), (int)(position.Y), (int)dimensions.X, (int)dimensions.Y), null, Color.White, rotation, new Vector2(textureToDraw.Bounds.Width / 2, textureToDraw.Bounds.Height / 2), new SpriteEffects(), 0);
            base.Draw(gameTime);
        }
        public void PlayerCollision()
        {

        }

        public void GetHit(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                dead = true;
            }
        }

        public void Death()
        {

        }

    }
    
}
