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

        public int currentNumber;
        public int maxNumber;

        public Rectangle currentRectangle;
        public Rectangle maxRectangle;

        string quantityString;

        public GaugeComponent(Game game,Vector2 Position, Vector2 Dimensions, Color CurrentColor, Color MaxColor, int CurrentNumber, int MaxNumber) : base(game)
        {
            DrawOrder = 100;

            currentNumber = CurrentNumber;
            maxNumber = MaxNumber;

            currentColor = CurrentColor;
            maxColor = MaxColor;

            position = Position;
            dimensions = Dimensions;
            
            maxQuantity = new Bar("MaxGauge", new Vector2(position.X, position.Y), new Vector2(dimensions.X, dimensions.Y), maxColor);
            currentQuantity = new Bar("CurrentGauge", new Vector2(position.X, position.Y), new Vector2(currentNumber / maxNumber * (maxQuantity.dimensions.X), dimensions.Y), currentColor);

            currentRectangle = new Rectangle((int)position.X, (int)position.Y, (int)currentNumber, (int)dimensions.Y);
            maxRectangle = new Rectangle((int)position.X,(int)position.Y, maxNumber*30, (int)dimensions.Y);

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
            quantityString = currentNumber + " / " + maxNumber;
            currentRectangle.Width = (int)currentNumber*30;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Begin();

            maxQuantity.Draw(maxRectangle);
            currentQuantity.Draw(currentRectangle);

            Globals.spriteBatch.DrawString(Globals.font, quantityString, new Vector2(maxRectangle.Center.X-15, maxRectangle.Center.Y-10), Color.White);

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

        public void Draw(Rectangle sourceRect)
        {
            Globals.spriteBatch.Draw(textureToDraw, sourceRect, null, barColor);
        }

    }
}
