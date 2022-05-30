using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public MainMenu(Game game) : base(game,"MainMenu",new Vector2(0,0),new Vector2(Globals.screenWidth,Globals.screenHeight))
        {
            continueButton = new ButtonComponent(game, "", new Vector2((Globals.screenWidth / 2)-100, Globals.screenHeight / 2-100), new Vector2(200, 50));
            continueButton.buttonTexture = Globals.content.Load<Texture2D>("ContinueButton");

            restartButton = new ButtonComponent(game, "", new Vector2((Globals.screenWidth / 2)-100, (Globals.screenHeight / 2)), new Vector2(200, 50));
            restartButton.buttonTexture = Globals.content.Load<Texture2D>("RestartButton");

            quitButton = new ButtonComponent(game, "", new Vector2((Globals.screenWidth / 2)-100, (Globals.screenHeight / 2) + 100), new Vector2(200, 50));
            quitButton.buttonTexture = Globals.content.Load<Texture2D>("quitButton");

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

        public void Disable()
        {
            continueButton.Enabled = false;
            continueButton.Visible = false;

            restartButton.Enabled = false;
            restartButton.Visible = false;

            quitButton.Enabled = false;
            quitButton.Visible = false;

            Enabled = false;
            Visible = false;
        }
        public void Enable()
        {
            continueButton.Enabled = true;
            continueButton.Visible = true;

            restartButton.Enabled = true;
            restartButton.Visible = true;

            quitButton.Enabled = true;
            quitButton.Visible = true;

            Enabled = true;
            Visible = true;
        }
    }
}
