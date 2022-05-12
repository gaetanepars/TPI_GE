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

        public string path;

        //basic texture placeholder while waiting for animations
        public Texture2D textureToDraw;
        public AnimationComponent idleAnimation;
        public AnimationComponent runningAnimation;
        public AnimationComponent deathAnimation;
        public EnemyComponent(Game game, string Path, Vector2 Position, Vector2 Dimensions) : base(game)
        {
            position = Position;
            dimensions = Dimensions;
            dead = false;
            textureToDraw= Globals.content.Load<Texture2D>(Path);
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
            AI();
            if (dead == true)
            {
                TPI_BattleBorn.Game.game.Components.Remove(this);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        public virtual void AI()
        {
            position += Globals.RadialMovement(TPI_BattleBorn.Game.game.player.position, position, speed);
            rotation = Globals.RotateTo(position, TPI_BattleBorn.Game.game.player.position);

            if (Globals.GetDistance(position, TPI_BattleBorn.Game.game.player.position) < 15)
            {
                TPI_BattleBorn.Game.game.player.GetHit(attackDamage);
                dead = true;
            }
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
