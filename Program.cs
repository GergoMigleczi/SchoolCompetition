using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchoolCompetition
{
    struct TestAnswer
    {
        public string IdOfCandidate;
        public string answerOfTheCandidate;

        public TestAnswer(string IdOfCandidate, string answerOfTheCandidate)
        {
            this.IdOfCandidate = IdOfCandidate;
            this.answerOfTheCandidate = answerOfTheCandidate;
        }
    }
    class SchoolCompetition
    {
        static string rightAnswer = "";
        static List<TestAnswer> answers = new List<TestAnswer>();

        //Task 1: Read and store the data of valaszok.txt
        static void Feladat1()
        {
            StreamReader sr = new StreamReader("valaszok.txt");
            rightAnswer = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split();
                string IdOfCandidate = line[0];
                string answerOfTheCandidate = line[1];

                TestAnswer item = new TestAnswer(IdOfCandidate, answerOfTheCandidate);
                answers.Add(item);
            }

            sr.Close();
        }

        //Task 2: Print the number of participants who took part in the test
        static void Feladat2()
        {
            Console.Write("Task 2:");

            Console.WriteLine($"Number of participants {answers.Count}.");
        }

        //Task 3: Ask the user to type in an ID of a participant
        //        You can assume that the user will type in an ID contained by the txt
        static string ID = "";
        static string answerOfTheCandidate = "";
        static void Fealdat3()
        {
            Console.Write("Task 3: ID of participant (AB123)= ");
            ID = Console.ReadLine();

            foreach (TestAnswer item in answers)
            {
                if (item.IdOfCandidate == ID)
                {
                    answerOfTheCandidate = item.answerOfTheCandidate;
                    Console.WriteLine($"{item.answerOfTheCandidate}\t(answer of the participant)");
                }
            }
        }

        //Task 4: Print the right answer and print a + below each answer the participant choosen in the task before got right
        static void Feladat4()
        {
            Console.WriteLine("Task 4:");
            Console.WriteLine($"{rightAnswer}\t(right answer)");
            for (int i = 0; i < answerOfTheCandidate.Length; i++)
            {
                if (answerOfTheCandidate[i] == rightAnswer[i])
                {
                    Console.Write("+");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine("\t(correct answers of the participant)");

        }

        //Task 5: Ask the user to type in the number of a task, and calculate how many participants got it right
        static void Feladat5()
        {
            Console.Write("Task 5: Number of the task = ");
            int numberOfTask = int.Parse(Console.ReadLine());

            int numberOfRightAnswers = 0;

            foreach (TestAnswer item in answers)
            {
                if (item.answerOfTheCandidate[numberOfTask - 1] == rightAnswer[numberOfTask - 1])
                {
                    numberOfRightAnswers++;
                }
            }

            Console.WriteLine($"There were {numberOfRightAnswers} right answers, {Math.Round((double)numberOfRightAnswers / answers.Count * 100, 2)}% of teh participants answered right.");
        }

        //Task 6: Print the points of each participant in the pontok.txt
        static int first = 0;
        static int second = 0;
        static int third = 0;
        static void Feladat6()
        {
            Console.WriteLine("Task 6: Calculating the points of each participant");

            StreamWriter sw = new StreamWriter("pontok.txt");

            int points;


            foreach (TestAnswer item in answers)
            {
                points = 0;
                for (int i = 0; i < item.answerOfTheCandidate.Length; i++)
                {
                    if (item.answerOfTheCandidate[i] == rightAnswer[i])
                    {
                        if (i < 5)
                            points += 3;
                        else if (i < 10)
                            points += 4;
                        else if (i < 13)
                            points += 5;
                        else if (i == 13)
                            points += 6;
                    }
                }
                if (points > first)
                {
                    third = second;
                    second = first;
                    first = points;
                }
                else if (points > second && points != first)
                {
                    third = second;
                    second = points;
                }
                else if (points > third && points != second)
                {
                    third = points;
                }
                sw.WriteLine($"{item.IdOfCandidate} {points}");
            }

            sw.Flush();
            sw.Close();
        }

        //Print the participants' ID with the three highest score
        static void Feladat7()
        {
            Console.WriteLine("Task 7: Top 3");

            int points;
            int[] Top3 = { first, second, third };

            for (int j = 0; j < Top3.Length; j++)
            {
                foreach (TestAnswer item in answers)
                {
                    points = 0;
                    for (int i = 0; i < item.answerOfTheCandidate.Length; i++)
                    {
                        if (item.answerOfTheCandidate[i] == rightAnswer[i])
                        {
                            if (i < 5)
                                points += 3;
                            else if (i < 10)
                                points += 4;
                            else if (i < 13)
                                points += 5;
                            else if (i == 13)
                                points += 6;
                        }
                    }
                    if (points == Top3[j])
                    {
                        Console.WriteLine($"{j + 1} place ({Top3[j]} point) : {item.IdOfCandidate}");
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            Feladat1();
            Console.WriteLine();
            Feladat2();
            Console.WriteLine();
            Fealdat3();
            Console.WriteLine();
            Feladat4();
            Console.WriteLine();
            Feladat5();
            Console.WriteLine();
            Feladat6();
            Console.WriteLine();
            Feladat7();
            Console.ReadKey();
        }
    }
}
