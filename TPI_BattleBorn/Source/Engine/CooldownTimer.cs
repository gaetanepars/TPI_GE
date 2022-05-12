using System;
using System.Collections.Generic;
using System.Text;

namespace TPI_BattleBorn
{
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

        public bool Test()
        {
            if (timer.TotalMilliseconds >= milliseconds || timeUp){
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddTime(int Milliseconds)
        {
            timer+=TimeSpan.FromMilliseconds(Milliseconds);
        }

        public void ResetTime()
        {
            timer = TimeSpan.Zero;
            timeUp = false;
        }

        public void SetTime(TimeSpan Time)
        {
            timer = Time;
        }

    }
}
