using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneRepos
{

    public class CafeContent
    {
        public string MealName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int MealNumber { get; set; }
        public double Price { get; set; }


        public CafeContent() { }
       
        public CafeContent(string mealName, string description, string ingredients, int mealNumber, double price)
        {
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            MealNumber = mealNumber;
            Price = price;
        }
    }
}
