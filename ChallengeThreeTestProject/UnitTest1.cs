using ChallengeThreeRepos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThreeTestProject
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void AddNewBadgeToDictionaryTest()
        {
            List<DoorNames> doorNameList = new List<DoorNames>();
            BadgesContent badge = new BadgesContent();
            BadgesRepository repository = new BadgesRepository();

            bool addBadge = repository.AddNewBadgeToDictionary(badge);

            Assert.IsTrue(addBadge);
        }

        private BadgesContent _content;
        private BadgesRepository _repository;


        [TestInitialize]

        public void CArrange()
        {
            _repository = new BadgesRepository();
            _content = new BadgesContent(12345, new List<DoorNames> { DoorNames.A3, DoorNames.B2 });
            _repository.AddNewBadgeToDictionary(_content);

        }

        [TestMethod]
        public void DGetBadgeByIDTest()
        {
            List<DoorNames> doorNameList = _repository.GetDoorsByBadgeID(12345);

            Assert.AreEqual(_content.DoorNameList, doorNameList);
        }

        [TestMethod]
        public void EUpdateDoorsOnBadgeTest()
        {


            BadgesContent badge = new BadgesContent(12345, new List<DoorNames> { DoorNames.A3, DoorNames.B2, DoorNames.C3});

            List<DoorNames> oldDoorNameList = _repository.GetDoorsByBadgeID(badge.BadgeID); 

            Assert.AreEqual(oldDoorNameList.Count, 2);

            bool updateDoors = _repository.UpdateDoorsOnBadge(12345, badge.DoorNameList);

            List<DoorNames> newDoorNameList = _repository.GetDoorsByBadgeID(badge.BadgeID);

            Assert.AreEqual(newDoorNameList.Count, 3);
        }


    }
}
