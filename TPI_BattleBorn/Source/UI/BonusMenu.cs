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
            bonusHealthButton = new ButtonComponent(game, "BonusHPButton", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(200, 150));
            bonusManaButton = new ButtonComponent(game, "BonusManaButton", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2+50), new Vector2(200, 150));
            bonusSpeedButton = new ButtonComponent(game, "BonusSpeedButton", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2+100), new Vector2(200, 150));

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

                TPI_BattleBorn.Game.game.bonusMenu.Enabled = false;
                TPI_BattleBorn.Game.game.bonusMenu.Visible = false;

                TPI_BattleBorn.Game.game.Components.Remove(this);
            }

            else if (bonusManaButton.buttonClicked == true)
            {
                TPI_BattleBorn.Game.game.player.maxMana += 5;

                TPI_BattleBorn.Game.game.bonusMenu.Enabled = false;
                TPI_BattleBorn.Game.game.bonusMenu.Visible = false;

                TPI_BattleBorn.Game.game.Components.Remove(this);
            }

            else if (bonusSpeedButton.buttonClicked == true)
            {
                TPI_BattleBorn.Game.game.player.speed += 1;

                TPI_BattleBorn.Game.game.bonusMenu.Enabled = false;
                TPI_BattleBorn.Game.game.bonusMenu.Visible = false;

                TPI_BattleBorn.Game.game.Components.Remove(this);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }





    }
}
