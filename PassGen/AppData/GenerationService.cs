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
        private readonly List<string> _patterns;

        public GenerationService(bool useNumbers, bool useSymbols, bool useLower, bool useUpper, bool useWords)
        {
            _patterns = new List<string>();

            if (useNumbers) _patterns.Add(_numbers);
            if (useSymbols) _patterns.Add(_symbols);
            if (useLower) _patterns.Add(_loverCharacters);
            if (useUpper) _patterns.Add(_upperCharacters);

        }

        public List<string> Start(int length, int passwordsCount)
        {



            var passwordSets = new List<string>();

            for (int i = 0; i < passwordsCount; i++)
            {
                string password = string.Empty;

                while (password.Length < length)
                {
                    int patternIndex = _random.Next(0, _patterns.Count);
                    int charIndexFromPattern = _random.Next(0, _patterns[patternIndex].Length);

                    password += _patterns[patternIndex][charIndexFromPattern];
                }
                passwordSets.Add(password);

            }

            return passwordSets;

        }


    }
}






