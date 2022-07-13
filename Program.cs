
public class Program
{
    private static readonly IEnumerable<char> _vowels = new[] { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u', 'Y', 'y' };

    public static void Main()
    {
        string text = "No, littering";
        Console.WriteLine(GetTranslation(text) == "itteringlay " ? "Correct" : "Wrong");
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
            traslated += stem + prefix + "ay ";
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

    private static string GetStem(string prefix, string word) => word[prefix.Length..];
}