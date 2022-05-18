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
            base.Draw(gameTime);
        }





    }
}
