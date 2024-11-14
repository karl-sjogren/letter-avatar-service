using System.Text.RegularExpressions;

namespace LetterAvatars.Generator;

public static partial class AvatarHelpers {
    public static string? CleanName(string? name) {
        if(string.IsNullOrWhiteSpace(name)) {
            return null;
        }

        name = name.ToUpperInvariant();
        name = name.Trim(',', '!', ';', '"', '\'', '#', '%', '&', '(', ')', '=', '?');
        name = EmojiRegex().Replace(name, string.Empty); // Remove emojis
        name = name.Trim();

#pragma warning disable IO0006 // Replace Path class with IFileSystem.Path for improved testability
        var invalidChars = Path.GetInvalidFileNameChars();
#pragma warning restore IO0006 // Replace Path class with IFileSystem.Path for improved testability
        foreach(var invalidChar in invalidChars)
            name = name.Replace(invalidChar, '-');

        while(name.Contains("--", StringComparison.Ordinal))
            name = name.Replace("--", "-", StringComparison.Ordinal);

        return name;
    }

    public static string? GetAvatarLetters(string? name) {
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

    [GeneratedRegex(@"\p{Cs}")]
    private static partial Regex EmojiRegex();
}
