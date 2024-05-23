using IP_Business.Components;
using IP_Contract_Business_DataLayer.interfaces;
using IP_Models.DTOs;
using IP_Models.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[TestFixture]
public class ItemComponentTests
{
    private Mock<IItemRepo> _mockItemRepo;
    private Mock<IBrandRepo> _mockBrandRepo;
    private Mock<ICategory_ItemRepo> _mockCategoryItemRepo;
    private Mock<ICategoryRepo> _mockCategoryRepo;
    private Mock<CategoryComponent> _mockCategoryComponent;
    private ItemComponent _itemComponent;

    [SetUp]
    public void SetUp()
    {
        _mockItemRepo = new Mock<IItemRepo>();
        _mockBrandRepo = new Mock<IBrandRepo>();
        _mockCategoryItemRepo = new Mock<ICategory_ItemRepo>();
        _mockCategoryRepo = new Mock<ICategoryRepo>();
        _mockCategoryComponent = new Mock<CategoryComponent>(_mockCategoryRepo.Object);
        _itemComponent = new ItemComponent(_mockItemRepo.Object, _mockBrandRepo.Object, _mockCategoryItemRepo.Object, _mockCategoryRepo.Object);
    }

    [Test]
    public async Task CreateItem_WhenRepoCreateItemReturnsTrue_ReturnsItems()
    {
        // Arrange
        var newItem = new Item
        {
            ItemID = 1,
            ItemName = "Test Item",
            ItemDescription = "Test Description",
            ItemPrice = 100,
            ItemQuantity = 10,
            ItemQuantitySold = 0,
            BrandID = 1
        };

        var items = new List<Item>
        {
            new Item { ItemID = 1, ItemName = "Test Item", ItemDescription = "Test Description", ItemPrice = 100, ItemQuantity = 10, ItemQuantitySold = 0, BrandID = 1 }
        };

        _mockItemRepo.Setup(repo => repo.CreateItem(It.IsAny<ItemDTO>())).ReturnsAsync(true);
        _mockItemRepo.Setup(repo => repo.GetItems()).ReturnsAsync(items.Select(i => new ItemDTO
        {
            ItemID = i.ItemID,
            ItemName = i.ItemName,
            ItemDescription = i.ItemDescription,
            ItemPrice = i.ItemPrice,
            ItemQuantity = i.ItemQuantity,
            ItemQuantitySold = i.ItemQuantitySold,
            BrandID = i.BrandID
        }));

        // Act
        var result = await _itemComponent.CreateItem(newItem);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(items.Count, result.Count());
        _mockItemRepo.Verify(repo => repo.CreateItem(It.IsAny<ItemDTO>()), Times.Once);
        _mockItemRepo.Verify(repo => repo.GetItems(), Times.Once);
    }

    [Test]
    public async Task CreateItem_WhenRepoCreateItemReturnsFalse_ReturnsNull()
    {
        // Arrange
        var newItem = new Item
        {
            ItemID = 1,
            ItemName = "Test Item",
            ItemDescription = "Test Description",
            ItemPrice = 100,
            ItemQuantity = 10,
            ItemQuantitySold = 0,
            BrandID = 1
        };

        _mockItemRepo.Setup(repo => repo.CreateItem(It.IsAny<ItemDTO>())).ReturnsAsync(false);

        // Act
        var result = await _itemComponent.CreateItem(newItem);

        // Assert
        Assert.IsNull(result);
        _mockItemRepo.Verify(repo => repo.CreateItem(It.IsAny<ItemDTO>()), Times.Once);
        _mockItemRepo.Verify(repo => repo.GetItems(), Times.Never);
    }

    [Test]
    public async Task GetItems_ReturnsListOfItems()
    {
        // Arrange
        var items = new List<Item>
        {
            new Item { ItemID = 1, ItemName = "Test Item", ItemDescription = "Test Description", ItemPrice = 100, ItemQuantity = 10, ItemQuantitySold = 0, BrandID = 1 }
        };

        _mockItemRepo.Setup(repo => repo.GetItems()).ReturnsAsync(items.Select(i => new ItemDTO
        {
            ItemID = i.ItemID,
            ItemName = i.ItemName,
            ItemDescription = i.ItemDescription,
            ItemPrice = i.ItemPrice,
            ItemQuantity = i.ItemQuantity,
            ItemQuantitySold = i.ItemQuantitySold,
            BrandID = i.BrandID
        }));

        // Act
        var result = await _itemComponent.GetItems();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(items.Count, result.Count());
        _mockItemRepo.Verify(repo => repo.GetItems(), Times.Once);
    }

    [Test]
    public async Task GetItemById_ItemExists_ReturnsItem()
    {
        // Arrange
        var itemDTO = new ItemDTO
        {
            ItemID = 1,
            ItemName = "Test Item",
            ItemDescription = "Test Description",
            ItemPrice = 100,
            ItemQuantity = 10,
            ItemQuantitySold = 0,
            BrandID = 1
        };

        _mockItemRepo.Setup(repo => repo.GetItemById(It.IsAny<int>())).ReturnsAsync(itemDTO);

        // Act
        var result = await _itemComponent.GetItemById(1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(itemDTO.ItemID, result.ItemID);
        _mockItemRepo.Verify(repo => repo.GetItemById(It.IsAny<int>()), Times.Once);
    }

    [Test]
    public async Task GetItemById_ItemDoesNotExist_ReturnsNull()
    {
        // Arrange
        _mockItemRepo.Setup(repo => repo.GetItemById(It.IsAny<int>())).ReturnsAsync((ItemDTO)null);

        // Act
        var result = await _itemComponent.GetItemById(1);

        // Assert
        Assert.IsNull(result);
        _mockItemRepo.Verify(repo => repo.GetItemById(It.IsAny<int>()), Times.Once);
    }
}
