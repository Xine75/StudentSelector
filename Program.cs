using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentSelector
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> Students1 = System.IO.File.ReadAllLines("studentList.txt").ToList();


            CallOnStudents();
            // Again();

            void CallOnStudents()
            {
                List<string> notCalledOn = new List<string>(Students1);
                List<string> alreadyCalledOn = new List<string>();

                while (alreadyCalledOn.Count < Students1.Count)
                {
                    var random = new Random();
                    var candidate = random.Next(0, Students1.Count);

                    if (notCalledOn.Contains(Students1[candidate]))
                    {
                        alreadyCalledOn.Add(Students1[candidate]);
                        notCalledOn.Remove(Students1[candidate]);


                        var candidateString = String.Join(", ", Students1[candidate]);
                        var notCalledOnString = String.Join(", ", notCalledOn);
                        var alreadyCalledOnString = String.Join(", ", alreadyCalledOn);

                        Console.WriteLine("You Have NOT Called On: ");
                        Console.WriteLine("------------------------------------------------------------");
                        Console.WriteLine(notCalledOnString);
                        Console.WriteLine();

                        Console.WriteLine("You've Already Called On: ");
                        Console.WriteLine("------------------------------------------------------------");
                        Console.WriteLine(alreadyCalledOnString);
                        Console.WriteLine();

                        Console.Write("UP NEXT: ");
                        Console.WriteLine(candidateString);
                        Console.WriteLine();

                        Console.WriteLine("*Press any key to continue*");

                        Console.ReadLine();
                        Console.Clear();
                    }

                    else if (notCalledOn.Count == 0)
                    {
                        Console.WriteLine("You've called on all the students. Start over? Y/N?");

                        string answer = Console.ReadLine().ToLower();
                        while (answer != "y" && answer != "n")
                        {
                            Console.Write("Please select Y or N.");
                            answer = Console.ReadLine().ToLower();
                        }

                        if (answer == "y")
                        {
                            CallOnStudents();
                        }
                        else
                        {
                            Console.WriteLine("Thank you and good-bye!");
                            return;
                        }

                    }
                }
            }
        }
    }
}

