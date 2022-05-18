using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class ButtonComponent : DrawableGameComponent
    {
        public Vector2 position;
        public Vector2 dimensions;

        public Texture2D buttonTexture;

        public string text;

        public bool buttonHovered;
        public bool buttonClicked;

        public ButtonComponent(Game game, string Path, Vector2 Position, Vector2 Dimensions) : base(game)
        {
            position = Position;
            dimensions = Dimensions;

            buttonTexture = Globals.content.Load<Texture2D>(Path);

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
            if(HoverButton()==true && Globals.mouse.LeftButton == ButtonState.Pressed)
            {
                buttonClicked = true;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.Draw(buttonTexture, position, Color.White);
            Globals.spriteBatch.DrawString(Globals.font, text, position, Color.Black);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

        public bool HoverButton()
        {
            if ((Globals.mouse.Position.X >= position.X - dimensions.X / 2 && Globals.mouse.Position.X <= position.X + dimensions.X / 2) && (Globals.mouse.Position.Y >= position.Y - dimensions.Y / 2 && Globals.mouse.Position.Y <= position.Y + dimensions.Y / 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
