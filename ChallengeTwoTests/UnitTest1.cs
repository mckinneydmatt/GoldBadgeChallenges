using ChallengeTwoRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeTwoTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddClaimToQueueTest()
        {
            ClaimContent claim = new ClaimContent();
            ClaimRepository repository = new ClaimRepository();
            bool addClaim = repository.AddClaimToQueue(claim);
            Assert.IsTrue(addClaim);
        }

        [TestMethod]
        public void GetClaimsTest()
        {
            ClaimContent claim = new ClaimContent();
            ClaimRepository repository = new ClaimRepository();
            repository.AddClaimToQueue(claim);

            List<ClaimContent> allClaims = repository.GetClaims();

            bool queueHasContent = allClaims.Contains(claim);

            Assert.IsTrue(queueHasContent);
        }

        private ClaimContent _content;
        private ClaimRepository _repository;

        [TestInitializeAttribute]

        public void Arrange()
        {
            _repository = new ClaimRepository();
            _content = new ClaimContent(3, ClaimType.Car, "Blown tire on interstate.", 500.00, new DateTime(2021, 1, 1), new DateTime(2021, 2, 1));

            _repository.AddClaimToQueue(_content);
        }

        [TestMethod]
        public void GetClaimByID()
        {
            ClaimContent searchResult = _repository.GetClaimByID(3);

            Assert.AreEqual(_content, searchResult);
        }

        [TestMethod]
        public void GetClaimByTypeTest()
        {
            ClaimContent searchResult = _repository.GetClaimByType(ClaimType.Car);

            Assert.AreEqual(_content, searchResult);
        }

        [TestMethod]
        public void MUpdateExistingClaimTest()
        {
            ClaimContent newClaim = new ClaimContent(2, ClaimType.Home, "Blown tire on interstate.", 500.00, new DateTime(2021, 1, 1), new DateTime(2021, 2, 1));

            bool updateResult = _repository.UpdateExistingClaim(3, newClaim);

            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void RemoveClaimFromQueueTest()
        {
            ClaimContent claim = _repository.GetClaimByID(3);

            bool removeResult = _repository.RemoveClaimFromQueue(claim);

            Assert.IsTrue(removeResult);
        }


    }
}
