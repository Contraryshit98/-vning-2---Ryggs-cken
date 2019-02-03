using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Övning_2___Ryggsäcken
{
    class Program
    {
        public static int iterationOfFunktion = 0;
        static void Main(string[] args)
        {
            //Läsa ett dokument -- Jag hann dock inte bygga in detta,
            //Inte heller hann jag skriva kommentarer till koden.
            //Arbetet var tidsödande och det finns en hel del ändringar
            //som inte var förutbestämda utan jag blev tvungen att införa 
            //efter att ha felsökt programmet. Det är ett halv-hafsat arbete med 
            //grova brott mot den allmännt accepterade praxis, 
            //men på kupen blir koden som i slutänden spys ur mycket mer 
            //funktionell än vad själva uppgiften frågade efter.
            string[][] myWritings = new string[5][];
            myWritings[0] = new string[2] { "", "" };

            //Testvärden
            Random random = new Random();
            DateTime RandomDay()
            {
                DateTime start = new DateTime(1995, 1, 1);
                int rangeD = (DateTime.Now - start).Days;
                int rangeM = (DateTime.Now - start).Minutes;
                return start.AddDays(random.Next(rangeD)).AddMinutes(random.Next(rangeM));
            }
            myWritings[1] = new string[2] { RandomDay().ToString("yy MM dd hh:mm"), "Entry 1" };
            myWritings[2] = new string[2] { RandomDay().ToString("yy MM dd hh:mm"), "Entry 2" };
            myWritings[3] = new string[2] { RandomDay().ToString("yy MM dd hh:mm"), "Entry 3" };
            myWritings[4] = new string[2] { RandomDay().ToString("yy MM dd hh:mm"), "Entry 4" };

            int interactionNumber = 0;

            while (true)
            {
                int[] myChoices = MainMenu();
                foreach (int choice in myChoices)
                {
                    switch (choice)
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
                            Console.WriteLine("OBS vi råkade inte hitta någon lämplig hanling relevant" +
                                " för din inmätning. Försök igen :)");
                            break;
                    }
                }
        
            }

        exit_loop:;

        }
        static int[] MainMenu()
        {
            Console.WriteLine("\tMenyn");
            Console.WriteLine("[1] Skriv något nytt");
            Console.WriteLine("[2] Ändra ett tidigare inlägg, eller rensa innehållet");
            Console.WriteLine("[3] Skriv ut");
            Console.WriteLine("[4] Avsluta");

            Console.Write("Vanligen välj ett alternativ, eller en oordnad sammansättning (1 till 4 eller 1,..,3): "); 
            string[] myChoicesS = Console.ReadLine().Split(',');
            int[] myChoicesI = new int[myChoicesS.Length];
            for (int i = 0; i < myChoicesI.Length; i++)
            {
                if (Regex.IsMatch(myChoicesS[i], @"\d"))
                    myChoicesI[i] = Convert.ToInt32(myChoicesS[i]);
            }
            bool notSorted = true;
            while (notSorted)
            {
                notSorted = false;
                for (int i = 0; i < myChoicesI.Length - 1; i++)
                {
                    if (myChoicesI[i] > myChoicesI[i + 1])
                    {
                        int temp = myChoicesI[i + 1];
                        myChoicesI[i + 1] = myChoicesI[i];
                        myChoicesI[i] = temp;
                        notSorted = true;
                    }
                }
            }

            return myChoicesI;
        }
        static void OptionOne(ref string[][] myWritings, ref int interactionNumber)
        {
            string nowString = DateTime.Now.ToString("yy MM dd hh:mm");
            if (interactionNumber == 0)
                Console.WriteLine("Var inte blyg - säg vad du har på hjärtat (avsluta med %, avbryta med %&):");
            else
                Console.WriteLine("Skriv in något (avsluta med %, avbryta med %&):");

            string[] writing = new string[] { };
            if (InputHandler(ref writing))
                return;
            if (writing.Length > 0)
            {
                bool found = false;
                for (int j = 0; j < myWritings.Length; j++)
                {
                    if (myWritings[j][0] == nowString)
                    {
                        int actualLength = myWritings[j].Length - 1;
                        for (int i = 1; i < writing.Length + 1; i++)
                        {
                            Array.Resize(ref myWritings[j], myWritings[j].Length + 1);
                            myWritings[j][actualLength + i] = writing[i - 1];
                        }
                       
                        
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    Array.Resize(ref myWritings, myWritings.Length + 1);
                    myWritings[myWritings.Length - 1] = new string[] { nowString };
                    int actualLength = myWritings[myWritings.Length - 1].Length - 1;
                    for (int i = 1; i < writing.Length + 1; i++)
                    {
                        Array.Resize(ref myWritings[myWritings.Length - 1], myWritings[myWritings.Length - 1].Length + 1);
                        myWritings[myWritings.Length - 1][actualLength + i] = writing[i - 1];
                    }
                }
                if (myWritings[0][0] == "" && myWritings[0][1] == "" && myWritings[0].Length == 2)
                {
                    var firstIndexRemover = new List<string[]>(myWritings);
                    firstIndexRemover.RemoveAt(0);
                    myWritings = firstIndexRemover.ToArray();
                }

                interactionNumber++;
            }
            else
            {
                Console.WriteLine("Ooops vi råkade inte hinna emotta detta. Försök igen :)");
                OptionOne(ref myWritings, ref interactionNumber);
            }
            
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
            Console.WriteLine("Skriv in det nya innehållet (avsluta med %), Avbryta med %& eller Rensa innehållet %&#:");
            string writing = Console.ReadLine();
            bool remove = false;
            while (true)
            {
                if ("%".Any(writing.Contains))
                {
                    if (writing.Contains("%&#"))
                    {
                        iterationOfFunktion = 0;
                        if (loopCount == 0)
                        {
                            var removed = new List<string>(myWritings[myWritings.Length - 1]);
                            removed.RemoveAt(queryNumber);
                            myWritings[myWritings.Length - 1] = removed.ToArray();
                        }
                        else
                        {
                            var removed = new List<string>(myWritings[loopCount - 1]);
                            removed.RemoveAt(queryNumber);
                            myWritings[loopCount - 1] = removed.ToArray();
                        }    
                        remove = true;
                        break;
                    }
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
            if (!remove)
            {
                toChange[queryNumber] = writing;
                if (loopCount == 0)
                    myWritings[myWritings.Length - 1] = toChange;
                else
                    myWritings[loopCount - 1] = toChange;
            }

            iterationOfFunktion = 0;
        }
        static void OptionThree (ref string[][] myWritings, ref int interactionNumber)
        {
            if (interactionNumber != 0)
            {
                Console.WriteLine("\n\nHär är allt du skrev:\n");
                for (int j = 0; j < myWritings.Length; j++)
                {
                    Console.Write(myWritings[j][0] + ": ");
                    for (int i = 1; i < myWritings[j].Length; i++)
                    {
                        Console.Write(myWritings[j][i] + "; ");
                        if (i == myWritings[j].Length - 1)
                            Console.Write("\n");
                    }
                    if (j == myWritings.Length - 1)
                        Console.Write("\n");
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
        static bool InputHandler(ref string[] writing)
        {
            string[] compound = new string[1];
            int count = 0;
            while (true)
            {
                string temporary = Console.ReadLine();
                if ("%".Any(temporary.Contains))
                {
                    if (temporary.Contains("%&"))
                        return true;
                    char[] stringed = temporary.ToCharArray();
                    StringBuilder restringed = new StringBuilder(temporary);
                    for (int counter = 0; counter < stringed.Length; counter++)
                    {
                        if (stringed[counter] == '%')
                            restringed.Remove(counter, 1);
                    }
                    temporary = restringed.ToString();
                    if (temporary[temporary.Length - 1] == ' ')
                    {
                        temporary = Regex.Replace(temporary, @"[ \t]+$", ".");
                        compound[count] = temporary;
                    }
                    else if (temporary[temporary.Length - 1] != '.')
                        compound[count] = temporary + ".";
                    else
                        compound[count] = temporary;
                    break;
                }
                if (temporary[temporary.Length - 1] == ' ')
                {
                    temporary = Regex.Replace(temporary, @"[ \t]+$", ".");
                    compound[count] = temporary;
                }
                else if (temporary[temporary.Length - 1] != '.')
                    compound[count] = temporary + ".";
                else
                    compound[count] = temporary;
                count++;
                Array.Resize(ref compound, compound.Length + 1);
            }
            writing = compound;
            return false;
        }
    }
}
