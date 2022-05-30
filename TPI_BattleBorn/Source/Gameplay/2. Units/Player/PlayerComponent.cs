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
        public int playerLevel;
        public int experience;
        public int score;

        public bool dead;

        public int maxHealth;
        public int health;
        public int maxMana;
        public int mana;
        public int speed;

        public float velocityX;
        public float velocityY;

        public float hitRange;

        public int potions;

        public Vector2 position;
        public Vector2 dimensions;
        public float rotation;

        public string path;

        //basic texture placeholder while waiting for animations
        public Texture2D textureToDraw;

        public Rectangle localBounds;

        CooldownTimer attackTimer = new CooldownTimer(400);
        CooldownTimer spellTimer = new CooldownTimer(800);
        CooldownTimer potionTimer = new CooldownTimer(800);

        public PlayerComponent(Game game, string Path, Vector2 Position, Vector2 Dimensions):base(game)
        {
            DrawOrder = 4;

            playerLevel = 0;
            experience = 0;
            score = 0;

            position = Position;
            dimensions = Dimensions;

            path = Path;
            dead = false;

            health = 5;
            maxHealth = health;
            mana = 5;
            maxMana = mana;
            speed = 2;
            potions = 2;

            ResetPlayer();
        }

        /// <summary>
        /// Player hitbox
        /// </summary>

        public void ResetPlayer()
        {
            Globals.hpBonus = 0;
            Globals.manaBonus = 0;
            Globals.speedBonus = 0;

            score = 0;
            playerLevel = 0;

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

        /// <summary>
        /// Handles movement inputs, attack inputs and collision with solid blocks
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            var oldX = position.X;
            var oldY = position.Y;

            position.X += velocityX;
            position.Y += velocityY;

            localBounds = new Rectangle((int)position.X, (int)position.Y, (int)dimensions.X, (int)dimensions.Y);

            if (Globals.keyboard.IsKeyDown(Keys.W))
            {
                velocityY = -speed;
            }
            if (Globals.keyboard.IsKeyDown(Keys.S))
            {
                velocityY = speed;
            }
            if (Globals.keyboard.IsKeyDown(Keys.A))
            {
                velocityX = -speed;
            }
            if (Globals.keyboard.IsKeyDown(Keys.D))
            {
                velocityX = speed;
            }

            if (Globals.keyboard.IsKeyUp(Keys.W) && Globals.keyboard.IsKeyUp(Keys.S))
            {
                velocityY = 0;
            }

            if (Globals.keyboard.IsKeyUp(Keys.A) && Globals.keyboard.IsKeyUp(Keys.D))
            {
                velocityX = 0;
            }

            if (Globals.mouse.LeftButton == ButtonState.Pressed)
            {
                if (attackTimer.Test()==true)
                {
                    TPI_BattleBorn.Game.game.Components.Add(new Fireball(TPI_BattleBorn.Game.game, new Vector2(TPI_BattleBorn.Game.game.player.position.X, TPI_BattleBorn.Game.game.player.position.Y), TPI_BattleBorn.Game.game.player, new Vector2(Globals.mouse.Position.X, Globals.mouse.Position.Y)));
                    attackTimer.ResetTime();
                }
            }

            if (Globals.mouse.RightButton == ButtonState.Pressed)
            {
                if (spellTimer.Test() == true && mana!=0)
                {
                    TPI_BattleBorn.Game.game.Components.Add(new Thunderbolt(TPI_BattleBorn.Game.game, new Vector2(TPI_BattleBorn.Game.game.player.position.X, TPI_BattleBorn.Game.game.player.position.Y), TPI_BattleBorn.Game.game.player, new Vector2(Globals.mouse.Position.X, Globals.mouse.Position.Y)));
                    mana--;
                    spellTimer.ResetTime();
                }
            }

            if (Globals.keyboard.IsKeyDown(Keys.Q))
            {
                if (potionTimer.Test()==true && potions!=0)
                {
                    health = maxHealth;
                    mana = maxMana;

                    potions--;
                    potionTimer.ResetTime();
                }
            }

            if (dead == true)
            {

                TPI_BattleBorn.Game.game.Components.Remove(this);
                TPI_BattleBorn.Game.game.player = null;
            }

            foreach (Rectangle hitbox in TPI_BattleBorn.Game.game.level.solidTiles)
            {
                bool x_overlaps = (localBounds.Left < hitbox.Right) && (localBounds.Right > hitbox.Left);
                bool y_overlaps = (localBounds.Top < hitbox.Bottom) && (localBounds.Bottom > hitbox.Top);

                bool colliding = x_overlaps && y_overlaps;

                if (colliding)
                {
                    position.X = oldX;
                    position.Y = oldY;
                }
            }

            rotation = Globals.RotateTo(position, new Vector2(Globals.mouse.Position.X, Globals.mouse.Position.Y));

            attackTimer.Update();

            spellTimer.Update();

            potionTimer.Update();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(textureToDraw, new Rectangle((int)(position.X), (int)(position.Y), (int)dimensions.X, (int)dimensions.Y), null, Color.White, rotation, new Vector2(textureToDraw.Bounds.Width / 2, textureToDraw.Bounds.Height / 2), new SpriteEffects(), 0);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }


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
