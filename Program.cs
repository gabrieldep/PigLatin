
public class Program
{
    private static readonly IEnumerable<char> _vowels = new[] { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u', 'Y', 'y' };

    public static void Main()
    {
        string text = "Hey you, you shot 1, but not 2, bullet at my eye!";
        Console.WriteLine(GetTranslation(text));
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
            if (int.TryParse(RemovePunctuation(word), out _))
            {
                traslated += word + " "; 
                continue;
            }

            string prefix = GetPrefix(word);
            string stem = GetStem(prefix, word);
            string sufix = "ay";

            if (IsOnlyVowels(word))
                sufix = "yay";

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
        word = RemovePunctuation(word);
        foreach (var item in word)
            if (!_vowels.Any(v => v == item))
                return false;
        return true;
    }

    private static string RemovePunctuation(string word) => new(word.Where(c => !char.IsPunctuation(c)).ToArray());

    private static string GetStem(string prefix, string word) => word[prefix.Length..];

    private static bool HasPunctuation(string word) => char.IsPunctuation(word[^1]);

    private static bool HasCapitalLetter(string word) => char.IsUpper(word[0]);
}