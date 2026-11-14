
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

}
