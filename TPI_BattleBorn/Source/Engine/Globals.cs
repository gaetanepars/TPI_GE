using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class Globals
    {
        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static GameTime gameTime;

        public static MouseState mouse;
        public static KeyboardState keyboard;

        public static int screenWidth;
        public static int screenHeight;
        
        public static int bonusHP;
        public static int bonusMana;
        public static int bonusSpeed;

        public static bool paused;
    }
}
