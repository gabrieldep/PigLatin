using System;
using System.Linq;
namespace KisTechTest
{
    public class Program
    {
        private static readonly char[] _vowels = new[] { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u', 'Y', 'y' };

        public static void Main()
        {
            Verify("Hey you, you shot 1, but not 2, bullet at my eye!", "Eyhay youyay, youyay otshay 1, utbay otnay 2, ulletbay atay ymay eyeyay!");
            Verify("Stop", "Opstay");
            Verify("I", "Iyay");
            Verify("No, littering", "Onay, itteringlay");
            Verify("No shirts, no shoes, no service", "Onay irtsshay, onay oesshay, onay ervicesay");
            Verify("No persons under 14 admitted", "Onay ersonspay underay 14 admitteday");
            Verify("Hey buddy, get away from my car!", "Eyhay uddybay, etgay awayay omfray ymay arcay!");
        }

        /// <summary>
        /// Get the translation of a text
        /// </summary>
        /// <param name="text">Text to be translated</param>
        /// <returns>The text translation</returns>
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

        /// <summary>
        /// Get the string formed from the beginning of the word up to, but not including, the first vowel.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get a string array from an original string splited by a space
        /// </summary>
        /// <param name="text">Text to split</param>
        /// <returns>A string array formed by the split of text</returns>
        private static string[] GetListWords(string text) => text.Split(" ");

        /// <summary>
        /// Remove the prefix from the string
        /// </summary>
        /// <param name="word">String formed by prefix + stem</param>
        /// <param name="prefix">Prefix to remove from the string</param>
        /// <returns>The string after remove the prefix</returns>
        private static string GetStem(string prefix, string word) => word[prefix.Length..];

        /// <summary>
        /// Removes all puctuation from the string
        /// </summary>
        /// <param name="word">String to remove the punctuation</param>
        /// <returns>The string without any punctuation</returns>
        private static string RemovePunctuation(string word) => new(word.Where(c => !char.IsPunctuation(c)).ToArray());

        /// <summary>
        /// Verify if the string is formed only by vowels or "y"
        /// </summary>
        /// <param name="word">String to verify</param>
        /// <returns>True if the string is formed only by vowels "y", if isn't returns False</returns>
        private static bool IsOnlyVowels(string word) => RemovePunctuation(word).All(c => IsVowel(c));

        /// <summary>
        /// Verify if the char is a vowel or "y"
        /// </summary>
        /// <param name="c">The char to verify</param>
        /// <returns>True if the char is a vowel or "y", if isn't returns False</returns>
        private static bool IsVowel(char c) => _vowels.Any(v => v == c);

        /// <summary>
        /// Verify if the string is a number
        /// </summary>
        /// <param name="word">String to verify</param>
        /// <returns>True if the string is a number, if isn't returns False</returns>
        private static bool IsNumber(string word) => int.TryParse(RemovePunctuation(word), out _);

        /// <summary>
        /// Verify if the last char is a punctuation
        /// </summary>
        /// <param name="word">The string to verify</param>
        /// <returns>True if the last char is a punctuation, if isn't returns False</returns>
        private static bool HasPunctuation(string word) => char.IsPunctuation(word[^1]);

        /// <summary>
        /// Verify if the first letter of the word is in Capital Letter
        /// </summary>
        /// <param name="word">The word to verify</param>
        /// <returns>True if the first letter is Upper, if is Lower returns False</returns>
        private static bool HasCapitalLetter(string word) => char.IsUpper(word[0]);

        /// <summary>
        /// Print on command line if the return of GetTranslation is correct
        /// </summary>
        /// <param name="text">Text to translate</param>
        /// <param name="translated">The correct translation</param>
        private static void Verify(string? text, string translated)
        {
            string translation = GetTranslation(text);
            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"Translation: {translation}");
            Console.WriteLine(translation.Equals(translated) ? "Correct" : "Wrong");
            Console.WriteLine();
        }
    }
}