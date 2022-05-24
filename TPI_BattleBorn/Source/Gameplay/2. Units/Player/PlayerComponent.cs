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

        public float hitRange;

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

        public AnimationManager sprite;

        public Rectangle localBounds;

        CooldownTimer attackTimer = new CooldownTimer(1000);
        CooldownTimer spellTimer = new CooldownTimer(5000);

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
        public Rectangle BoundingRectangle
        {
            get
            {
                int left = (int)Math.Round(position.X) + localBounds.X;
                int top = (int)Math.Round(position.Y) + localBounds.Y;
                return new Rectangle(left, top, localBounds.Width, localBounds.Height);
            }
        }

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
        /// Handles movement inputs, attack inputs and calls CollisionManagement()
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
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
                if (attackTimer.Test()==true)
                {
                    TPI_BattleBorn.Game.game.Components.Add(new Fireball(TPI_BattleBorn.Game.game, new Vector2(TPI_BattleBorn.Game.game.player.position.X, TPI_BattleBorn.Game.game.player.position.Y), TPI_BattleBorn.Game.game.player, new Vector2(Globals.mouse.Position.X, Globals.mouse.Position.Y)));
                    attackTimer.ResetTime();
                }
            }

            if (Globals.mouse.RightButton == ButtonState.Pressed)
            {
                if (spellTimer.Test() == true || mana!=0)
                {
                    mana--;
                    spellTimer.ResetTime();
                }
            }

            if (Globals.keyboard.IsKeyDown(Keys.Q))
            {
                if (potions != 0)
                {
                    health = maxHealth;
                }
                
            }

            if (dead == true)
            {

                TPI_BattleBorn.Game.game.Components.Remove(this);
                TPI_BattleBorn.Game.game.player = null;

            }

            CollisionManagement();

            rotation = Globals.RotateTo(position, new Vector2(Globals.mouse.Position.X, Globals.mouse.Position.Y));

            attackTimer.Update();

            spellTimer.Update();

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

        /// <summary>
        /// Handles the collision between the player and the tiles
        /// </summary>
        private void CollisionManagement()
        {
            Rectangle bounds = BoundingRectangle;
            int leftTile = (int)Math.Floor((float)bounds.Left/ Tile.tileWidth);
            int rightTile = (int)Math.Ceiling(((float)bounds.Right / Tile.tileWidth)) - 1;
            int topTile = (int)Math.Floor((float)bounds.Top / Tile.tileHeight);
            int bottomTile = (int)Math.Ceiling(((float)bounds.Bottom / Tile.tileHeight)) - 1;

            for (int y = topTile; y <= bottomTile; y++)
            {
                for (int x = leftTile; x <= rightTile; x++)
                {
                    TileStatus collision = TPI_BattleBorn.Game.game.level.GetCollision(x, y);
                    if (collision != TileStatus.Passthrough)
                    {
                        Rectangle tileBounds = TPI_BattleBorn.Game.game.level.GetTileRectangle(x, y);
                        Vector2 depth = RectangleExtension.GetIntersectionDepth(bounds, tileBounds);
                        if (depth != Vector2.Zero)
                        {
                            float absDepthX = Math.Abs(depth.X);
                            float absDepthY = Math.Abs(depth.Y);

                            if (absDepthY < absDepthX && collision == TileStatus.Solid)
                            {

                                position = new Vector2(position.X, position.Y - Tile.tileHeight );
                                bounds = BoundingRectangle;
                            }
                            else if (absDepthY>absDepthX && collision == TileStatus.Solid)
                            {
                                position = new Vector2(position.X +Tile.tileWidth, position.Y);
                                bounds = BoundingRectangle;
                            }
                        }
                    }
                }
            }
        }
    }
}
