using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class GaugeComponent : DrawableGameComponent
    {
        public Vector2 position;
        public Vector2 dimensions;

        public Bar currentQuantity;
        public Bar maxQuantity;

        public Color currentColor;
        public Color maxColor;

        public int border;

        public int currentNumber;
        public int maxNumber;

        public GaugeComponent(Game game, int Border,Vector2 Position, Vector2 Dimensions, Color CurrentColor, Color MaxColor, int CurrentNumber, int MaxNumber) : base(game)
        {
            border = Border;

            currentNumber = CurrentNumber;
            maxNumber = MaxNumber;

            currentColor = CurrentColor;
            maxColor = MaxColor;

            position = Position;
            dimensions = Dimensions;

            currentQuantity = new Bar("CurrentGauge", new Vector2(0, 0), new Vector2(Dimensions.X - border * 2, Dimensions.Y - border * 2),CurrentColor);
            maxQuantity = new Bar("MaxGauge", new Vector2(0, 0), new Vector2(Dimensions.X, Dimensions.Y), CurrentColor);
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
            currentQuantity.dimensions = new Vector2(currentNumber / maxNumber * (maxQuantity.dimensions.X - border * 2), currentQuantity.dimensions.Y);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Begin();
            maxQuantity.Draw();
            currentQuantity.Draw();
            Globals.spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
    public class Bar
    {
        public string path;

        public Vector2 position;
        public Vector2 dimensions;

        public Texture2D textureToDraw;
        public Color barColor;

        public Bar(string Path, Vector2 Position, Vector2 Dimensions, Color BarColor)
        {
            path = Path;
            position = Position;
            dimensions = Dimensions;

            textureToDraw = Globals.content.Load<Texture2D>(Path);
            barColor = BarColor;
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(textureToDraw, new Vector2(position.X, position.Y), barColor);
        }
    }
}
