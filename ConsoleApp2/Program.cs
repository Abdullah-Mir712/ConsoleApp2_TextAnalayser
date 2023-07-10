using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Prints Frequency of words in sentence");
        Console.WriteLine("2. Make a sentence");
        Console.WriteLine("3. Find long and short word in sentence");
        Console.WriteLine("4. Search words in your Sentence");
        Console.WriteLine("5. Detects Palindrome in sentence");
        Console.WriteLine("6. Counts Vowel and Consonant ");
        Console.Write("Enter your choice (1-6): ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter a sentence:");
                string sentence = Console.ReadLine();
                WordFrequencies(sentence);
                break;

            case 2:
                Console.WriteLine("Enter a Number 'N':");
                int n = int.Parse(Console.ReadLine());
                GenerateSentences(n);
                break;

            case 3:
                Console.WriteLine("Enter a sentence:");
                string sentenceForLength = Console.ReadLine();
                FindLongestAndShortestWords(sentenceForLength);
                break;

            case 4:
                Console.WriteLine("Enter a sentence:");
                string sentenceForSearch = Console.ReadLine();
                Console.WriteLine("Enter a word to search:");
                string wordToSearch = Console.ReadLine();
                SearchWord(sentenceForSearch, wordToSearch);
                break;

            case 5:
                Console.WriteLine("Enter a sentence:");
                string sentenceForPalindrome = Console.ReadLine();
                DetectPalindromes(sentenceForPalindrome);
                break;

            case 6:
                Console.WriteLine("Enter a sentence:");
                string sentenceForVowelsConsonants = Console.ReadLine();
                CountVowelsAndConsonants(sentenceForVowelsConsonants);
                break;

            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        Console.Read();
    }

    static void WordFrequencies(string sentence)
    {
        string[] words = SplitSentenceIntoWords(sentence);
        int[] frequencies = new int[words.Length];
        string[] uniqueWords = new string[words.Length];
        int uniqueWordCount = 0;

        for (int i = 0; i < words.Length; i++)
        {
            bool isDuplicate = false;
            for (int j = 0; j < uniqueWordCount; j++)
            {
                if (words[i] == uniqueWords[j])
                {
                    isDuplicate = true;
                    frequencies[j]++;
                    break;
                }
            }

            if (!isDuplicate)
            {
                uniqueWords[uniqueWordCount] = words[i];
                frequencies[uniqueWordCount] = 1;
                uniqueWordCount++;
            }
        }

        Console.WriteLine("\nWord Frequency:");
        for (int i = 0; i < uniqueWordCount; i++)
        {
            Console.WriteLine($"\"{uniqueWords[i]}\": {frequencies[i]}");
        }
    }

    static string[] SplitSentenceIntoWords(string sentence)
    {
        int wordCount = 1;
        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] == ' ')
            {
                wordCount++;
            }
        }

        string[] words = new string[wordCount];
        int wordIndex = 0;
        int startIndex = 0;

        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] == ' ')
            {
                words[wordIndex] = sentence.Substring(startIndex, i - startIndex);
                wordIndex++;
                startIndex = i + 1;
            }
        }

        words[wordIndex] = sentence.Substring(startIndex);

        return words;
    }

    static void GenerateSentences(int n)
    {
        string[] sentences = new string[n];
        string[] words = { "Hello", "candidate", "welcome", "to", "curemed", "world", "friend" };
        int wordCount = words.Length;
        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            string generatedSentence = "";
            for (int j = 0; j < wordCount; j++)
            {
                int index = random.Next(wordCount);
                generatedSentence += words[index] + " ";
            }
            sentences[i] = generatedSentence.Trim();
        }

        Console.WriteLine("\nGenerated Sentences:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{i + 1}. {sentences[i]}");
        }
    }

    static void FindLongestAndShortestWords(string sentence)
    {
        string[] words = SplitSentenceIntoWords(sentence);
        string longestWord = "";
        string shortestWord = words[0];

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > longestWord.Length)
            {
                longestWord = words[i];
            }

            if (words[i].Length < shortestWord.Length)
            {
                shortestWord = words[i];
            }
        }

        Console.WriteLine($"\nLongest Word: {longestWord}");
        Console.WriteLine($"Shortest Word: {shortestWord}");
    }

    static void SearchWord(string sentence, string word)
    {
        string[] words = SplitSentenceIntoWords(sentence);
        int wordCount = 0;

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == word)
            {
                wordCount++;
            }
        }

        Console.WriteLine($"\nThe word \"{word}\" appears {wordCount} times in the sentence.");

    }

    static void DetectPalindromes(string sentence)
    {
        string[] words = SplitSentenceIntoWords(sentence);

        Console.WriteLine("\nPalindromes in the sentence:");
        foreach (string word in words)
        {
            if (IsPalindrome(word))
            {
                Console.WriteLine(word);
            }
        }
    }

    static bool IsPalindrome(string word)
    {
        int left = 0;
        int right = word.Length - 1;

        while (left < right)
        {
            if (char.ToLower(word[left]) != char.ToLower(word[right]))
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    static void CountVowelsAndConsonants(string sentence)
    {
        string[] words = SplitSentenceIntoWords(sentence);

        Console.WriteLine("\nVowels and Consonants count:");

        for (int i = 0; i < words.Length; i++)
        {
            int wordVowelCount = 0;
            int wordConsonantCount = 0;

            for (int j = 0; j < words[i].Length; j++)
            {
                char ch = char.ToLower(words[i][j]);

                if (ch >= 'a' && ch <= 'z')
                {
                    if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                    {
                        wordVowelCount++;
                    }
                    else
                    {
                        wordConsonantCount++;
                    }
                }
            }

            Console.WriteLine($"\"{words[i]}\": {wordVowelCount} vowel(s) and {wordConsonantCount} consonant(s)");
        }
    }

}
