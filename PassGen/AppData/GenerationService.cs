using System;
using System.Collections.Generic;

namespace PassGen.AppData
{
    internal class GenerationService
    {
        private readonly Random _random = new Random();
        private readonly string _numbers = "1234567890";
        private readonly string _symbols = "!@#$%^&*()_-=";
        private readonly string _loverCharacters = "qwertyuiopasdfghjklzxcvbnm";
        private readonly string _upperCharacters = "QWERTYUIOPASDFGHJKLZXCVBNM";


        public List<string> Start(int length)
        {


            string[] patterns = new string[] { _numbers, _symbols, _loverCharacters, _upperCharacters };
            string password = string.Empty;
            var passwordSets = new List<string>();

            while (password.Length < length)
            {
                int patternIndex = _random.Next(0, patterns.Length);
                int charIndexFromPattern = _random.Next(0, patterns[patternIndex].Length);

                password += patterns[patternIndex][charIndexFromPattern];
            }

            return passwordSets;

        }
    }
}






