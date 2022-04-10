internal class Program
{
    /// <summary>
    /// Prints hangman Figure if wrong answer or prints the previous Hangman figure if correct answer
    /// </summary>
    /// <param name="wrong">amount of times guessed wrong</param>
    private static void PrintHangman(int wrong)
    {
        if (wrong == 0)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine("    |");
            Console.WriteLine("    |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 1)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine("O   |");
            Console.WriteLine("    |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 2)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine("O   |");
            Console.WriteLine("|   |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 3)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine(" O  |");
            Console.WriteLine("/|  |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 4)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine(" O  |");
            Console.WriteLine("/|\\ |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 5)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine(" O  |");
            Console.WriteLine("/|\\ |");
            Console.WriteLine("/   |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 6)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine(" O  |");
            Console.WriteLine("/|\\ |");
            Console.WriteLine("/ \\ |");
            Console.WriteLine("   ===");
        }

        
    }
    /// <summary>
    /// Prints the word and counts the amount of letters and correct letters
    /// </summary>
    /// <param name="guessedLetters">letters guessed</param>
    /// <param name="randomWord">random generated word</param>
    /// <returns></returns>
    private static int PrintWord(List<char>guessedLetters, String randomWord)
    {
        int count = 0;
        int correctChars = 0;
        Console.Write("\r\n");
        foreach (char c in randomWord)
        {
            if (guessedLetters.Contains(c))
            {
                Console.Write(c + " ");
                correctChars++;
            }
            else
            {
                Console.Write(" ");
            }
            count++;
        }
        return correctChars;
    }
    /// <summary>
    /// Prints the lines for the random generated word, either under a correct guessed letter or a "hidden" letter
    /// </summary>
    /// <param name="randomWord">randomly generated word</param>
    private static void PrintLines(String randomWord)
    {
        Console.Write("\r");
        foreach (char c in randomWord)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Write("\u0305 ");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hangman");
        Console.WriteLine("------------------------------------------------------------------------¨");

        Random random = new Random();
        List<string> words = new List<string>() { "gren", "svettas", "ensam", "kniv", "kväll", "pulver", "batteri", "hjärta", "skog", "lejon", "telefon", "morot"};
        int index = random.Next(words.Count);
        String randomWord = words[index];
        // Write the lines under the random word
        foreach (var c in randomWord)
        {
            Console.Write("_ ");
        }

        int lengthOfWord = randomWord.Length;
        int wrongAmount = 0;
        List<char> currentGuessed = new List<char>();
        int currentRight = 0;
        // game loop
        while (wrongAmount != 6 && currentRight != lengthOfWord)
        {
            // guessed letters print
            Console.Write("\nGissade bokstäver: ");
            foreach (var letter in currentGuessed)
            {
                Console.Write(letter + " ");
            }

            Console.Write("\nGissa bokstav: ");
            // Player input
            char guessedLetter = Console.ReadLine()[0];
            // Check if letter have been guessed multiple times
            if (currentGuessed.Contains(guessedLetter))
            {
                Console.Write("Du har redan gissat på den här bokstaven!");
                PrintHangman(wrongAmount);
                currentRight = PrintWord(currentGuessed, randomWord);
                PrintLines(randomWord);
            }
            else
            {
                bool right = false;
                for (int i = 0; i < randomWord.Length; i++)
                {
                    if (guessedLetter == randomWord[i])
                    {
                        right = true;
                    }
                }
                // if guessed right print hangnman and correct letter
                if (right)
                {
                    PrintHangman(wrongAmount);
                    currentGuessed.Add(guessedLetter);
                    currentRight = PrintWord(currentGuessed, randomWord);
                    Console.Write("\r\n");
                    PrintLines(randomWord);
                }
                // same as above but if wrong letter and increase amount of times wrong
                else
                {
                    wrongAmount++;
                    currentGuessed.Add(guessedLetter);
                    PrintHangman(wrongAmount);
                    currentRight = PrintWord(currentGuessed, randomWord);
                    Console.Write("\r\n");
                    PrintLines(randomWord);
                }
            }

        }
        Console.WriteLine("\r\nSpelet är slut!");
    }
}