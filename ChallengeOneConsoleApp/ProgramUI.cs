using ChallengeOneRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneConsoleApp
{
    public class ProgramUI
    {
        private readonly CafeRepository _menuRepo = new CafeRepository();
        
        public void Run()
        {
            SeedMenu();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("What would you like to do?\n" +
                    "Choose the number of the option you want:\n" +
                    "1. Add a new menu item\n" +
                    "2. Delete a menu item\n" +
                    "3. View all items on the menu\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ShowAllMenuItems();
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

        private void AddNewMenuItem()
        {
            Console.Clear();
            CafeContent menu = new CafeContent();

            Console.WriteLine("Press any key to begin adding a new menu item.");
            Console.ReadKey();

            Console.WriteLine("Please enter a name for the meal:");
            menu.MealName = Console.ReadLine();

            Console.WriteLine("Please enter a description for the meal:");
            menu.Description = Console.ReadLine();

            Console.WriteLine("Please enter the ingredients:");
            menu.Ingredients = Console.ReadLine();

            Console.WriteLine("Please enter the associated meal number:");
            menu.MealNumber = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the price for the meal:");
            menu.Price = double.Parse(Console.ReadLine());

            _menuRepo.AddItemToMenu(menu);
        }


        private void DeleteMenuItem()
        {
            Console.Clear();

            Console.WriteLine("Which menu item would you like to remove?");

            List<CafeContent> menuList = _menuRepo.GetItems();

            int count = 0;

            foreach (CafeContent menuItem in menuList)
            {
                count++;
                Console.WriteLine($"{count}. {menuItem.MealName}");
            }

            int targetItemID = int.Parse(Console.ReadLine());
            int targetIndex = targetItemID - 1;

            if (targetIndex >= 0 && targetIndex < menuList.Count)
            {
                CafeContent desiredItem = menuList[targetIndex];

                if (_menuRepo.DeleteItemFromMenu(desiredItem))
                {
                    Console.WriteLine($"{desiredItem.MealName} was removed.");
                }
            }
            else
            {
                Console.WriteLine("No item by that name found.");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void ShowAllMenuItems()
        {
            Console.Clear();
            List<CafeContent> menuItems = _menuRepo.GetItems();
            foreach (CafeContent item in menuItems)
            {
                DisplayMenu(item);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void DisplayMenu(CafeContent item)
        {
            
            Console.WriteLine($"Title: {item.MealName}\n" +
                $"Description: {item.Description}\n" +
                $"Ingredients: {item.Ingredients}\n" +
                $"Meal Number: {item.MealNumber}\n" +
                $"Price: {item.Price}\n" +
                $"");
        }

        private void SeedMenu()
        {
            CafeContent hamburger = new CafeContent("Hamburger", "Beef patty between two toasted buns with lettuce, tomato, onion and pickles", "Beef, buns, lettuce, tomato, onion, pickles", 1, 6.99);
            CafeContent spaghetti = new CafeContent("Spaghetti", "Pasta with red sauce with meatballs", "Spaghetti, marinara, beef", 2, 5.99);
            CafeContent cake = new CafeContent("Cake", "Chocolate cake with chocolate frosting", "Flour, sugar, milk, eggs", 4, 9.99);
            CafeContent steak = new CafeContent("Steak", "Filet mignon cooked to medium rare, with a baked potato and seasoned vegetables", "Filet mignon, potato, vegetables", 3, 19.99);

            _menuRepo.AddItemToMenu(hamburger);
            _menuRepo.AddItemToMenu(steak);
            _menuRepo.AddItemToMenu(spaghetti);
           _menuRepo.AddItemToMenu(cake);

        }


    }
}
