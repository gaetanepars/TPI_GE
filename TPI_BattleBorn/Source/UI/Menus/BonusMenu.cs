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

        public BonusMenu(Game game) : base(game,"BonusMenu",new Vector2(0,0), new Vector2(Globals.screenWidth, Globals.screenHeight))
        {
            bonusHealthButton = new ButtonComponent(game, "HP+",new Vector2((Globals.screenWidth/2)-100,(Globals.screenHeight/2)-100), new Vector2(200,50));
            bonusManaButton = new ButtonComponent(game, "Mana+", new Vector2((Globals.screenWidth / 2) - 100, Globals.screenHeight / 2), new Vector2(200, 50));
            bonusSpeedButton = new ButtonComponent(game, "Speed+", new Vector2((Globals.screenWidth / 2) - 100, (Globals.screenHeight / 2) + 100), new Vector2(200, 50));

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
                bonusHealthButton.buttonClicked = false;

                Globals.hpBonus++;
                TPI_BattleBorn.Game.game.player.maxHealth += Globals.hpBonus;

                Disable();

                foreach (GameComponent component in TPI_BattleBorn.Game.game.Components)
                {
                    if (!(component is MenuComponent || component is CursorComponent || component is ButtonComponent))
                    {
                        ((DrawableGameComponent)component).Enabled = true;
                        ((DrawableGameComponent)component).Visible = true;
                    }
                }
            }

            else if (bonusManaButton.buttonClicked == true)
            {
                bonusManaButton.buttonClicked = false;

                Globals.manaBonus++;
                TPI_BattleBorn.Game.game.player.maxMana += Globals.manaBonus;

                Disable();

                foreach (GameComponent component in TPI_BattleBorn.Game.game.Components)
                {
                    if (!(component is MenuComponent || component is CursorComponent || component is ButtonComponent))
                    {
                        ((DrawableGameComponent)component).Enabled = true;
                        ((DrawableGameComponent)component).Visible = true;
                    }
                }
            }

            else if (bonusSpeedButton.buttonClicked == true)
            {
                bonusSpeedButton.buttonClicked = false;

                Globals.speedBonus++;
                TPI_BattleBorn.Game.game.player.speed += Globals.speedBonus;

                Disable();

                foreach (GameComponent component in TPI_BattleBorn.Game.game.Components)
                {
                    if (!(component is MenuComponent || component is CursorComponent || component is ButtonComponent))
                    {
                        ((DrawableGameComponent)component).Enabled = true;
                        ((DrawableGameComponent)component).Visible = true;
                    }
                }
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
            bonusSpeedButton.Visible = true;

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
            bonusSpeedButton.Visible = false;

            Enabled = false;
            Visible = false;
        }
    }
}
