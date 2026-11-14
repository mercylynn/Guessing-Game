using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] studentNames = new string[3];
        double[] scores = new double[3];
        bool dataEntered = false;
        bool running = true;

        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    EnterStudentData(studentNames, scores);
                    dataEntered = true;
                    break;

                case "2":
                    if (dataEntered)
                        DisplayReport(studentNames, scores);
                    else
                        Console.WriteLine("\nNo data yet. Choose option 1 first.");
                    break;

                case "3":
                    if (dataEntered)
                    {
                        Console.WriteLine($"\nAverage Score: {CalculateAverage(scores):F2}");
                        Console.WriteLine($"Highest Score: {FindHighestScore(scores)}");
                        Console.WriteLine($"Lowest Score: {FindLowestScore(scores)}");
                    }
                    else
                        Console.WriteLine("\nNo data yet. Choose option 1 first.");
                    break;

                case "4":
                    running = false;
                    Console.WriteLine("\nGoodbye!");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Please enter 1, 2, 3 or 4.");
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n========== GRADE TRACKER ==========");
        Console.WriteLine("1. Enter student names and scores");
        Console.WriteLine("2. View full grade report");
        Console.WriteLine("3. View average, highest and lowest");
        Console.WriteLine("4. Quit");
        Console.Write("Choose an option: ");
    }

    static void EnterStudentData(string[] studentNames, double[] scores)
    {
        for (int i = 0; i < studentNames.Length; i++)
        {
            Console.WriteLine($"Enter the name of student {i + 1}:");
            studentNames[i] = Console.ReadLine();

            scores[i] = GetScoreInput(studentNames[i]);
        }
    }

    static double GetScoreInput(string studentName)
    {
        double score;
        while (true)
        {
            Console.WriteLine($"Enter the score for {studentName}:");
            if (double.TryParse(Console.ReadLine(), out score) && score >= 0 && score <= 100)
            {
                return score;
            }
            Console.WriteLine("Invalid score! Enter a number between 0 and 100.");
        }
    }

    static double CalculateAverage(double[] scores)
    {
        double sum = 0;
        foreach (double score in scores)
        {
            sum += score;
        }
        return sum / scores.Length;
    }

    static double FindHighestScore(double[] scores)
    {
        return scores.Max();
    }

    static double FindLowestScore(double[] scores)
    {
        return scores.Min();
    }

    static string GetGrade(double score)
    {
        if (score >= 80)
            return "A";
        else if (score >= 70)
            return "B+";
        else if (score >= 60)
            return "B";
        else if (score >= 50)
            return "C";
        else
            return "D";
    }

    static void DisplayReport(string[] studentNames, double[] scores)
    {
        Console.WriteLine("\n========== STUDENT GRADE REPORT ==========");
        Console.WriteLine("Student Name\tScore\tGrade");
        Console.WriteLine("------------------------------------------");

        for (int i = 0; i < studentNames.Length; i++)
        {
            string grade = GetGrade(scores[i]);

            Console.WriteLine($"{studentNames[i]}\t\t{scores[i]}\t{grade}");
        }

        Console.WriteLine("------------------------------------------");

        Console.WriteLine($"Average Score: {CalculateAverage(scores):F2}");
        Console.WriteLine($"Highest Score: {FindHighestScore(scores)}");
        Console.WriteLine($"Lowest Score: {FindLowestScore(scores)}");
    }
}