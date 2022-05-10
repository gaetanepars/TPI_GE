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
    public class LevelComponent : DrawableGameComponent
    {
        private Game game;

        private Tile[,] tiles;

        private Vector2 startingPoint;

        private Texture2D background;

        private PlayerCharacter player;

        private bool leveledUp;

        private int playerExperience;
        private int playerLevel;
        private int levelIndex;

        public HUD hud;

        private List<Enemy> enemies = new List<Enemy>();
        private List<Projectile> projectiles = new List<Projectile>();
        private List<Spawner> spawners = new List<Spawner>();

        //PassObject resetLevel;
        //PassObject stateChange;

        Stream fileStream;

        public PlayerCharacter Player
        {
            get { return player; }
        }

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

        public LevelComponent(Game game) : base(game)
        {
            this.game = game;

        }

        public override void Initialize()
        {
            LoadAllTiles(fileStream);
            levelIndex = 0;
            base.Initialize();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            background = Globals.content.Load<Texture2D>("Background" + levelIndex);
            player.Draw();
            DrawAllTiles(spriteBatch);

            for(int i=0; i < projectiles.Count; i++)
            {
                //projectiles[i].Draw();
            }

            for(int i=0; i < enemies.Count; i++)
            {
                //enemies[i].Draw();
            }

            //hud.Draw(this);

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            if (!player.dead && !Globals.paused)
            {
                player.Update();

                if (playerExperience == 10)
                {
                    
                }
                if (leveledUp == true)
                {

                }

                for(int i = 0; i < spawners.Count; i++)
                {
                    //spawners[i].Update();

                    //if (spawners[i].dead)
                    {
                        spawners.RemoveAt(i);
                        i--;
                    }
                }

                for (int i = 0; i < enemies.Count; i++)
                {
                    //enemies[i].Update();

                    //if (enemies[i].dead)
                    {
                        spawners.RemoveAt(i);
                        i--;
                    }
                }

                for (int i = 0; i < projectiles.Count; i++)
                {
                    //projectiles[i].Update(enemies.ToList<Enemy>(),spawners.ToList<Spawner>());

                    //if (projectiles[i].destroyed)
                    {
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }

                //hud.Update(this);
            }

            base.Update(gameTime);
        }

        public void AddEnemy(object INFO)
        {
            enemies.Add((Enemy)INFO);
        }

        public void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile)INFO);
        }

        public void AddSpawner(object INFO)
        {
            spawners.Add((Spawner)INFO);
        }

        private Tile TileConversion(char tileType, int x, int y)
        {
            switch (tileType)
            {
                case '-':
                    return new Tile(null, TileStatus.Passthrough);
                case 'S':
                    return StartTile(x, y);
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
            //player = new PlayerCharacter();
            return new Tile(null, TileStatus.Passthrough);
        }

        private Tile EnemyTile(int x, int y, string spriteSet)
        {
            Vector2 position = new Vector2(x,y);
            //enemies.Add(new Enemy();

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

    }
}
