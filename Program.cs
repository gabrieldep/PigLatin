namespace KisTechTest
{
    public class Program
    {
        private static readonly char[] _vowels = new[] { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u', 'Y', 'y' };

        public static void Main()
        {
            string? text = "";
            Console.WriteLine(GetTranslation(text) == "" ? "Correct" : "Wrong");
            text = null;
            Console.WriteLine(GetTranslation(text) == "" ? "Correct" : "Wrong");
            text = "Hey you, you shot 1, but not 2, bullet at my eye!";
            Console.WriteLine(GetTranslation(text) == "Eyhay youyay, youyay otshay 1, utbay otnay 2, ulletbay atay ymay eyeyay!" ? "Correct" : "Wrong");
            text = "Stop";
            Console.WriteLine(GetTranslation(text) == "Opstay" ? "Correct" : "Wrong");
            text = "I";
            Console.WriteLine(GetTranslation(text) == "Iyay" ? "Correct" : "Wrong");
            text = "No, littering";
            Console.WriteLine(GetTranslation(text) == "Onay, itteringlay" ? "Correct" : "Wrong");
            text = "No shirts, no shoes, no service";
            Console.WriteLine(GetTranslation(text) == "Onay irtsshay, onay oesshay, onay ervicesay" ? "Correct" : "Wrong");
            text = "No persons under 14 admitted";
            Console.WriteLine(GetTranslation(text) == "Onay ersonspay underay 14 admitteday" ? "Correct" : "Wrong");
            text = "Hey buddy, get away from my car!";
            Console.WriteLine(GetTranslation(text) == "Eyhay uddybay, etgay awayay omfray ymay arcay!" ? "Correct" : "Wrong");
        }

        private static string GetTranslation(string? text)
        {
            string traslated = "";
            if (string.IsNullOrEmpty(text))
                return traslated;

            string[] words = GetListWords(text);
            foreach (string word in words)
            {
                if (IsNumber(word) || string.IsNullOrEmpty(word))
                {
                    traslated += word + " ";
                    continue;
                }

                string prefix = GetPrefix(word);
                string stem = GetStem(prefix, word);
                string sufix = IsOnlyVowels(word) ? "yay" : "ay";

                if (HasPunctuation(word))
                {
                    char punct = word[^1];
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
            return traslated[0..^1];
        }

        private static string GetPrefix(string word)
        {
            string prefix = "";
            foreach (char c in word)
            {
                if (IsVowel(c))
                    break;
                prefix += c;
            }
            return prefix;
        }

        private static string[] GetListWords(string text) => text.Split(" ");

        private static string GetStem(string prefix, string word) => word[prefix.Length..];

        private static bool IsOnlyVowels(string word) => RemovePunctuation(word).All(c => IsVowel(c));

        private static bool IsVowel(char c) => _vowels.Any(v => v == c);

        private static string RemovePunctuation(string word) => new(word.Where(c => !char.IsPunctuation(c)).ToArray());

        private static bool IsNumber(string word) => int.TryParse(RemovePunctuation(word), out _);

        private static bool HasPunctuation(string word) => char.IsPunctuation(word[^1]);

        private static bool HasCapitalLetter(string word) => char.IsUpper(word[0]);
    }
}