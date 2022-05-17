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

        public static SpriteFont font;

        public static MouseState mouse;
        public static KeyboardState keyboard;

        public static int gameState = 0;

        public static int screenWidth;
        public static int screenHeight;
        
        public static int bonusHP;
        public static int bonusMana;
        public static int bonusSpeed;

        public static bool paused;

        public static int levelIndex=-1;

        public static float GetDistance(Vector2 position, Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(position.X - target.X, 2) + Math.Pow(position.Y - target.Y, 2));
        }

        public static Vector2 RadialMovement(Vector2 focus, Vector2 position, float speed)
        {
            float distance = Globals.GetDistance(position, focus);

            if(distance <= speed)
            {
                return focus - position;
            }
            else
            {
                return (focus - position) * speed / distance;
            }
        }

        public static float RotateTo(Vector2 position, Vector2 focus)
        {
            float h;
            float sineTheta;
            float angle;

            if (position.Y - focus.Y != 0)
            {
                h = (float)Math.Sqrt(Math.Pow(position.X - focus.X, 2) + Math.Pow(position.Y - focus.Y, 2));
                sineTheta = (float)(Math.Abs(position.Y - focus.Y) / h);
            }
            else
            {
                h = position.X - focus.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);

            if (position.X - focus.X > 0 && position.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI * 3 / 2 + angle);
            }
            else if (position.X - focus.X > 0 && position.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI * 3 / 2 - angle);
            }
            else if (position.X - focus.X < 0 && position.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI / 2 - angle);
            }
            else if (position.X - focus.X < 0 && position.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI / 2 + angle);
            }
            else if (position.X - focus.X > 0 && position.Y - focus.Y == 0)
            {
                angle = (float)Math.PI * 3 / 2;
            }
            else if (position.X - focus.X < 0 && position.Y - focus.Y == 0)
            {
                angle = (float)Math.PI / 2;
            }
            else if (position.X - focus.X == 0 && position.Y - focus.Y > 0)
            {
                angle = (float)0;
            }
            else if (position.X - focus.X == 0 && position.Y - focus.Y < 0)
            {
                angle = (float)Math.PI;
            }
            return angle;
        }
    }
}
