
public class Program
{
    private static readonly IEnumerable<char> _vowels = new[] { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u', 'Y', 'y' };

    public static void Main()
    {
        Console.WriteLine(GetPrefix("Tdfgest"));
        string? text;
        text = Console.ReadLine();
    }

    private static string GetTranslation(string? text)
    {
        if (string.IsNullOrEmpty(text))
            return "";
        return default;
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
}