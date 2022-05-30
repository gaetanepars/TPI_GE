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
            DrawOrder = 100;

            healthMeter = new GaugeComponent(game, new Vector2(80, 595), new Vector2(TPI_BattleBorn.Game.game.player.maxHealth*100, 30), Color.Red, Color.DarkRed, TPI_BattleBorn.Game.game.player.health, TPI_BattleBorn.Game.game.player.maxHealth);
            manaMeter = new GaugeComponent(game, new Vector2(80, 630), new Vector2(TPI_BattleBorn.Game.game.player.maxMana * 100, 30), Color.Blue, Color.DarkBlue, TPI_BattleBorn.Game.game.player.mana, TPI_BattleBorn.Game.game.player.maxMana);

            TPI_BattleBorn.Game.game.Components.Add(healthMeter);
            TPI_BattleBorn.Game.game.Components.Add(manaMeter);

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
            if (TPI_BattleBorn.Game.game.player != null)
            {
                healthMeter.currentNumber = TPI_BattleBorn.Game.game.player.health;
                healthMeter.maxNumber = TPI_BattleBorn.Game.game.player.maxHealth;

                manaMeter.currentNumber = TPI_BattleBorn.Game.game.player.mana;
                manaMeter.maxNumber = TPI_BattleBorn.Game.game.player.maxMana;

                informationString = "Experience = " + TPI_BattleBorn.Game.game.player.experience + "    Score = " + TPI_BattleBorn.Game.game.player.score + "    Player level " + TPI_BattleBorn.Game.game.player.playerLevel+"    Potions "+TPI_BattleBorn.Game.game.player.potions+" / 2";

            }
            else
            {
                TPI_BattleBorn.Game.game.hud.Enabled = false;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Begin();

            Globals.spriteBatch.DrawString(Globals.font, informationString, new Vector2(100, 30), Color.White);

            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
