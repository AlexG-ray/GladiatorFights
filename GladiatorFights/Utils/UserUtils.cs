using System;

namespace GladiatorFights.Utils
{
    internal class UserUtils
    {
        private static readonly Random s_random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            return s_random.Next(min, max);
        }
    }
}
