using System;

class Program
{
    enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }
    static void Gain(string[] args)
    {

        Difficulty difficulty0 = 0;
        double score = 0;
        Temp(difficulty0, score);
    }

    static void Temp(Difficulty difficulty0, double score)
    {
        

        Console.WriteLine("score: {0}, Difficulty: {1}", score, difficulty0);
        int menu;
        for (int i = 0; ; i++)
        {
            menu = int.Parse(Console.ReadLine());
          
            if (menu == 0)
            {
                gameplay(difficulty0, score);
            }
            else if (menu == 1)
            {
                Setting(score, ref difficulty0);
            }
            else if (menu == 2)
            {
                break;
            }
            else
            {
                Console.WriteLine("please input 0-2");
            }
            break;
        }
    }

    static void Main()

    {
        Difficulty difficulty0 = Difficulty.Easy;
        double score = 0;
        Temp(difficulty0, score); 

    }
    static void Setting(double score, ref Difficulty difficulty0)
    {
        int Select = int.Parse(Console.ReadLine());


        if (Select == 0)
        {
            difficulty0 = Difficulty.Easy;


        }
        else if (Select == 1)
        {
            difficulty0 = Difficulty.Normal;



        }
        else if (Select == 2)
        {
            difficulty0 = Difficulty.Hard;



        }
        else
        {
            Console.WriteLine("Invalid");
            Setting(score, ref difficulty0);
        }

        Temp(difficulty0,score);
    }

    struct Problem
    {
        public string Message;
        public int Answer;

        public Problem(string message, int answer)
        {
            Message = message;
            Answer = answer;
        }
    }
    static Problem[] GenerateRandomProblems(int numProblem)
    {
        Problem[] randomProblems = new Problem[numProblem];

        Random rnd = new Random();
        int x, y;

        for (int i = 0; i < numProblem; i++)
        {
            x = rnd.Next(50);
            y = rnd.Next(50);
            if (rnd.NextDouble() >= 0.5)
                randomProblems[i] =
                new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
            else
                randomProblems[i] =
                new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
        }

        return randomProblems;
    }
    static void gameplay(Difficulty difficulty0, double score)
    {
        int numProblem = 0;
        double dif = 0;
        if (difficulty0 == 0)
        {
            numProblem = 3;
            dif = 0;
        }
        else if (difficulty0 == Difficulty.Normal)
        {
            numProblem = 5;
            dif = 1;
        }
        else if (difficulty0 == Difficulty.Hard)
        {
            numProblem = 7;
            dif = 2;
        }
        Problem[] Gameplay = GenerateRandomProblems(numProblem);

        long x = DateTimeOffset.Now.ToUnixTimeSeconds();
        double correct = 0;
        for (int i = 0; i <= Gameplay.Length - 1; i++)
        {
            Console.WriteLine(Gameplay[i].Message);
            int answers;
            answers = int.Parse(Console.ReadLine());


            if (Gameplay[i].Answer == answers)
            {
                correct++;
            }
        }

        long y = DateTimeOffset.Now.ToUnixTimeSeconds();
        long time = y - x;

        double currentscore;
        currentscore = (correct / numProblem) * ((25 - dif * dif) / Math.Max(time, 25 - dif * dif)) * Math.Pow(2 * dif + 1, 2);
        Console.WriteLine("Your score is: {0}", currentscore);
        score += currentscore;

        Temp(difficulty0, score);
    }
    

}



