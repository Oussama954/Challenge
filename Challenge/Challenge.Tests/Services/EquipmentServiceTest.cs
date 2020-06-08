using Challenge.Business;
using Challenge.Business.Interfaces;
using Challenge.Dal.Interfaces;
using Challenge.Model;
using Challenge.VO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Challenge.Tests.Services
{
    [TestClass]
    public class EquipmentServiceTest
    {
        private EquipmentService _equipmentService;
        private Mock<IEquipmentRepository> _mockEquipmentRepository;
        private Mock<IPictureRepository> _mockPictureRepository;

        [TestInitialize]
        public void InitTest()
        {
            _mockEquipmentRepository = new Mock<IEquipmentRepository>();
            _mockPictureRepository = new Mock<IPictureRepository>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockEquipmentRepository.Setup(m => m.Get(It.IsAny<int>())).Returns(new Model.Equipment
            {
                Name = "name1",
                NextControlDate = new System.DateTime(2020, 06, 06),
                SerialNumber = 1,
                Picture = new Model.Picture()
                {
                    Content = new byte[0],
                    SerialNumber = 1
                }
            });
            _mockEquipmentRepository.Setup(m => m.FindByName(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Equipment>
                {
                    new Equipment()
                    {
                        Name = "name1",
                        NextControlDate = new System.DateTime(2020, 06, 06),
                        SerialNumber = 1,
                        Picture = new Model.Picture()
                        {
                            Content = new byte[0],
                            SerialNumber = 1
                        }
                    }
                });
            _mockEquipmentRepository.Setup(m => m.OrderBy(x => x.SerialNumber, It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Equipment>
                {
                    new Equipment()
                    {
                        Name = "name1",
                        NextControlDate = new System.DateTime(2020, 06, 06),
                        SerialNumber = 1,
                        Picture = new Model.Picture()
                        {
                            Content = new byte[0],
                            SerialNumber = 1
                        }
                    }
                });
            _mockEquipmentRepository.Setup(m => m.OrderBy(x => x.Name, It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Equipment>
                {
                    new Equipment()
                    {
                        Name = "name1",
                        NextControlDate = new System.DateTime(2020, 06, 06),
                        SerialNumber = 1,
                        Picture = new Model.Picture()
                        {
                            Content = new byte[0],
                            SerialNumber = 1
                        }
                    }
                });
            _mockEquipmentRepository.Setup(m => m.OrderBy(x => x.NextControlDate, It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Equipment>
                {
                    new Equipment()
                    {
                        Name = "name1",
                        NextControlDate = new System.DateTime(2020, 06, 06),
                        SerialNumber = 1,
                        Picture = new Model.Picture()
                        {
                            Content = new byte[0],
                            SerialNumber = 1
                        }
                    }
                });
            //
            _mockEquipmentRepository.Setup(m => m.OrderByDescending(x => x.SerialNumber, It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Equipment>
                {
                    new Equipment()
                    {
                        Name = "name1",
                        NextControlDate = new System.DateTime(2020, 06, 06),
                        SerialNumber = 1,
                        Picture = new Model.Picture()
                        {
                            Content = new byte[0],
                            SerialNumber = 1
                        }
                    }
                });
            _mockEquipmentRepository.Setup(m => m.OrderByDescending(x => x.Name, It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Equipment>
                {
                    new Equipment()
                    {
                        Name = "name1",
                        NextControlDate = new System.DateTime(2020, 06, 06),
                        SerialNumber = 1,
                        Picture = new Model.Picture()
                        {
                            Content = new byte[0],
                            SerialNumber = 1
                        }
                    }
                });
            _mockEquipmentRepository.Setup(m => m.OrderByDescending(x => x.NextControlDate, It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Equipment>
                {
                    new Equipment()
                    {
                        Name = "name1",
                        NextControlDate = new System.DateTime(2020, 06, 06),
                        SerialNumber = 1,
                        Picture = new Model.Picture()
                        {
                            Content = new byte[0],
                            SerialNumber = 1
                        }
                    }
                });
            mockUnitOfWork.Setup(u => u.Equipments).Returns(_mockEquipmentRepository.Object);
            mockUnitOfWork.Setup(u => u.Pictures).Returns(_mockPictureRepository.Object);

            _equipmentService = new EquipmentService(mockUnitOfWork.Object);
        }
        [TestMethod]
        public void TestDelete()
        {
            var equipmentVO = new EquipmentVO()
            {
                Name = "name1",
                NextControlDate = new System.DateTime(2020, 06, 06),
                Picture = new byte[0],
                SerialNumber = 1
            };
            _equipmentService.Delete(equipmentVO);
            _mockEquipmentRepository.Verify(m => m.Remove(It.IsAny<Equipment>()), Times.Once());
        }
        [TestMethod]
        public void TestUpdate()
        {
            var equipmentVO = new EquipmentVO()
            {
                Name = "name1",
                NextControlDate = new System.DateTime(2020, 06, 06),
                Picture = new byte[0],
                SerialNumber = 1
            };
            _equipmentService.Update(equipmentVO);
            _mockEquipmentRepository.Verify(m => m.Update(It.IsAny<Equipment>()), Times.Once());
        }
        [TestMethod]
        public void TestAdd()
        {
            var equipmentVO = new EquipmentVO()
            {
                Name = "name1",
                NextControlDate = new System.DateTime(2020, 06, 06),
                Picture = new byte[0],
                SerialNumber = 1
            };
            _equipmentService.Add(equipmentVO);
            _mockEquipmentRepository.Verify(m => m.Add(It.IsAny<Equipment>()), Times.Once());
        }
        [TestMethod]
        public void TestCount()
        {
            _equipmentService.Count();
            _mockEquipmentRepository.Verify(m => m.Count(), Times.Once());
        }
        [TestMethod]
        public void TestCountByName()
        {
            _equipmentService.CountByName(It.IsAny<string>());
            _mockEquipmentRepository.Verify(m => m.CountByName(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public void TestFind()
        {
            _equipmentService.Find(It.IsAny<int>());
            _mockEquipmentRepository.Verify(m => m.Get(It.IsAny<int>()), Times.Once());
        }
        [TestMethod]
        public void TestFindName()
        {
            _equipmentService.FindName(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>());
            _mockEquipmentRepository.Verify(m => m.FindByName(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
        [TestMethod]
        public void TestOrderBySerialNumber()
        {
            _equipmentService.OrderBySerialNumber(It.IsAny<int>(), It.IsAny<int>());
            _mockEquipmentRepository.Verify(m => m.OrderBy(x => x.SerialNumber, It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
        [TestMethod]
        public void TestOrderByName()
        {
            _equipmentService.OrderByName(It.IsAny<int>(), It.IsAny<int>());
            _mockEquipmentRepository.Verify(m => m.OrderBy(x => x.Name, It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
        [TestMethod]
        public void TestOrderByDate()
        {
            _equipmentService.OrderByDate(It.IsAny<int>(), It.IsAny<int>());
            _mockEquipmentRepository.Verify(m => m.OrderBy(x => x.NextControlDate, It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
        [TestMethod]
        public void TestOrderByDescendingSerialNumber()
        {
            _equipmentService.OrderByDescendingSerialNumber(It.IsAny<int>(), It.IsAny<int>());
            _mockEquipmentRepository.Verify(m => m.OrderByDescending(x => x.SerialNumber, It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
        [TestMethod]
        public void TestOrderByDescendingName()
        {
            _equipmentService.OrderByDescendingName(It.IsAny<int>(), It.IsAny<int>());
            _mockEquipmentRepository.Verify(m => m.OrderByDescending(x => x.Name, It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
        [TestMethod]
        public void TestOrderByDescendingDate()
        {
            _equipmentService.OrderByDescendingDate(It.IsAny<int>(), It.IsAny<int>());
            _mockEquipmentRepository.Verify(m => m.OrderByDescending(x => x.NextControlDate, It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
    }
}