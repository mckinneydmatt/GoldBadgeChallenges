using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneRepos
{
    public class CafeRepository
    {
        protected readonly List<CafeContent> _menuDirectory = new List<CafeContent>();

        //create a new menu item
        public bool AddItemToMenu(CafeContent item)
        {
            int startingCount = _menuDirectory.Count;
            _menuDirectory.Add(item);
            return _menuDirectory.Count > startingCount;
        }

        //delete an item
        public bool DeleteItemFromMenu(CafeContent item)
        {
            bool deleteItem = _menuDirectory.Remove(item);
            return deleteItem;
        }

        //get all items on menu
        public List<CafeContent> GetItems()
        {
            return _menuDirectory;
        }

        //get item by meal number
        public CafeContent GetItemByNumber(int mealNumber)
        {
            foreach (CafeContent item in _menuDirectory)
            {
                if (item.MealNumber == mealNumber)
                {
                    return item;
                }
            }
            return null;
        }

        //get item by title
        public CafeContent GetItemByTitle(string mealName)
        {
            foreach (CafeContent item in _menuDirectory)
            {
                if (item.MealName == mealName)
                {
                    return item;
                }
            }
            return null;
        }


    }
}
