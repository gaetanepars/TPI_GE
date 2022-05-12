using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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


        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Globals.screenWidth = 1600;
            Globals.screenHeight = 900;

            game = this;

            _graphics.PreferredBackBufferWidth = Globals.screenWidth;
            _graphics.PreferredBackBufferHeight = Globals.screenHeight;
            _graphics.ApplyChanges();

            IsMouseVisible = false;

            LoadNext();

            Components.Add(level);
            player = new PlayerComponent(this,"Player",new Vector2(level.startingPoint.X, level.startingPoint.Y),new Vector2(50,50));
            Components.Add(player);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            Globals.mouse = Mouse.GetState();
            Globals.keyboard = Keyboard.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

        private void LoadNext()
        {
            Globals.levelIndex = (Globals.levelIndex + 1) % numberOfLevels;

            if (level == null)
            {
                string levelPath = string.Format("Content/{0}.txt", Globals.levelIndex);
                using (Stream fileStream = TitleContainer.OpenStream(levelPath))
                {
                    level = new LevelComponent(this, Services, fileStream, Globals.levelIndex);
                }

            }
            else
            {
                level.Dispose();
                string levelPath = string.Format("Content/{0}.txt", Globals.levelIndex);
                using (Stream fileStream = TitleContainer.OpenStream(levelPath))
                {
                    level = new LevelComponent(this, Services, fileStream, Globals.levelIndex);
                }
            }
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
