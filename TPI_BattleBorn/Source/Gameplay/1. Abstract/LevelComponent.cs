using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TPI_BattleBorn
{
    //Level component, basically the environnement where the game happens
    public class LevelComponent : DrawableGameComponent
    {
        private Tile[,] tiles;

        public Vector2 startingPoint;

        private Texture2D background;

        public HUDComponent hud;

        private List<EnemyComponent> enemies = new List<EnemyComponent>();
        private List<ProjectileComponent> projectiles = new List<ProjectileComponent>();
        private List<SpawnerComponent> spawners = new List<SpawnerComponent>();

        private bool hasWon;
        public bool HasWon
        {
            get { return hasWon; }
        }

        public int Width
        {
            get { return tiles.GetLength(0); }
        }

        public int Height
        {
            get { return tiles.GetLength(1); }
        }

        public LevelComponent(Game game, IServiceProvider services, Stream fileStream, int levelIndex) : base(game)
        {
            LoadAllTiles(fileStream);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            background = Globals.content.Load<Texture2D>("Background" + Globals.levelIndex);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Draw(background, new Vector2(Globals.screenWidth, Globals.screenHeight), Color.White);
            DrawAllTiles(Globals.spriteBatch);
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void AddEnemy(object INFO)
        {
            enemies.Add((EnemyComponent)INFO);
        }

        public void AddProjectile(object INFO)
        {
            projectiles.Add((ProjectileComponent)INFO);
        }

        public void AddSpawner(object INFO)
        {
            spawners.Add((SpawnerComponent)INFO);
        }

        private Tile TileConversion(char tileType, int x, int y)
        {
            switch (tileType)
            {
                case '-':
                    return new Tile(null, TileStatus.Passthrough);
                case 'S':
                    return StartTile(x, y);
                case 'X':
                    return EnemyTile(x, y, "Enemy1");
                case 'Y':
                    return EnemyTile(x, y, "Enemy2");
                case '*':
                    return EnemyTile(x, y, "Spawner1");
                case '"':
                    return EnemyTile(x, y, "Spawner2");
                case '#':
                    return LoadTile("Obstacle", TileStatus.Solid);
                default:
                    throw new NotSupportedException(String.Format("Error handling tiles"));
            }
        }

        private Tile LoadTile(string name, TileStatus status)
        {
            return new Tile(Globals.content.Load<Texture2D>(name), status);
        }

        private Tile StartTile(int x, int y)
        {
            startingPoint = new Vector2(x,y);
            
            return new Tile(null, TileStatus.Passthrough);
        }

        private Tile EnemyTile(int x, int y, string spriteSet)
        {
            Vector2 position = new Vector2(x, y);

            Game.Components.Add(new EnemyComponent(TPI_BattleBorn.Game.game, spriteSet ,position,new Vector2(60,60)));
            return new Tile(null, TileStatus.Passthrough);
        }

        private Tile SpawnerTile(int x, int y, string spriteSet)
        {
            Vector2 position = new Vector2(x, y);

            //Game.Components.Add(new SpawnerComponent(TPI_BattleBorn.Game.game, spriteSet, position, new Vector2(60, 60)));
            return new Tile(null, TileStatus.Passthrough);
        }

        public Rectangle GetTileRectangle(int x, int y)
        {
            return new Rectangle(x * Tile.tileWidth, y * Tile.tileHeight, Tile.tileWidth, Tile.tileHeight);
        }

        private void LoadAllTiles(Stream fileStream)
        {
            int width;
            List<string> lines = new List<string>();

            using(StreamReader reader = new StreamReader(fileStream))
            {
                string line = reader.ReadLine();
                width = line.Length;
                while (line != null)
                {
                    lines.Add(line);
                    if (line.Length != width)
                    {
                        throw new Exception(String.Format("Level Dimension Error"));
                    }
                    line = reader.ReadLine();
                }
            }
            tiles = new Tile[width, lines.Count];
            for(int y = 0; y < Height; y++)
            {
                for(int x = 0; x < Width; x++)
                {
                    char tileType = lines[y][x];
                    tiles[x, y] = TileConversion(tileType, x, y);
                }
            }
        }

        private void DrawAllTiles(SpriteBatch spriteBatch)
        {
            for(int y = 0; y < Height; y++)
            {
                for(int x = 0; x < Width; x++)
                {
                    Texture2D texture = tiles[x, y].texture;
                    if (texture != null)
                    {
                        Vector2 position = new Vector2(x * Tile.Size.X, y * Tile.Size.Y);
                        spriteBatch.Draw(texture, position, Color.White);
                    }
                }
            }
        }

        public TileStatus GetCollision(int x, int y)
        {
            if (x >= Width || x < 0 || y >= Height || y > 0 )
            {
                return TileStatus.Solid;
            }

            return tiles[x, y].status;
        }

    }
}
