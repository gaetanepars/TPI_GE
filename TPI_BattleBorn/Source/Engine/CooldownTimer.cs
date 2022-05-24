using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
    /// <summary>
    /// Timer class used to handle all cooldowns in the game (attack cooldown, spell cooldown,etc...) and limit the spamming of menus and stuff of that nature
    /// </summary>
    public class CooldownTimer
    {
        public bool timeUp;
        public int milliseconds;
        public TimeSpan timer = new TimeSpan();

        public CooldownTimer(int Milliseconds)
        {
            timeUp = false;
            milliseconds = Milliseconds;
        }

        public void Update()
        {
            timer += Globals.gameTime.ElapsedGameTime;
        }

        /// <summary>
        /// Test if the timer is up
        /// </summary>
        /// <returns></returns>
        public bool Test()
        {
            if (timer.TotalMilliseconds >= milliseconds || timeUp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Allow to add time to the timer so that an event can start sooner or later for the first time for example
        /// </summary>
        /// <param name="Milliseconds"></param>
        public void AddTime(int Milliseconds)
        {
            timer += TimeSpan.FromMilliseconds(Milliseconds);
        }

        /// <summary>
        /// reset the timer to zero
        /// </summary>
        public void ResetTime()
        {
            timer = TimeSpan.Zero;
            timeUp = false;
        }

        /// <summary>
        /// set the timer to a specific time
        /// </summary>
        /// <param name="Time"></param>
        public void SetTime(TimeSpan Time)
        {
            timer = Time;
        }

    }
}
