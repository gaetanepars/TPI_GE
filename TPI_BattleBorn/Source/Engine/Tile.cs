using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public enum TileStatus
    {
        //Units can go through
        Passthrough=0,
        //Units are blocked by this
        Solid=1,
    }

    public struct Tile
    {
        //Texture of the tile
        public Texture2D texture;
        //Status of said tile
        public TileStatus status;

        //Dimensions of the tile
        public const int tileWidth = 60;
        public const int tileHeight = 60;
        public static Vector2 Size = new Vector2(tileWidth, tileHeight);

        public Tile(Texture2D Texture, TileStatus Status)
        {
            texture = Texture;
            status = Status;
        }

    }
}
