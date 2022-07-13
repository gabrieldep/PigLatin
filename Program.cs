
public class Program
{
    private static readonly IEnumerable<char> _vowels = new[] { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u', 'Y', 'y' };

    public static void Main()
    {
        string text = "Iaue";
        Console.WriteLine(GetTranslation(text) == "Iaueyay " ? "Correct" : "Wrong");
        Console.WriteLine(GetTranslation(text) == "Onay, itteringlay " ? "Correct" : "Wrong");
        text = "No shirts, no shoes, no service";
        Console.WriteLine(GetTranslation(text) == "Onay irtsshay, onay oesshay, onay ervicesay " ? "Correct" : "Wrong");
    }

    private static IEnumerable<string> GetListWords(string text) => text.Split(" ");

    private static string GetTranslation(string? text)
    {
        string traslated = "";
        if (string.IsNullOrEmpty(text))
            return "";

        var words = GetListWords(text);
        foreach (string word in words)
        {
            var prefix = GetPrefix(word);
            var stem = GetStem(prefix, word);
            var sufix = "ay";

            if (IsOnlyVowels(word))
            {
                sufix = "yay";
            }

            if (HasPunctuation(word))
            {
                char punct = word[word.Length - 1];
                stem = stem[0..^1];
                sufix += punct;
            }
            if (HasCapitalLetter(word))
            {
                prefix = prefix.ToLower();
                stem = char.ToUpper(stem[0]) + stem[1..];
            }

            traslated += stem + prefix + sufix + " ";
        }
        return traslated;
    }

    private static string GetPrefix(string word)
    {
        string prefix = "";
        foreach (var item in word)
        {
            if (_vowels.Any(v => v == item))
                break;
            prefix += item;
        }
        return prefix;
    }

    private static bool IsOnlyVowels(string word)
    {
        foreach (var item in word)
            if (!_vowels.Any(v => v == item))
                return false;
        return true;
    }

    private static string GetStem(string prefix, string word) => word[prefix.Length..];

    private static bool HasPunctuation(string word) => char.IsPunctuation(word[^1]);

    private static bool HasCapitalLetter(string word) => char.IsUpper(word[0]);
}