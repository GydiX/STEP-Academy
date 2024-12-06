using System;
using System.Collections.Generic;

public class DictionaryManager
{
    private Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

    public void AddWord(string englishWord, List<string> frenchTranslations)
    {
        if (!dictionary.ContainsKey(englishWord))
        {
            dictionary[englishWord] = new List<string>(frenchTranslations);
            Console.WriteLine($"Слово {englishWord} додано.");
        }
        else
        {
            Console.WriteLine("Таке слово вже існує.");
        }
    }

    public void RemoveWord(string englishWord)
    {
        if (dictionary.Remove(englishWord))
        {
            Console.WriteLine($"Слово {englishWord} видалено.");
        }
        else
        {
            Console.WriteLine("Слово не знайдено.");
        }
    }

    public void RemoveTranslation(string englishWord, string frenchTranslation)
    {
        if (dictionary.TryGetValue(englishWord, out List<string> translations))
        {
            if (translations.Remove(frenchTranslation))
            {
                Console.WriteLine($"Переклад {frenchTranslation} для слова {englishWord} видалено.");
            }
            else
            {
                Console.WriteLine("Переклад не знайдено.");
            }
        }
        else
        {
            Console.WriteLine("Слово не знайдено.");
        }
    }

    public void UpdateWord(string oldWord, string newWord)
    {
        if (dictionary.TryGetValue(oldWord, out List<string> translations))
        {
            dictionary.Remove(oldWord);
            dictionary[newWord] = translations;
            Console.WriteLine($"Слово {oldWord} змінено на {newWord}.");
        }
        else
        {
            Console.WriteLine("Слово не знайдено.");
        }
    }

    public void UpdateTranslation(string englishWord, string oldTranslation, string newTranslation)
    {
        if (dictionary.TryGetValue(englishWord, out List<string> translations))
        {
            int index = translations.IndexOf(oldTranslation);
            if (index != -1)
            {
                translations[index] = newTranslation;
                Console.WriteLine($"Переклад {oldTranslation} змінено на {newTranslation}.");
            }
            else
            {
                Console.WriteLine("Переклад не знайдено.");
            }
        }
        else
        {
            Console.WriteLine("Слово не знайдено.");
        }
    }

    public void FindTranslations(string englishWord)
    {
        if (dictionary.TryGetValue(englishWord, out List<string> translations))
        {
            Console.WriteLine($"Переклади для {englishWord}: {string.Join(", ", translations)}");
        }
        else
        {
            Console.WriteLine("Слово не знайдено.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        DictionaryManager manager = new DictionaryManager();
        manager.AddWord("hello", new List<string> { "bonjour", "salut" });
        manager.AddWord("book", new List<string> { "livre" });

        manager.FindTranslations("hello");
        manager.UpdateTranslation("hello", "salut", "coucou");
        manager.FindTranslations("hello");

        manager.RemoveTranslation("book", "livre");
        manager.FindTranslations("book");

        manager.RemoveWord("hello");
        manager.FindTranslations("hello");
    }
}
