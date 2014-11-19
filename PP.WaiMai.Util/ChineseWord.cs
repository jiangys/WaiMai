using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Util
{
    /// <summary>
    /// 汉字相关
    /// </summary>
    public static class ChineseWord
    {
        /// <summary>
        /// 获取字符的拼音字母
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string GetSpellingChar(char word)
        {

            var array = Encoding.Default.GetBytes(new char[] { word });
            var index = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));

            if (index < 0xB0A1)
                return "*";
            if (index < 0xB0C5)
                return "A";
            if (index < 0xB2C1)
                return "B";
            if (index < 0xB4EE || word == '重')
                return "C";
            if (index < 0xB6EA)
                return "D";
            if (index < 0xB7A2)
                return "E";
            if (index < 0xB8C1)
                return "F";
            if (index < 0xB9FE)
                return "G";
            if (index < 0xBBF7)
                return "H";
            if (index < 0xBFA6)
                return "J";
            if (index < 0xC0AC)
                return "K";
            if (index < 0xC2E8)
                return "L";
            if (index < 0xC4C3)
                return "M";
            if (index < 0xC5B6)
                return "N";
            if (index < 0xC5BE)
                return "O";
            if (index < 0xC6DA)
                return "P";
            if (index < 0xC8BB)
                return "Q";
            if (index < 0xC8F6)
                return "R";
            if (index < 0xCBFA)
                return "S";
            if (index < 0xCDDA)
                return "T";
            if (index < 0xCEF4)
                return "W";
            if (index < 0xD1B9)
                return "X";
            if (index < 0xD4D1)
                return "Y";
            if (index < 0xD7FA || word == '圳')
                return "Z";

            return "*";
        }
        /// <summary>
        /// 获取字符的没每一个字的拼音字母
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetAbbreviativeSpelling(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;

            string result = "";

            char[] array = name.ToCharArray();
            foreach (var word in array)
            {
                int ascii = (int)word;
                if (ascii >= 33 && ascii <= 126)
                {
                    result = string.Concat(result, word.ToString());
                }
                else
                {
                    result = string.Concat(result, GetSpellingChar(word));
                }
            }
            return result;
        }
    }
}
