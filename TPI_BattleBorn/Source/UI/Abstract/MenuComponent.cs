using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class MenuComponent : DrawableGameComponent
    {
        public Vector2 position;
        public Vector2 dimensions;

        public Texture2D menuScreen;

        public MenuComponent(Game game, string Path, Vector2 Position, Vector2 Dimensions) : base(game)
        {
            Enabled = false;
            Visible = false;

            position = Position;
            dimensions = Dimensions;

            menuScreen = Globals.content.Load<Texture2D>(Path);
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
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(menuScreen, position, Color.White);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
