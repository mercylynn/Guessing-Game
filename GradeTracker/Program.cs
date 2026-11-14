
class Program
{
    static void Main(string[] args)
    {
        string[] studentNames = new string[3];
        double[] scores = new double[3];

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
        double highestScore = scores[0];
        foreach (double score in scores)
        {
            if (score > highestScore)
            {
                highestScore = score;
            }
        }
       return highestScore;
    }

    static double FindLowestScore(double[] scores)
    {
        double lowestScore = scores[0];
        foreach (double score in scores)
        {
            if (score < lowestScore)
            {
                lowestScore = score;
            }
        }
        return lowestScore; 
    }

    static string GetGrade(double score)
    {
        if (percentage <= 49)
        { 
           Console.WriteLine("Grade is D");
        }
        else if (percentage >= 50 && percentage <= 59)
        {
            Console.WriteLine("Grade is C");
        }
        else if (percentage >= 60 && percentage <= 69)
        {
            Console.WriteLine("Grade is B");
        }
        else if (percentage >= 70 && percentage <= 79)
        {
            Console.WriteLine("Grade is B+");
        }
        else if (percentage >= 80)
        {
            Console.WriteLine("Grade is A");
        }
    }

    static void DisplayReport(string[] studentNames, double[] scores)
    {
        
    
    }
}
