using ChallengeThreeRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeConsoleApp
{
    class ProgramUI
    {
        private readonly BadgesRepository _badgesRepo = new BadgesRepository();

        public void Run()
        {
            SeedBadges();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("What would you like to do? Choose the number for your task:\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadges();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        RunMenu();
                        break;
                }
            }
        }

        
          


        private void AddBadge()
        {
            Console.Clear();
            BadgesContent badge = new BadgesContent();

            Console.WriteLine("Please enter the badge number for the new badge:");

            badge.BadgeID = Int32.Parse(Console.ReadLine());

            List<DoorNames> doorNameList = new List<DoorNames>();

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Please choose a door it needs access to:\n" +
                    "A1\n" +
                    "A2\n" +
                    "A3\n" +
                    "B1\n" +
                    "B2\n" +
                    "B3\n" +
                    "C1\n" +
                    "C2\n" +
                    "C3\n");
                string doorNameWant = Console.ReadLine().ToLower();

                switch (doorNameWant)
                {
                    case "a1":
                        if (doorNameList.Contains(DoorNames.A1))
                        {
                            Console.WriteLine("This badge already has access to that door.");
                            AddBadge();
                        }
                        else
                        {
                            doorNameList.Add(DoorNames.A1);
                        }
                        break;
                    case "a2":
                        if (doorNameList.Contains(DoorNames.A2))
                        {
                            Console.WriteLine("This badge already has access to that door.");
                            AddBadge();
                        }
                        else
                        {
                            doorNameList.Add(DoorNames.A2);
                        }
                        break;
                    case "a3":
                        if (doorNameList.Contains(DoorNames.A3))
                        {
                            Console.WriteLine("This badge already has access to that door.");
                            AddBadge();
                        }
                        else
                        {
                            doorNameList.Add(DoorNames.A3);
                        }
                        break;
                    case "b1":
                        if (doorNameList.Contains(DoorNames.B1))
                        {
                            Console.WriteLine("This badge already has access to that door.");
                            AddBadge();
                        }
                        else
                        {
                            doorNameList.Add(DoorNames.B1);
                        }
                        break;
                    case "b2":
                        if (doorNameList.Contains(DoorNames.B2))
                        {
                            Console.WriteLine("This badge already has access to that door.");
                            AddBadge();
                        }
                        else
                        {
                            doorNameList.Add(DoorNames.B2);
                        }
                        break;
                    case "b3":
                        if (doorNameList.Contains(DoorNames.B3))
                        {
                            Console.WriteLine("This badge already has access to that door.");
                            AddBadge();
                        }
                        else
                        {
                            doorNameList.Add(DoorNames.B3);
                        }
                        break;
                    case "c1":
                        if (doorNameList.Contains(DoorNames.C1))
                        {
                            Console.WriteLine("This badge already has access to that door.");
                            AddBadge();
                        }
                        else
                        {
                            doorNameList.Add(DoorNames.C1);
                        }
                        break;
                    case "c2":
                        if (doorNameList.Contains(DoorNames.C2))
                        {
                            Console.WriteLine("This badge already has access to that door.");
                            AddBadge();
                        }
                        else
                        {
                            doorNameList.Add(DoorNames.C2);
                        }
                        break;
                    case "c3":
                        if (doorNameList.Contains(DoorNames.C3))
                        {
                            Console.WriteLine("This badge already has access to that door.");
                            AddBadge();
                        }
                        else
                        {
                            doorNameList.Add(DoorNames.C3);
                        }
                        break;
                    default:
                        AddBadge();
                        break;
                }



                Console.WriteLine($"You have added {doorNameWant}. Do you want to add another door?\n" +
                     $"Type y or n\n");
                string anotherDoor = Console.ReadLine().ToLower();
                if (anotherDoor == "n")
                {
                    break;
                }

                badge.DoorNameList = doorNameList;

            }

            _badgesRepo.AddNewBadgeToDictionary(badge);
            RunMenu();
        }

        private void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge ID to update?");

            int requestedBadgeID = Int32.Parse(Console.ReadLine());

            List<DoorNames> doors = _badgesRepo.GetDoorsByBadgeID(requestedBadgeID);

            if (doors != null)
            {
                Console.WriteLine($"{requestedBadgeID} has access to: \n");


                foreach (DoorNames doorName in doors)
                {
                    Console.Write(doorName + " \n");
                }
            }
            else
            {
                Console.WriteLine("That badge number wasn't found.");
                Console.ReadKey();
                EditBadge();
            }

            Console.WriteLine($"What would you like to do with {requestedBadgeID}?\n" +
                $"1. Remove a door\n" +
                $"2. Add a door\n");

            string doorInput = Console.ReadLine();

            switch (doorInput)
            {
                case "1":
                    Console.WriteLine("What door would you like to remove? Please enter the door name exactly.");
                 
                    string doorToRemove = Console.ReadLine();

                    DoorNames doorNames = (DoorNames)Enum.Parse(typeof(DoorNames), doorToRemove);


                    if (doors.Contains(doorNames))
                    {
                        doors.Remove(doorNames);
                        Console.WriteLine($"You have removed {doorNames}");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"{requestedBadgeID} doesn't have access to {doorNames}");
                        EditBadge();
                    }


                    break;
                case "2":
                    for (int i = 0; i < 50; i++)
                    {

                        Console.WriteLine("What door would you like to add?\n" +
                       "A1\n" +
                       "A2\n" +
                       "A3\n" +
                       "B1\n" +
                       "B2\n" +
                       "B3\n" +
                       "C1\n" +
                       "C2\n" +
                       "C3\n");

                        string addDoorChoice = Console.ReadLine().ToLower();

                        switch (addDoorChoice)
                        {
                            case "a1":
                                if (doors.Contains(DoorNames.A1))
                                {
                                    Console.WriteLine("This badge already has access to that door.");
                                }
                                else
                                {
                                    doors.Add(DoorNames.A1);
                                    Console.WriteLine("You have added A1.");

                                }
                                break;
                            case "a2":
                                if (doors.Contains(DoorNames.A2))
                                {
                                    Console.WriteLine("This badge already has access to that door.");
                                }
                                else
                                {
                                    doors.Add(DoorNames.A2);
                                    Console.WriteLine("You have added A2.");

                                }
                                break;
                            case "a3":
                                if (doors.Contains(DoorNames.A3))
                                {
                                    Console.WriteLine("This badge already has access to that door.");
                                }
                                else
                                {
                                    doors.Add(DoorNames.A3);
                                    Console.WriteLine("You have added A3.");

                                }
                                break;
                            case "b1":
                                if (doors.Contains(DoorNames.B1))
                                {
                                    Console.WriteLine("This badge already has access to that door.");
                                }
                                else
                                {
                                    doors.Add(DoorNames.B1);
                                    Console.WriteLine("You have added B1.");

                                }
                                break;
                            case "b2":
                                if (doors.Contains(DoorNames.B2))
                                {
                                    Console.WriteLine("This badge already has access to that door.");
                                }
                                else
                                {
                                    doors.Add(DoorNames.B2);
                                    Console.WriteLine("You have added B2.");

                                }
                                break;
                            case "b3":
                                if (doors.Contains(DoorNames.B3))
                                {
                                    Console.WriteLine("This badge already has access to that door.");
                                }
                                else
                                {
                                    doors.Add(DoorNames.B3);
                                    Console.WriteLine("You have added B3.");

                                }
                                break;
                            case "c1":
                                if (doors.Contains(DoorNames.C1))
                                {
                                    Console.WriteLine("This badge already has access to that door.");
                                }
                                else
                                {
                                    doors.Add(DoorNames.C1);
                                    Console.WriteLine("You have added C1.");

                                }
                                break;
                            case "c2":
                                if (doors.Contains(DoorNames.C2))
                                {
                                    Console.WriteLine("This badge already has access to that door.");
                                }
                                else
                                {
                                    doors.Add(DoorNames.C2);
                                    Console.WriteLine("You have added C2.");

                                }
                                break;
                            case "c3":
                                if (doors.Contains(DoorNames.C3))
                                {
                                    Console.WriteLine("This badge already has access to that door.");
                                }
                                else
                                {
                                    doors.Add(DoorNames.C3);
                                    Console.WriteLine("You have added C3.");
                                }
                                break;
                        }

                        Console.WriteLine("Would you like to add another door? Type Y or N");
                        string addAnotherDoorInput = Console.ReadLine().ToLower();

                        if (addAnotherDoorInput == "n")
                        {
                            break;
                        }

                    }
                    _badgesRepo.UpdateDoorsOnBadge(requestedBadgeID, doors);
                    break;
            }
        }

        private void ListBadges()
        {
            Console.Clear();

            Dictionary<int, List<DoorNames>> allBadges = _badgesRepo.GetBadgeDictionary();

            Console.WriteLine($"Badge ID                     Door Access");

            foreach (KeyValuePair<int, List<DoorNames>> kvp in allBadges)
            {
                Console.Write($"{kvp.Key}                        ");
                foreach (DoorNames doorNames in kvp.Value)
                {
                    Console.Write(doorNames + ", ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\nPress any key to continue.");

            Console.ReadKey();
        }



        private void SeedBadges()
        {
            BadgesContent newBadgeOne = new BadgesContent(12345, new List<DoorNames> { DoorNames.A1, DoorNames.B1, DoorNames.C1 });
            BadgesContent newBadgeTwo = new BadgesContent(11111, new List<DoorNames> { DoorNames.A2, DoorNames.B2, DoorNames.C2 });
            
            _badgesRepo.AddNewBadgeToDictionary(newBadgeOne);
            _badgesRepo.AddNewBadgeToDictionary(newBadgeTwo);

        }
    }
}
