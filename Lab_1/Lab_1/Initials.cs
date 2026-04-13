using System;

namespace Lab1
{
    class Initials
    {
        private char _firstChar;
        private char _secondChar;

        public char FirstChar
        {
            get
            {
                return _firstChar;
            }
            set
            {
                _firstChar = value;
            }
        }

        public char SecondChar
        {
            get
            {
                return _secondChar;
            }
            set
            {
                _secondChar = value;
            }
        }

        public Initials()
        {
            _firstChar = 'A';
            _secondChar = 'B';
        }

        public Initials(char first, char second)
        {
            this._firstChar = first;
            this._secondChar = second;
        }

        public Initials(Initials other)
        {
            this._firstChar = other._firstChar;
            this._secondChar = other._secondChar;
        }

        public string CreateString()
        {
            string result = "Символ 1: " + _firstChar.ToString() +
                ", Символ 2: " + _secondChar.ToString();
            return result;
        }

        public override string ToString()
        {
            return "Инициалы: " + _firstChar + "." + _secondChar + ".";
        }
    }
}