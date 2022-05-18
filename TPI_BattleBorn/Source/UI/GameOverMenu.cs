using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn.Source.UI
{
    public class GameOverMenu : MenuComponent
    {

        public ButtonComponent restartButton;
        public ButtonComponent quitButton;

        public GameOverMenu(Game game) : base(game,"GameOverMenu",new Vector2(Globals.screenWidth/2,Globals.screenHeight/2), new Vector2(Globals.screenWidth,Globals.screenHeight))
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
