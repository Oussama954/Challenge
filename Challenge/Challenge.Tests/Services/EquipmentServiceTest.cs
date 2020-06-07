using Challenge.Business;
using Challenge.Business.Interfaces;
using Challenge.Dal.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
            mockUnitOfWork.Setup(u => u.Equipments).Returns(_mockEquipmentRepository.Object);
            mockUnitOfWork.Setup(u => u.Pictures).Returns(_mockPictureRepository.Object);

            _equipmentService = new EquipmentService(mockUnitOfWork.Object);
        }

        [TestMethod]
        public void TestCount()
        {
            _equipmentService.Count();
            _mockEquipmentRepository.Verify(m => m.Count(), Times.Once());
        }
    }
}