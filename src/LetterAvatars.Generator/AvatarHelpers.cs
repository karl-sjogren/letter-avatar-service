using System;
using System.Text.RegularExpressions;

namespace LetterAvatars.Generator {
    public static class AvatarHelpers {
        public static string CleanName(string name) {
            if(string.IsNullOrWhiteSpace(name))
                return null;

            name = name.ToUpperInvariant();
            name = name.Trim(',', '!', ';', '"', '\'', '#', '%', '&', '(', ')', '=', '?');
            name = Regex.Replace(name, @"\p{Cs}", string.Empty); // Remove emojis
            name = name.Trim();

            var invalidChars = System.IO.Path.GetInvalidFileNameChars();
            foreach(var invalidChar in invalidChars)
                name = name.Replace(invalidChar, '-');

            while(name.Contains("--"))
                name = name.Replace("--", "-");

            return name;
        }

        public static string GetAvatarLetters(string name) {
            name = CleanName(name);
            if(string.IsNullOrWhiteSpace(name))
                return null;

            var split = name.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var first = split[0][0];
            var last = '-';
            if(split.Length > 1)
                last = split[split.Length - 1][0];

            var text = first + (last == '-' ? string.Empty : last.ToString());

            return text;
        }
    }
}
