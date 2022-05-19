using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class GameOverMenu : MenuComponent
    {
        public ButtonComponent restartButton;
        public ButtonComponent quitButton;

        public GameOverMenu(Game game) : base(game,"GameOverMenu",new Vector2(0,0), new Vector2(Globals.screenWidth,Globals.screenHeight))
        {
            restartButton = new ButtonComponent(game, "Restart", new Vector2(640, 360), new Vector2(200, 50));
            quitButton = new ButtonComponent(game, "Quit", new Vector2(640, 610), new Vector2(200, 50));

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

        public void Disable()
        {
            restartButton.Enabled = false;
            restartButton.Visible = false;

            quitButton.Enabled = false;
            quitButton.Visible = false;

            Enabled = false;
            Visible = false;
        }

        public void Enable()
        {
            restartButton.Enabled = true;
            restartButton.Visible = true;

            quitButton.Enabled = true;
            quitButton.Visible = true;

            Enabled = true;
            Visible = true;
        }
    }
}
