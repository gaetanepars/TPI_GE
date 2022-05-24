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

        public HUDComponent hud;

        public int Width
        {
            get { return tiles.GetLength(0); }
        }

        public int Height
        {
            get { return tiles.GetLength(1); }
        }

        public LevelComponent(Game game, Stream fileStream, int levelIndex) : base(game)
        {
            DrawOrder = 1;
            LoadAllTiles(fileStream);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            Globals.spriteBatch.Begin();
            DrawAllTiles(Globals.spriteBatch);
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Calls the corresponding function for each type of tile depending on what is in the text file
        /// </summary>
        /// <param name="tileType"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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
                    return SpawnerTile(x, y, "Spawner1");
                case '"':
                    return SpawnerTile(x, y, "Spawner2");
                case '#':
                    return LoadTile("Obstacle", TileStatus.Solid);
                default:
                    throw new NotSupportedException(String.Format("Error handling tiles"));
            }
        }

        /// <summary>
        /// Load a specific tile
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        private Tile LoadTile(string name, TileStatus status)
        {
            return new Tile(Globals.content.Load<Texture2D>(name), status);
        }

        /// <summary>
        /// Set the starting point of the player to the position of that null tile and add it to the components list
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private Tile StartTile(int x, int y)
        {
            startingPoint = RectangleExtension.GetBottomCenter(GetTileRectangle(x, y));

            TPI_BattleBorn.Game.game.player = new PlayerComponent(TPI_BattleBorn.Game.game, "Player", new Vector2(startingPoint.X,startingPoint.Y), new Vector2(50, 50));
            TPI_BattleBorn.Game.game.Components.Add(TPI_BattleBorn.Game.game.player);

            return new Tile(null, TileStatus.Passthrough);
        }

        /// <summary>
        /// Set the initial position of an enemy to the position of the tile and adds the correct enemy to the components list
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="spriteSet"></param>
        /// <returns></returns>
        private Tile EnemyTile(int x, int y, string spriteSet)
        {
            Vector2 enemyPosition = RectangleExtension.GetBottomCenter(GetTileRectangle(x, y));

            if (spriteSet == "Enemy1")
            {
                TPI_BattleBorn.Game.game.Components.Add(new Enemy1(TPI_BattleBorn.Game.game, new Vector2(enemyPosition.X,enemyPosition.Y)));
            }
            else if (spriteSet == "Enemy2")
            {
                TPI_BattleBorn.Game.game.Components.Add(new Enemy2(TPI_BattleBorn.Game.game, new Vector2(enemyPosition.X,enemyPosition.Y)));
            }
            return new Tile(null, TileStatus.Passthrough);
        }

        /// <summary>
        /// Set the initial position of a spawner to the position of the tile and adds the correct spawner to the components list
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="spriteSet"></param>
        /// <returns></returns>
        private Tile SpawnerTile(int x, int y, string spriteSet)
        {
            Vector2 spawnerPosition = RectangleExtension.GetBottomCenter(GetTileRectangle(x, y));

            if (spriteSet == "Spawner1")
            {
                TPI_BattleBorn.Game.game.Components.Add(new Spawner1(TPI_BattleBorn.Game.game,new Vector2(spawnerPosition.X, spawnerPosition.Y)));
            }
            else if (spriteSet == "Spawner2")
            {
                TPI_BattleBorn.Game.game.Components.Add(new Spawner2(TPI_BattleBorn.Game.game, new Vector2(spawnerPosition.X, spawnerPosition.Y)));
            }
            
            return new Tile(null, TileStatus.Passthrough);
        }
   
        /// <summary>
        /// gives the position of the tile's rectangle
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Rectangle GetTileRectangle(int x, int y)
        {
            return new Rectangle(x * Tile.tileWidth, y * Tile.tileHeight, Tile.tileWidth, Tile.tileHeight);
        }

        /// <summary>
        /// Read the lines of a text file to make the grid
        /// </summary>
        /// <param name="fileStream"></param>
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
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
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
            return tiles[x, y].status;
        }

    }
}
