using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class CursorComponent : DrawableGameComponent
    {
        public Vector2 position;
        public Vector2 dimensions;

        public Texture2D cursorSprite;

        public CursorComponent(Game game,string Path,Vector2 Position, Vector2 Dimensions) : base(game)
        {
            DrawOrder = 1000;
            position = Position;
            dimensions = Dimensions;

            cursorSprite = Globals.content.Load<Texture2D>(Path);
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
            Globals.spriteBatch.Draw(cursorSprite, new Vector2(Globals.mouse.Position.X, Globals.mouse.Position.Y), Color.White);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
