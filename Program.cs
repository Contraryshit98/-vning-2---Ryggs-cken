using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_2___Ryggsäcken
{
    class Program
    {
        public static int iterationOfFunktion = 0;
        static void Main(string[] args)
        {
            //läsa ett dokument
            string[][] myWritings = new string[5][];
            myWritings[0] = new string[2] { "", "" };
            Random random = new Random();
            DateTime RandomDay()
            {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Now - start).Days;
                return start.AddDays(random.Next(range));
            }
            myWritings[1] = new string[2] { RandomDay().ToString("mm hh dd MM yy"), "Entry 1" };
            myWritings[2] = new string[2] { RandomDay().ToString(), "Entry 2" };
            myWritings[3] = new string[2] { RandomDay().ToString(), "Entry 3" };
            myWritings[4] = new string[2] { RandomDay().ToString(), "Entry 4" };
            int interactionNumber = 0;

            while (true)
            {
                int myChoice = MainMenu();

                switch (myChoice)
                {
                    case 1:
                        OptionOne(ref myWritings, ref interactionNumber);
                        break;
                    case 2:
                        OptionTwo(ref myWritings, ref interactionNumber);
                        break;
                    case 3:
                        OptionThree(ref myWritings, ref interactionNumber);
                        break;
                    case 4:
                        goto exit_loop;

                    default:
                        Console.WriteLine("OBS vi råkade inte hitta någon lämplig hanling relevant för din inmätning. Försök igen :)");
                        break;
                }

            }


        exit_loop:;

        }

        static int MainMenu()
        {
            Console.WriteLine("\tMenyn");
            Console.WriteLine("[1] Skriv något nytt");
            Console.WriteLine("[2] Ändra ett tidigare inlägg, eller rensa innehållet");
            Console.WriteLine("[3] Skriv ut (och skapa fil)");
            Console.WriteLine("[4] Avsluta");

            Console.Write("Vanligen välj ett alternativ: "); //eller fler
            int myChoice = Convert.ToInt32(Console.ReadLine());

            return myChoice;
        }
        static void OptionOne(ref string[][] myWritings, ref int interactionNumber)
        {
            string nowString = DateTime.Now.ToString("yy MM dd hh:mm");
            if (interactionNumber == 0)
                Console.WriteLine("Var inte blyg - säg vad du har på hjärtat (avsluta med %):");
            else
                Console.WriteLine("Skriv in något (avsluta med %):");
            string writing = Console.ReadLine();

            while (true)
            {

                if ("%".Any(writing.Contains))
                {
                    char[] stringed = writing.ToCharArray();
                    for (int counter = 0; counter < stringed.Length; counter++)
                    {
                        if (stringed[counter] == '%')
                        {
                            StringBuilder restringed = new StringBuilder(writing);
                            restringed.Remove(counter, 1);
                            writing = restringed.ToString();
                            break;
                        }


                    }
                    break;
                }
                writing += ". " + Console.ReadLine();
            }
            bool found = false;
            for (int j = 0; j < myWritings.Length; j++)
            {

                if (myWritings[j][0] == nowString)
                {
                    Array.Resize(ref myWritings[j], myWritings[j].Length + 1);
                    myWritings[j][myWritings[j].Length - 1] = writing;
                    found = true;
                    break;
                }

            }
            if (found == false)
            {
                Array.Resize(ref myWritings, myWritings.Length + 1);
                myWritings[myWritings.Length - 1] = new string[2] { nowString, writing };
            }
            if (myWritings[0][0] == "" && myWritings[0][1] == "" && myWritings[0].Length == 2)
            {
                var firstIndexRemover = new List<string[]>(myWritings);
                firstIndexRemover.RemoveAt(0);
                myWritings = firstIndexRemover.ToArray();
            }

            interactionNumber++;
        }
        static void OptionTwo(ref string[][] myWritings, ref int interactionNumber)
        {
            Console.WriteLine("Vill du ändra något du skrev tidigare idag? (Ja/Nej)");
            string response = (Console.ReadLine().ToLower() == "ja") ? "ja" : null;
            string[] toChange = myWritings[0];
            int loopCount = 0;
            bool isFound = false;
            iterationOfFunktion++;
            if (response != null)
            {
                bool exists = false;
                if (interactionNumber != 0)
                {
                    foreach (string[] s in myWritings)
                    {
                        if (s[0].Remove(8) == DateTime.Now.ToString("yy MM dd"))
                            exists = true;
                    }
                }
                if (exists)
                {
                    toChange = myWritings[myWritings.Length - 1];
                    isFound = true;
                }
                else
                {
                    Console.Write("Du skrev inget tillägg idag, vill du skriva något istället (Ja/Nej)? ");
                    string response2 = (Console.ReadLine().ToLower() == "ja") ? "ja" : null;
                    if (response2 != null)
                    {
                        OptionOne(ref myWritings, ref interactionNumber);
                        iterationOfFunktion = 0;
                        return;
                    }
                    else
                    {
                        iterationOfFunktion = 0;
                        return;
                    }

                }
            }
            else if (iterationOfFunktion > 1)
            {
                iterationOfFunktion = 0;
                return;
            }
            else
            {
                Console.Write("Skriv in datumet på dagen då du adderade tillägget (dd/mm/yy): ");
                string additionTime = Console.ReadLine();

                foreach (string[] s in myWritings)
                {
                    if (s[0].Contains(additionTime))
                    {
                        toChange = s;
                        isFound = true;
                    }
                    loopCount++;
                }

                while (!isFound)
                {
                    Console.Write("Ingen träff. Skriv in datumet igen (dd/mm/yy) eller avbryta med %: ");
                    additionTime = Console.ReadLine();
                    if ("%".Any(additionTime.Contains))
                    {
                        OptionTwo(ref myWritings, ref interactionNumber);
                        return;
                    }
                    foreach (string[] s in myWritings)
                    {
                        if (s[0].Contains(additionTime))
                        {
                            toChange = s;
                            isFound = true;
                        }
                        loopCount++;
                    }
                }

            }

            Console.WriteLine("Här är de tillägg som adderades inom angivna tidpunkten:");
            Console.WriteLine(toChange[0].Remove(8) + ": ");
            for (int i = 1; i < toChange.Length; i++)
            {
                Console.WriteLine("[{0}] " + toChange[i] + ";", i);
            }
            int queryNumber = 1;
            if (toChange.Length > 2)
            {
                Console.Write("Ange siffran på det inlägg du önskar att ändra (1 till {0}): ", myWritings[myWritings.Length - 1].Length - 1);
                queryNumber = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Skriv in det nya innehållet (avsluta med %), eller Avbryta med %&:");
            string writing = Console.ReadLine();
            while (true)
            {
                if ("%".Any(writing.Contains))
                {
                    if (writing.Contains("%&"))
                    {
                        iterationOfFunktion = 0;
                        return;
                    }
                    char[] stringed = writing.ToCharArray();
                    for (int counter = 0; counter < stringed.Length; counter++)
                    {
                        if (stringed[counter] == '%')
                        {
                            StringBuilder restringed = new StringBuilder(writing);
                            restringed.Remove(counter, 1);
                            writing = restringed.ToString();
                            break;
                        }

                    }
                    break;
                }

                writing += ". " + Console.ReadLine();
            }
            toChange[queryNumber] = writing;
            if (loopCount == 0)
                myWritings[myWritings.Length - 1] = toChange;
            else
                myWritings[loopCount - 1] = toChange;

            iterationOfFunktion = 0;
        }
        static void OptionThree(ref string[][] myWritings, ref int interactionNumber)
        {
            if (interactionNumber != 0)
            {
                string[] something = new string[] { "", "" };
                string[][] packaging = myWritings;
                Console.WriteLine("\nHär är allt du skrev:\n\n");
                for (int j = 0; j < myWritings.Length; j++)
                {
                    Console.Write(myWritings[j][0] + ": ");
                    for (int i = 1; i < myWritings[j].Length; i++)
                    {
                        Console.Write(myWritings[j][i] + "; ");

                        StringBuilder stringed = new StringBuilder(myWritings[j][i]);
                        if (myWritings[j][i][myWritings[j][i].Length - 1] == ' ')
                        {
                            stringed.Remove(myWritings[j][i].Length - 1, 1);
                            stringed.Append(".");
                        }
                        else
                            stringed.Append('.', 1);
                        packaging[j][i] = stringed.ToString();

                        if (i == myWritings[j].Length - 1)
                        {
                            Console.Write("\n");
                        }

                    }

                }
            }
            else
            {
                Console.Write("Det är tomt härinne. Du har nyligen inte tillagt något, vill du skriva något (Ja/Nej)? ");
                string response = (Console.ReadLine().ToLower() == "ja") ? "ja" : null;
                if (response != null)
                {
                    int lengthBefore = myWritings.Length;
                    OptionOne(ref myWritings, ref interactionNumber);
                    if (myWritings.Length > lengthBefore)
                        OptionThree(ref myWritings, ref interactionNumber);
                    else
                        return;
                }

            }
        }

    }
}
