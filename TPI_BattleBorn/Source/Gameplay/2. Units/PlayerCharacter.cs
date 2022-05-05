using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    public class PlayerCharacter
    {
        public bool dead;
        public int maxHealth;
        public int health;
        public int speed;

        public Vector2 position;

        CooldownTimer attackTimer = new CooldownTimer();
        CooldownTimer spellTimer = new CooldownTimer();

        public PlayerCharacter(string Path, Vector2 Position, Vector2 Dimensions)
        {
            health = 5;
            maxHealth = health;
            speed = 2;
            ResetPlayer();
        }

        public void ResetPlayer()
        {
            health = 5;
            speed = 2;
            dead = false;

        }

        public void Update()
        {
            if (Globals.keyboard.IsKeyDown(Keys.W))
            {
                position = new Vector2(position.X, position.Y - speed);
            }
            if (Globals.keyboard.IsKeyDown(Keys.S))
            {
                position = new Vector2(position.X, position.Y + speed);
            }
            if (Globals.keyboard.IsKeyDown(Keys.A))
            {
                position = new Vector2(position.X - speed, position.Y);
            }
            if (Globals.keyboard.IsKeyDown(Keys.D))
            {
                position = new Vector2(position.X + speed, position.Y);
            }

            if (Globals.mouse.LeftButton == ButtonState.Pressed)
            {

            }

            if (Globals.mouse.RightButton == ButtonState.Pressed)
            {

            }
        }

        public void PlayerCollision()
        {

        }

        public void Death()
        {

        }

    }
    
}
