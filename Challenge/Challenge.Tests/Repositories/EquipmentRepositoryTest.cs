using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Challenge.Dal;
using Challenge.Dal.Interfaces;
using Challenge.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Challenge.Tests.Repositories
{
    [TestClass]
    public class EquipmentRepositoryTest
    {
        private IEquipmentRepository _mockEquipmentRepository;
        private Mock<DbSet<Equipment>> _mockSet;
        private IEquipmentRepository _repo;

        [TestInitialize]
        public void InitTest()
        {
            _mockSet = new Mock<DbSet<Equipment>>();
            var mockContext = new Mock<ChallengeContext>();
            mockContext.Setup(c => c.Set<Equipment>()).Returns(_mockSet.Object);
            _repo = new EquipmentRepository(mockContext.Object);
            var equipments = new List<Equipment>
            {
                new Equipment
                {
                    SerialNumber = 1,
                    Name = "equipment1",
                    NextControlDate = new DateTime(2020, 6, 5)
                },
                new Equipment
                {
                    SerialNumber = 2,
                    Name = "equipment2",
                    NextControlDate = new DateTime(2020, 6, 6)
                },
                new Equipment
                {
                    SerialNumber = 3,
                    Name = "equipment3",
                    NextControlDate = new DateTime(2020, 6, 7)
                }
            };
            var mockEquipmentRepository = new Mock<IEquipmentRepository>();
            mockEquipmentRepository
                .Setup(eq => eq.OrderBy(x => x.SerialNumber, 1, 2))
                .Returns(
                    (Expression p, int a, int b) => equipments.OrderBy(x => x.SerialNumber).Skip(1).Take(2).ToList());
            mockEquipmentRepository
                .Setup(eq => eq.OrderBy(x => x.Name, 1, 2))
                .Returns(
                    (Expression p, int a, int b) => equipments.OrderBy(x => x.Name).Skip(1).Take(2).ToList());
            mockEquipmentRepository
                .Setup(eq => eq.OrderBy(x => x.NextControlDate, 1, 2))
                .Returns(
                    (Expression p, int a, int b) =>
                        equipments.OrderBy(x => x.NextControlDate).Skip(1).Take(2).ToList());

            mockEquipmentRepository
                .Setup(eq => eq.OrderByDescending(x => x.SerialNumber, 1, 2))
                .Returns(
                    (Expression p, int a, int b) =>
                        equipments.OrderByDescending(x => x.SerialNumber).Skip(1).Take(2).ToList());
            mockEquipmentRepository
                .Setup(eq => eq.OrderByDescending(x => x.Name, 1, 2))
                .Returns(
                    (Expression p, int a, int b) => equipments.OrderByDescending(x => x.Name).Skip(1).Take(2).ToList());
            mockEquipmentRepository
                .Setup(eq => eq.OrderByDescending(x => x.NextControlDate, 1, 2))
                .Returns(
                    (Expression p, int a, int b) =>
                        equipments.OrderByDescending(x => x.NextControlDate).Skip(1).Take(2).ToList());

            _mockEquipmentRepository = mockEquipmentRepository.Object;
        }

        [TestMethod]
        public void TestAdd()
        {
            var equipment = new Equipment
            {
                SerialNumber = 1,
                Name = "equipment1",
                NextControlDate = new DateTime()
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
                NextControlDate = new DateTime()
            };
            _repo.Remove(equipment);
            _mockSet.Verify(m => m.Remove(It.IsAny<Equipment>()), Times.Once());
        }

        [TestMethod]
        public void TestOrderBy_int()
        {
            var ordredList = _mockEquipmentRepository.OrderBy(x => x.SerialNumber, 1, 2);
            Assert.IsNotNull(ordredList); // Test if null
            Assert.IsInstanceOfType(ordredList, typeof(IEnumerable<Equipment>)); // Test type
            Assert.AreEqual(2, ordredList.First().SerialNumber); // Verify it is the right 
            Assert.AreEqual(3, ordredList.Last().SerialNumber); // Verify it is the right 
        }

        [TestMethod]
        public void TestOrderBy_string()
        {
            var ordredList = _mockEquipmentRepository.OrderBy(x => x.Name, 1, 2);
            Assert.IsNotNull(ordredList); // Test if null
            Assert.IsInstanceOfType(ordredList, typeof(IEnumerable<Equipment>)); // Test type
            Assert.AreEqual("equipment2", ordredList.First().Name); // Verify it is the right 
            Assert.AreEqual("equipment3", ordredList.Last().Name); // Verify it is the right 
        }

        [TestMethod]
        public void TestOrderBy_date()
        {
            var ordredList = _mockEquipmentRepository.OrderBy(x => x.NextControlDate, 1, 2);
            Assert.IsNotNull(ordredList); // Test if null
            Assert.IsInstanceOfType(ordredList, typeof(IEnumerable<Equipment>)); // Test type
            Assert.AreEqual(new DateTime(2020, 6, 6), ordredList.First().NextControlDate); // Verify it is the right 
            Assert.AreEqual(new DateTime(2020, 6, 7), ordredList.Last().NextControlDate); // Verify it is the right 
        }

        [TestMethod]
        public void TestOrderByDescending_int()
        {
            var ordredList = _mockEquipmentRepository.OrderByDescending(x => x.SerialNumber, 1, 2);
            Assert.IsNotNull(ordredList); // Test if null
            Assert.IsInstanceOfType(ordredList, typeof(IEnumerable<Equipment>)); // Test type
            Assert.AreEqual(2, ordredList.First().SerialNumber); // Verify it is the right 
            Assert.AreEqual(1, ordredList.Last().SerialNumber); // Verify it is the right 
        }

        [TestMethod]
        public void TestOrderByDescending_string()
        {
            var ordredList = _mockEquipmentRepository.OrderByDescending(x => x.Name, 1, 2);
            Assert.IsNotNull(ordredList); // Test if null
            Assert.IsInstanceOfType(ordredList, typeof(IEnumerable<Equipment>)); // Test type
            Assert.AreEqual("equipment2", ordredList.First().Name); // Verify it is the right 
            Assert.AreEqual("equipment1", ordredList.Last().Name); // Verify it is the right 
        }

        [TestMethod]
        public void TestOrderByDescending_date()
        {
            var ordredList = _mockEquipmentRepository.OrderByDescending(x => x.NextControlDate, 1, 2);
            Assert.IsNotNull(ordredList); // Test if null
            Assert.IsInstanceOfType(ordredList, typeof(IEnumerable<Equipment>)); // Test type
            Assert.AreEqual(new DateTime(2020, 6, 6), ordredList.First().NextControlDate); // Verify it is the right 
            Assert.AreEqual(new DateTime(2020, 6, 5), ordredList.Last().NextControlDate); // Verify it is the
        }
    }
}