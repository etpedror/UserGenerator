using System.Collections.Generic;

namespace UserGenerator
{
    public static class Phonetic
    {
        /// <summary>
        /// A table with the phonetic representations of each character
        /// </summary>
        public static Dictionary<string,string> Table = new()
        {
            { "a", "alpha" },
            { "b", "bravo" },
            { "c", "charlie" },
            { "d", "delta" },
            { "e", "echo" },
            { "f", "foxtrot" },
            { "g", "golf" },
            { "h", "hotel" },
            { "i", "india" },
            { "j", "juliet" },
            { "k", "kilo" },
            { "l", "lima" },
            { "m", "mike" },
            { "n", "november" },
            { "o", "oscar" },
            { "p", "papa" },
            { "q", "quebec" },
            { "r", "romeo" },
            { "s", "sierra" },
            { "t", "tango" },
            { "u", "uniform" },
            { "v", "victor" },
            { "w", "whiskey" },
            { "x", "x-ray" },
            { "y", "yankee" },
            { "z", "zulu" },

            { "A", "(CAPITAL)ALPHA" },
            { "B", "(CAPITAL)BRAVO" },
            { "C", "(CAPITAL)CHARLIE" },
            { "D", "(CAPITAL)DELTA" },
            { "E", "(CAPITAL)ECHO" },
            { "F", "(CAPITAL)FOXTROT" },
            { "G", "(CAPITAL)GOLF" },
            { "H", "(CAPITAL)HOTEL" },
            { "I", "(CAPITAL)INDIA" },
            { "J", "(CAPITAL)JULIET" },
            { "K", "(CAPITAL)KILO" },
            { "L", "(CAPITAL)LIMA" },
            { "M", "(CAPITAL)MIKE" },
            { "N", "(CAPITAL)NOVEMBER" },
            { "O", "(CAPITAL)OSCAR" },
            { "P", "(CAPITAL)PAPA" },
            { "Q", "(CAPITAL)QUEBEC" },
            { "R", "(CAPITAL)ROMEO" },
            { "S", "(CAPITAL)SIERRA" },
            { "T", "(CAPITAL)TANGO" },
            { "U", "(CAPITAL)UNIFORM" },
            { "V", "(CAPITAL)VICTOR" },
            { "W", "(CAPITAL)WHISKEY" },
            { "X", "(CAPITAL)X-RAY" },
            { "Y", "(CAPITAL)YANKEE" },
            { "Z", "(CAPITAL)ZULU" },

            { "0", "ZERO" },
            { "1", "ONE" },
            { "2", "TWO" },
            { "3", "THREE" },
            { "4", "FOUR" },
            { "5", "FIVE" },
            { "6", "SIX" },
            { "7", "SEVEN" },
            { "8", "EIGHT" },
            { "9", "NINE" },


            { "!", "<EXCLAMATION>" },
            { "$", "<DOLLAR>" },
            { "%", "<PERCENT>" },
            { "^", "<CIRCUMFLEX>" },
            { "&", "<AMPERSAND>" },
            { "*", "<ASTERISK>" },
            { "(", "<OPEN_PARENTHESIS>" },
            { ")", "<CLOSE_PARENTHESIS>" },
            { "{", "<OPEN_CURLY_BRACE>" },
            { "}", "<CLOSE_CURLY_BRACE>" },
            { "[", "<OPEN_SQUARE_BRACKET>" },
            { "]", "<CLOSE_SQUARE_BRACKET>" },
            { ",", "<COMMA>" },
            { ".", "<PERIOD>" },
        };
    }
    
}