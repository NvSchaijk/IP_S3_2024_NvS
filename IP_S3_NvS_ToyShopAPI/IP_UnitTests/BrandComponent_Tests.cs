using Moq;
using IP_Contract_Business_DataLayer.interfaces;
using IP_Models.Models;
using IP_Models.DTOs;
using IP_Business;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IP_Tests
{
    [TestFixture]
    public class BrandComponent_Tests
    {
        private Mock<IBrandRepo> _mockRepo;
        private BrandComponent _brandComponent;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IBrandRepo>();
            _brandComponent = new BrandComponent(_mockRepo.Object);
        }

        [Test]
        public async Task CreateBrand_SuccessfulCreation_ReturnsUpdatedBrandsList()
        {
            // Arrange
            var brand = new Brand { BrandName = "Test Brand", BrandDescription = "Test Description" };
            _mockRepo.Setup(repo => repo.CreateBrand(It.IsAny<BrandDTO>())).ReturnsAsync(true);
            _mockRepo.Setup(repo => repo.GetBrands()).ReturnsAsync(new List<BrandDTO> {
                new BrandDTO { BrandID = 1, BrandName = "Test Brand", BrandDescription = "Test Description" }
            });

            // Act
            var result = await _brandComponent.CreateBrand(brand);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Test Brand", result.First().BrandName);
        }

        [Test]
        public async Task DeleteBrand_SuccessfulDeletion_ReturnsUpdatedBrandsList()
        {
            // Arrange
            int brandId = 1;
            _mockRepo.Setup(repo => repo.DeleteBrand(brandId)).ReturnsAsync(true);
            _mockRepo.Setup(repo => repo.GetBrands()).ReturnsAsync(new List<BrandDTO>());

            // Act
            var result = await _brandComponent.DeleteBrand(brandId);

            // Assert
            Assert.NotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetBrandById_BrandExists_ReturnsBrand()
        {
            // Arrange
            int brandId = 1;
            _mockRepo.Setup(repo => repo.GetBrandById(brandId)).ReturnsAsync(new BrandDTO
            {
                BrandID = brandId,
                BrandName = "Test Brand",
                BrandDescription = "Test Description"
            });

            // Act
            var result = await _brandComponent.GetBrandById(brandId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(brandId, result.BrandID);
            Assert.AreEqual("Test Brand", result.BrandName);
        }
    }
}


