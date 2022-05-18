using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class MainMenu : MenuComponent
    {
        public ButtonComponent continueButton;
        public ButtonComponent restartButton;
        public ButtonComponent quitButton;

        public MainMenu(Game game) : base(game,"MainMenu",new Vector2(Globals.screenWidth/2,Globals.screenHeight/2),new Vector2(Globals.screenWidth,Globals.screenHeight))
        {
            continueButton = new ButtonComponent(game, "ContinueButton", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2), new Vector2(200, 150));
            restartButton = new ButtonComponent(game, "RestartButton", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 + 50), new Vector2(200, 150));
            quitButton = new ButtonComponent(game, "QuitButton", new Vector2(Globals.screenWidth / 2, Globals.screenHeight / 2 + 100), new Vector2(200, 150));

            TPI_BattleBorn.Game.game.Components.Add(continueButton);
            TPI_BattleBorn.Game.game.Components.Add(restartButton);
            TPI_BattleBorn.Game.game.Components.Add(quitButton);

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
