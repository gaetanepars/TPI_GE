using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class BonusMenu : MenuComponent
    {
        public ButtonComponent bonusHealthButton;
        public ButtonComponent bonusManaButton;
        public ButtonComponent bonusSpeedButton;

        public BonusMenu(Game game) : base(game,"BonusMenu",new Vector2(Globals.screenWidth/2,Globals.screenHeight/2), new Vector2(Globals.screenWidth, Globals.screenHeight))
        {
            bonusHealthButton = new ButtonComponent(game, "HP+", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(200, 150));
            bonusManaButton = new ButtonComponent(game, "Mana+", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2+50), new Vector2(200, 150));
            bonusSpeedButton = new ButtonComponent(game, "Speed+", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2+100), new Vector2(200, 150));

            TPI_BattleBorn.Game.game.Components.Add(bonusHealthButton);
            TPI_BattleBorn.Game.game.Components.Add(bonusManaButton);
            TPI_BattleBorn.Game.game.Components.Add(bonusSpeedButton);
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
            if (bonusHealthButton.buttonClicked == true)
            {
                TPI_BattleBorn.Game.game.player.maxHealth += 5;
                Disable();
            }

            else if (bonusManaButton.buttonClicked == true)
            {
                TPI_BattleBorn.Game.game.player.maxMana += 5;
                Disable();

            }

            else if (bonusSpeedButton.buttonClicked == true)
            {
                TPI_BattleBorn.Game.game.player.speed += 1;
                Disable();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void Enable()
        {
            bonusHealthButton.Enabled = true;
            bonusHealthButton.Visible = true;

            bonusManaButton.Enabled = true;
            bonusManaButton.Visible = true;

            bonusSpeedButton.Enabled = true;
            bonusSpeedButton.Enabled = true;

            Enabled = true;
            Visible = true;
        }

        public void Disable()
        {
            bonusHealthButton.Enabled = false;
            bonusHealthButton.Visible = false;

            bonusManaButton.Enabled = false;
            bonusManaButton.Visible = false;

            bonusSpeedButton.Enabled = false;
            bonusSpeedButton.Enabled = false;

            Enabled = false;
            Visible = false;
        }
    }
}
