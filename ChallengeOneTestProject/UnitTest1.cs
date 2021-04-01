using ChallengeOneRepos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeOneTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMenuItemTest()
        {
            //arrange
            CafeContent item = new CafeContent();
            CafeRepository repository = new CafeRepository();

            //act
            bool addItem = repository.AddItemToMenu(item);

            //assert
            Assert.IsTrue(addItem);
        }

        private CafeRepository _repo;
        private CafeContent _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeRepository();

            //add a menu item
            _content = new CafeContent("Hamburger", "Meat in between two buns with some toppings", "Meat, bread, lettuce", 1, 2.50);

            //add movie to database
            _repo.AddItemToMenu(_content);
        }

        [TestMethod]
        public void GetItemByName()
        {
            //arrange

            //act

            CafeContent searchResult = _repo.GetItemByTitle("Hamburger");

            //assert
            Assert.AreEqual(_content, searchResult);
        }

        [TestMethod]
        public void GetItemByNumber()
        {
            //act

            CafeContent searchResult = _repo.GetItemByNumber(1);

            //assert
            Assert.AreEqual(_content, searchResult);
        }


        [TestMethod]
        public void RDeleteMenuItemTest()
        {
            //arrange
            CafeContent item = _repo.GetItemByTitle("Hamburger");

            //act
            bool removeItem = _repo.DeleteItemFromMenu(item);

            //assert
            Assert.IsTrue(removeItem);

        }

    }
}
