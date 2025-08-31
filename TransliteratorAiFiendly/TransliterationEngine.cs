
using System;
using System.Collections.Generic;
using System.Linq;

namespace TransliteratorApp
{
    public class TransliterationEngine
    {
        private readonly Dictionary<string, string> plToCyr = new Dictionary<string, string>
        {
            {"sz", "ш"},{"cz", "ч"},{"dz", "дз"},{"dź", "дь"},{"rz", "ж"},{"ja", "Я"},{"ju", "Ю"},{"ia", "Я"},{"je", "Е"},{"ie", "Е"},{"e", "Э"},
            {"a", "а"},{"b", "б"},{"c", "ц"},{"ć", "ч"},{"d", "д"},{"f", "ф"},{"g", "г"},{"ch", "х"},{"h", "х"},{"i", "и"},{"j", "й"},
            {"k", "к"},{"l", "л"},{"ł", "л"},{"m", "м"},{"n", "н"},{"ń", "нь"},{"o", "о"},{"p", "п"},{"r", "р"},{"s", "с"},{"t", "т"},
            {"u", "у"},{"w", "в"},{"y", "ы"},{"z", "з"},{"ź", "зь"},{"ż", "ж"}
        };

        private readonly Dictionary<string, string> cyrToPl = new Dictionary<string, string>
        {
            {"ш", "sz"},{"ч", "ć"},{"дз", "dz"},{"дь", "dź"},{"ж", "ż"},{"Я", "ja"},{"Ю","ju"},{"Е", "je"},{"Э", "e"},
            {"а", "a"},{"б", "b"},{"ц", "c"},{"д", "d"},{"ф", "f"},{"г", "g"},{"х", "h"},{"и", "i"},{"й", "j"},{"к", "k"},
            {"л", "l"},{"м", "m"},{"н", "n"},{"нь", "ń"},{"о", "o"},{"п", "p"},{"р", "r"},{"с", "s"},{"т", "t"},{"у", "u"},
            {"в", "w"},{"ы", "y"},{"з", "z"},{"зь", "ź"}
        };

        public string ToCyrillic(string input)
        {
            string result = input.ToLower();
            var keys = plToCyr.Keys.OrderByDescending(k => k.Length);
            foreach (var key in keys)
            {
                result = result.Replace(key, plToCyr[key]);
            }
            return result;
        }

        public string ToPolish(string input)
        {
            string result = input;
            var keys = cyrToPl.Keys.OrderByDescending(k => k.Length);
            foreach (var key in keys)
            {
                result = result.Replace(key, cyrToPl[key]);
            }
            return result;
        }
    }
}
