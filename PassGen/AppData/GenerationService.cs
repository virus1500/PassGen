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
        private int _point = 0;
        public string rel = "";
        public GenerationService(bool useNumbers, bool useSymbols, bool useLower, bool useUpper, bool useWords)
        {
            _patterns = new List<string>();

            if (useNumbers)
            {
                _patterns.Add(_numbers);
                _point++;
            }
            if (useSymbols)
            {
                _patterns.Add(_symbols);
                _point++;
            }

            if (useLower)
            {
                _patterns.Add(_loverCharacters);
                _point++;
            }
            if (useUpper)
            {
                _patterns.Add(_upperCharacters);
                _point++;
            }


        }



        public List<string> Start(int length, int passwordsCount)
        {

            if (length <= 9)
            {
                _point = 0;
            }
            else if (length >= 10 && length <= 16) { _point = _point + 1; }
            else if (length >= 17 && length <= 25) { _point = _point + 2; }
            else if (length >= 26 && length <= 33) { _point = _point + 3; }

            if (_point == 0) { rel = "Ненадёжный"; }
            if (_point == 2) { rel = "надёжный"; }
            if (_point == 3) { rel = "Nадёжный"; }
            if (_point == 6) { rel = "ИДЕАЛЬНЫЙ"; }

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






