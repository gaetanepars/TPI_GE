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

        public Vector2 position;
        public Vector2 dimensions;
        public float rotation;

        public string path;

        //basic texture placeholder while waiting for animations
        public Texture2D textureToDraw;
        public AnimationComponent idleAnimation;
        public AnimationComponent runningAnimation;
        public AnimationComponent deathAnimation;
        public EnemyComponent(Microsoft.Xna.Framework.Game game) : base(game)
        {
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
            AI();
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public virtual void AI()
        {
           
        }

    }
}
