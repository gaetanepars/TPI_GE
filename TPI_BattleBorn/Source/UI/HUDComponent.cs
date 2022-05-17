using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class HUDComponent : DrawableGameComponent
    {
        public GaugeComponent healthMeter;
        public GaugeComponent manaMeter;

        string informationString;

        public HUDComponent(Game game) : base(game)
        {
            DrawOrder = 60;

            healthMeter = new GaugeComponent(game, 2, new Vector2(104, 12), new Vector2(140, 30), Color.Red, Color.DarkRed, TPI_BattleBorn.Game.game.player.health, TPI_BattleBorn.Game.game.player.maxHealth);
            manaMeter = new GaugeComponent(game, 2, new Vector2(104, 80), new Vector2(140, 30), Color.Red, Color.DarkRed, TPI_BattleBorn.Game.game.player.mana, TPI_BattleBorn.Game.game.player.maxMana);

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
            healthMeter.currentNumber = TPI_BattleBorn.Game.game.player.health;
            healthMeter.maxNumber = TPI_BattleBorn.Game.game.player.maxHealth;

            manaMeter.currentNumber = TPI_BattleBorn.Game.game.player.mana;
            manaMeter.maxNumber = TPI_BattleBorn.Game.game.player.maxMana;

            informationString = "Experience = " + TPI_BattleBorn.Game.game.player.experience + " Score = " + TPI_BattleBorn.Game.game.player.score + " Player level " + TPI_BattleBorn.Game.game.player.playerLevel;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Begin();
            Globals.spriteBatch.DrawString(Globals.font, informationString, new Vector2(100,100),Color.Black);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
