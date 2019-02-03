using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_2___Ryggsäcken
{
    class Program
    {
        static void Main(string[] args)
        {
            //läsa ett dokument
            //bättre DateTime med minuter och timmar

            string[][] myWritings = new string[5][];
            myWritings[0] = new string[2] { "", "" };
            Random random = new Random();
            DateTime RandomDay()
            {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Now - start).Days;
                return start.AddDays(random.Next(range));
            }
            myWritings[1] = new string[2] { RandomDay().ToString(), "Entry 1" };
            myWritings[2] = new string[2] { RandomDay().ToString(), "Entry 2" };
            myWritings[3] = new string[2] { RandomDay().ToString(), "Entry 3" };
            myWritings[4] = new string[2] { RandomDay().ToString(), "Entry 4" };
            int interactionNumber = 0;

            while (true)
            {

                //Console.WriteLine("\tMenyn");
                //Console.WriteLine("[1] Skriv något nytt");
                //Console.WriteLine("[2] Ändra ett tidigare inlägg, eller rensa innehållet");
                //Console.WriteLine("[3] Skriv ut");
                //Console.WriteLine("[4] Avsluta");

                //Console.Write("Vanligen välj ett alternativ: "); //eller fler
                //int myChoice = Convert.ToInt32(Console.ReadLine());
                int myChoice = MainMenu();
                //DateTime now = DateTime.Now;
                //string nowString = now.ToString("dd MM yy");
                switch (myChoice)
                {
                    case 1:
                        OptionOne(ref myWritings, ref interactionNumber);
                        interactionNumber++;
                        break;
                    case 2:
                        OptionTwo(ref myWritings, ref interactionNumber);
                        break;
                    case 3:
                        Console.WriteLine("\nHär är allt du skrev:\n\n");
                        foreach (string[] s in myWritings)
                        {
                            Console.Write(s[0] + ": ");
                            for (int i = 1; i < s.Length; i++)
                            {
                                StringBuilder stringed = new StringBuilder(s[i]);
                                if (s[i][s[i].Length - 1] == ' ')
                                    stringed.Replace(" ", ".", s[i].Length - 1, 1);
                                else
                                    stringed.Append('.', 1);
                                s[i] = stringed.ToString();

                                Console.Write(s[i] + "; ");
                                if (i == s.Length - 1)
                                {
                                    Console.Write("\n");
                                }

                                //writing += (writing[writing.Length - 1] == ' ') ? ".\n" : " .\n";
                                //writing += Console.ReadLine();
                            }

                        }

                        break;
                    case 4:
                        break;
                        break;
                    default:
                        break;

                }
                if (myChoice == 1)
                {
                    //Console.WriteLine("Var inte blyg - säg vad du har på hjärtat (avsluta med %):");
                    //string writing = Console.ReadLine();

                    //while (true)
                    //{

                    //    if ("%".Any(writing.Contains))
                    //    {
                    //        char[] stringed = writing.ToCharArray();
                    //        for (int counter = 0; counter < stringed.Length; counter++)
                    //        {
                    //            if (stringed[counter] == '%')
                    //            {
                    //                StringBuilder restringed = new StringBuilder(writing);
                    //                restringed.Remove(counter, 1);
                    //                writing = restringed.ToString();
                    //                break;
                    //            }


                    //        }
                    //        break;
                    //    }
                    //    writing += ". " + Console.ReadLine();
                    //}
                    //bool found = false;
                    //for (int j = 0; j < myWritings.Length; j++)
                    //{

                    //    if (myWritings[j][0] == nowString)
                    //    {
                    //        Array.Resize(ref myWritings[j], myWritings[j].Length + 1);
                    //        myWritings[j][myWritings[j].Length - 1] = writing;
                    //        found = true;
                    //        break;
                    //    }

                    //}
                    //if (found == false)
                    //{
                    //    Array.Resize(ref myWritings, myWritings.Length + 1);
                    //    myWritings[myWritings.Length - 1] = new string[2] { nowString, writing };
                    //}
                    //if (myWritings[0][0] == "" && myWritings[0][1] == "" && myWritings[0].Length == 2)
                    //{
                    //    var firstIndexRemover = new List<string[]>(myWritings);
                    //    firstIndexRemover.RemoveAt(0);
                    //    myWritings = firstIndexRemover.ToArray();
                    //}

                    //OptionOne(ref myWritings, ref interactionNumber);
                    //interactionNumber++;
                }
                else if (myChoice == 2)
                {
                    //Console.WriteLine("Vill du ändra något de skrev tidigare idag? (Ja/Nej)");
                    //string response = (Console.ReadLine().ToLower() == "ja") ? "ja" : null;
                    //string[] toChange = myWritings[0];
                    //int loopCount = 0;
                    //if (response != null)
                    //{
                    //    bool exists = false;
                    //    foreach (string[] s in myWritings)
                    //    {
                    //        if (s.Contains(DateTime.Now.ToString("dd MM yy")))
                    //            exists = true;
                    //    }
                    //    if (exists)
                    //        toChange = myWritings[myWritings.Length - 1];
                    //    else
                    //    {
                    //        Console.Write("Du skrev inget tillägg idag, vill du skriva något istället (Ja/Nej)? ");
                    //        string response2 = (Console.ReadLine().ToLower() == "ja") ? "ja" : null;
                    //        if (response2 != null)
                    //            continue;
                    //        else
                    //            continue;
                    //    }
                    //}
                    //else
                    //{
                    //    Console.Write("Skriv in datumet på dagen då du adderade tillägget (dd/mm/yy): ");
                    //    string additionTime = Console.ReadLine();
                    //    foreach (string[] s in myWritings)
                    //    {
                    //        if (s[0] == additionTime)
                    //            toChange = s;
                    //        loopCount++;
                    //    }
                    //}
                    //Console.WriteLine("Här är de tillägg som adderades inom angivna tidpunkten:");
                    //Console.WriteLine(toChange[0] + ": ");
                    //for (int i = 1; i < toChange.Length; i++)
                    //{
                    //    Console.WriteLine("[{0}] " + toChange[i] + ";", i);
                    //}
                    //int queryNumber = 1;
                    //if (toChange.Length > 2)
                    //{
                    //    Console.Write("Ange siffran på det inlägg du önskar att ändra (1 till {0}): ", myWritings[myWritings.Length - 1].Length - 1);
                    //    queryNumber = Convert.ToInt32(Console.ReadLine());
                    //}
                    //Console.WriteLine("Okej, skriv in det nya innehållet (avsluta med %):");
                    //string writing = Console.ReadLine();
                    //while (true)
                    //{
                    //    if ("%".Any(writing.Contains))
                    //    {
                    //        char[] stringed = writing.ToCharArray();
                    //        for (int counter = 0; counter < stringed.Length; counter++)
                    //        {
                    //            if (stringed[counter] == '%')
                    //            {
                    //                StringBuilder restringed = new StringBuilder(writing);
                    //                restringed.Remove(counter, 1);
                    //                writing = restringed.ToString();
                    //                break;
                    //            }


                    //        }
                    //        break;
                    //    }

                    //    writing += ". " + Console.ReadLine();
                    //}
                    //toChange[queryNumber] = writing;
                    //if (loopCount == 0)
                    //    myWritings[myWritings.Length - 1] = toChange;
                    //else
                    //    myWritings[loopCount - 1] = toChange;
                    //OptionTwo(ref myWritings, ref interactionNumber);
                }
                else if (myChoice == 3)
                {

                    //Console.WriteLine("\nHär är allt du skrev:\n\n");
                    //foreach (string[] s in myWritings)
                    //{
                    //    Console.Write(s[0] + ": ");
                    //    for (int i = 1; i < s.Length; i++)
                    //    {
                    //        StringBuilder stringed = new StringBuilder(s[i]);
                    //        if (s[i][s[i].Length - 1] == ' ')
                    //            stringed.Replace(" ", ".", s[i].Length - 1, 1);
                    //        else
                    //            stringed.Append('.', 1);
                    //        s[i] = stringed.ToString();

                    //        Console.Write(s[i] + "; ");
                    //        if (i == s.Length - 1)
                    //        {
                    //            Console.Write("\n");
                    //        }

                    //        //writing += (writing[writing.Length - 1] == ' ') ? ".\n" : " .\n";
                    //        //writing += Console.ReadLine();
                    //    }

                    //}


                }
                else if (myChoice == 4)
                {
                    //break;
                }

            }

            //switch (myChoice) {
            //    case 1:
            //        Console.WriteLine("Var inte blyg - säg vad du har på hjärtat (avsluta med %):");
            //        string writing = "";
            //        while (true) {
            //            writing += Console.ReadLine();
            //            if ("%".Any(writing.Contains))
            //                break;
            //        }
            //        bool found = false;
            //        for (int j = 0; j < counterTime; j++) {

            //            if (myWritings[j][0] == nowString)
            //            {
            //                myWritings[j][counterEntry] = writing;
            //                found = true;
            //                break;
            //            }

            //        }
            //        if (found == false)
            //            myWritings[myWritings.Length + 1] = new string[2] { nowString, writing };


            //        break;
            //    default:
            //        break;
            //}


            foreach (string[] s in myWritings)
            {
                Console.Write(s[0] + ": ");
                for (int i = 1; i < s.Length; i++)
                {
                    Console.Write(s[i] + "; ");
                    if (i == s.Length - 1)
                    {
                        Console.Write("\n");
                    }

                    //writing += (writing[writing.Length - 1] == ' ') ? ".\n" : " .\n";
                    //writing += Console.ReadLine();
                }

            }


            Console.ReadLine();
        }
        static int MainMenu()
        {
            Console.WriteLine("\tMenyn");
            Console.WriteLine("[1] Skriv något nytt");
            Console.WriteLine("[2] Ändra ett tidigare inlägg, eller rensa innehållet");
            Console.WriteLine("[3] Skriv ut");
            Console.WriteLine("[4] Avsluta");

            Console.Write("Vanligen välj ett alternativ: "); //eller fler
            int myChoice = Convert.ToInt32(Console.ReadLine());

            return myChoice;
        }
        static void OptionOne(ref string[][] myWritings, ref int interactionNumber)
        {
            string nowString = DateTime.Now.ToString("dd MM yy");
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

        }
        static void OptionTwo(ref string[][] myWritings, ref int interactionNumber)
        {
            Console.WriteLine("Vill du ändra något de skrev tidigare idag? (Ja/Nej)");
            string response = (Console.ReadLine().ToLower() == "ja") ? "ja" : null;
            string[] toChange = myWritings[0];
            int loopCount = 0;
            bool isFound = false;
            if (response != null)
            {
                bool exists = false;
                foreach (string[] s in myWritings)
                {
                    if (s.Contains(DateTime.Now.ToString("dd MM yy")))
                        exists = true;
                }
                if (exists)
                    toChange = myWritings[myWritings.Length - 1];
                else
                {
                    Console.Write("Du skrev inget tillägg idag, vill du skriva något istället (Ja/Nej)? ");
                    string response2 = (Console.ReadLine().ToLower() == "ja") ? "ja" : null;
                    if (response2 != null)
                    {
                        OptionOne(ref myWritings, ref interactionNumber);
                        return;
                    }
                    else
                        return;
                }
            }
            else
            {
                Console.Write("Skriv in datumet på dagen då du adderade tillägget (dd/mm/yy): ");
                string additionTime = Console.ReadLine();

                foreach (string[] s in myWritings)
                {
                    if (s[0] == additionTime)
                    {
                        toChange = s;
                        isFound = true;
                    }
                    loopCount++;
                }
            }
            if (!isFound)
                return;

            Console.WriteLine("Här är de tillägg som adderades inom angivna tidpunkten:");
            Console.WriteLine(toChange[0] + ": ");
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
                        return;
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
        }

    }
}
