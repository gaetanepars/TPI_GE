using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace TPI_BattleBorn
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;

        private const int numberOfLevels = 3;

        public static Game game;

        public LevelComponent level;
        public PlayerComponent player;
        public HUDComponent hud;
        public CursorComponent cursor;

        public MainMenu mainMenu;
        public GameOverMenu gameOverMenu;
        public BonusMenu bonusMenu;
        public VictoryMenu victoryMenu;

        public Texture2D background;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.screenWidth = 1280;
            Globals.screenHeight = 720;

            game = this;

            _graphics.PreferredBackBufferWidth = Globals.screenWidth;
            _graphics.PreferredBackBufferHeight = Globals.screenHeight;
            _graphics.ApplyChanges();

            IsMouseVisible = false;

            LoadNext();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.font = Globals.content.Load<SpriteFont>("Font");
            background = Globals.content.Load<Texture2D>("Background" + Globals.levelIndex);
        }

        protected override void Update(GameTime gameTime)
        {
            Globals.mouse = Mouse.GetState();
            Globals.keyboard = Keyboard.GetState();
            Globals.gameTime = gameTime;
            cursor.position = new Vector2(Globals.mouse.Position.X, Globals.mouse.Position.Y);

            if (Globals.keyboard.IsKeyDown(Keys.Escape))
            {
                foreach(GameComponent component in Components)
                {
                    if (!(component is MainMenu || component is CursorComponent))
                    {
                        ((DrawableGameComponent)component).Enabled = false;
                        ((DrawableGameComponent)component).Visible = false;
                    }
                }
                mainMenu.Enable();
            }

            if (Globals.keyboard.IsKeyDown(Keys.Enter) || mainMenu.continueButton.buttonClicked == true)
            {
                foreach(GameComponent component in Components)
                {
                    if (!(component is MenuComponent || component is CursorComponent || component is ButtonComponent))
                    {
                        ((DrawableGameComponent)component).Enabled = true;
                        ((DrawableGameComponent)component).Visible = true;
                    }
                }
                mainMenu.continueButton.buttonClicked = false;
                mainMenu.Disable();
            }

            if (player!=null && player.experience == 100)
            {
                foreach(GameComponent component in Components)
                {
                    if (!(component is BonusMenu || component is CursorComponent))
                    {
                        ((DrawableGameComponent)component).Enabled = false;
                        ((DrawableGameComponent)component).Visible = false;
                    }
                }
                player.experience = 0;
                bonusMenu.Enable();
                player.playerLevel++;
            }

            if (player != null && player.score==100 && Globals.levelIndex<2)
            {
                player.ResetPlayer();
                LoadNext();
            }

            else if (player!=null && player.score==100 && Globals.levelIndex==2)
            {
                LoadVictory();
            }

            else if (player == null)
            {
                LoadGameOver();
            }

            if (gameOverMenu.restartButton.buttonClicked==true || mainMenu.restartButton.buttonClicked == true || victoryMenu.restartButton.buttonClicked==true)
            {
                Components.Clear();

                Globals.levelIndex = -1;

                LoadNext();
            }

            if(gameOverMenu.quitButton.buttonClicked==true || mainMenu.quitButton.buttonClicked == true || victoryMenu.quitButton.buttonClicked==true)
            {
                Environment.Exit(0);
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            Globals.spriteBatch.Draw(background, new Vector2(0,0), Color.White);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Load the next level and add it to the components list (and the first)
        /// </summary>
        private void LoadNext()
        {
            cursor = new CursorComponent(game, "Cursor", new Vector2(Globals.mouse.Position.X, Globals.mouse.Position.Y), new Vector2(15, 15));
            Components.Add(cursor);

            mainMenu = new MainMenu(game);
            Components.Add(mainMenu);

            gameOverMenu = new GameOverMenu(game);
            Components.Add(gameOverMenu);

            bonusMenu = new BonusMenu(game);
            Components.Add(bonusMenu);

            victoryMenu = new VictoryMenu(game);
            Components.Add(victoryMenu);

            Globals.levelIndex = (Globals.levelIndex + 1) % numberOfLevels;

            if (level == null)
            {
                string levelPath = string.Format("Content/{0}.txt", Globals.levelIndex);
                using (Stream fileStream = TitleContainer.OpenStream(levelPath))
                {
                    level = new LevelComponent(this, fileStream, Globals.levelIndex);
                    Components.Add(level);

                    hud = new HUDComponent(game);
                    Components.Add(hud);
                }
            }
            else
            {
                level.Dispose();
                string levelPath = string.Format("Content/{0}.txt", Globals.levelIndex);
                using (Stream fileStream = TitleContainer.OpenStream(levelPath))
                {
                    level = new LevelComponent(this, fileStream, Globals.levelIndex);
                    Components.Add(level);

                    hud = new HUDComponent(game);
                    Components.Add(hud);
                }
            }
        }

        public void LoadGameOver()
        {
            foreach (GameComponent component in Components)
            {
                if (!(component is GameOverMenu || component is CursorComponent))
                {
                    ((DrawableGameComponent)component).Enabled = false;
                    ((DrawableGameComponent)component).Visible = false;
                }
            }
            gameOverMenu.Enable();
        }

        public void LoadVictory()
        {
            foreach (GameComponent component in Components)
            {
                if (!(component is VictoryMenu || component is CursorComponent))
                {
                    ((DrawableGameComponent)component).Enabled = false;
                    ((DrawableGameComponent)component).Visible = false;
                }
            }

            victoryMenu.Enable();
        }

        public static class Program
        {
            static void Main()
            {
                using (var game = new Game())
                    game.Run();
            }
        }
    }
}
