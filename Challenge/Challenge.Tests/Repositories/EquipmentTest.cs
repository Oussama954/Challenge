using System;
using System.Data.Entity;
using Challenge.Dal;
using Challenge.Dal.Interfaces;
using Challenge.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Challenge.Tests.Repositories
{
    [TestClass]
    public class EquipmentTest
    {
        private IEquipmentRepository _repo;
        private Mock<DbSet<Equipment>> _mockSet;
        [TestInitialize()]
        public void InitTest()
        {
            _mockSet = new Mock<DbSet<Equipment>>();
            var mockContext = new Mock<ChallengeContext>();
            mockContext.Setup(c => c.Set<Equipment>()).Returns(_mockSet.Object);
            _repo = new EquipmentRepository(mockContext.Object);
        }
        [TestMethod]
        public void TestAdd()
        {
            var equipment = new Equipment
            {
                SerialNumber = 1,
                Name = "equipment1",
                NextControlDate = new DateTime(),
            };
            _repo.Add(equipment);
            _mockSet.Verify(m => m.Add(It.IsAny<Equipment>()), Times.Once());
        }

        [TestMethod]
        public void TestGet()
        {
            _repo.Get(1);
            _mockSet.Verify(m => m.Find(It.IsAny<object[]>()));
        }
        [TestMethod]
        public void TestRemove()
        {
            var equipment = new Equipment
            {
                SerialNumber = 1,
                Name = "equipment1",
                NextControlDate = new DateTime(),
            };
            _repo.Remove(equipment);
            _mockSet.Verify(m => m.Remove(It.IsAny<Equipment>()), Times.Once());
        }

    }
}
