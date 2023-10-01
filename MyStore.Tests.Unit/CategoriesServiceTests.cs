using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MyStore.Data;
using MyStore.Domain;
using MyStore.Services;
using NSubstitute;

namespace MyStore.Tests.Unit
{
    public class CategoriesServiceTests
    {
        public readonly ICategoryService subjectUnderTest;
        public readonly ICategoryRepository mockRepository;
        public CategoriesServiceTests() 
        {
            mockRepository = Substitute.For<ICategoryRepository>();
            subjectUnderTest = new CategoryService(mockRepository);
        }

        [Fact]
        public void GetCategoryShouldReturn_Category_WhenExists()
        {
            //Arrange
            var existingCategory = new Category()
            {
                Categoryid = 1,
                Categoryname = "Test category",
                Description = "Test description"

            };

            mockRepository.GetCategoryById(existingCategory.Categoryid)
                .Returns(existingCategory);
            //Act
            var actualResult = subjectUnderTest.GetCategory(existingCategory.Categoryid);

            //Assert
            actualResult.Should().BeEquivalentTo(existingCategory);
        }
        [Fact]
        public void IsDuplicate_ShouldReturnTrue_WhenCategoryName_Exists()
        {
            //Arrange
            
            var categoryList = new List<Category>()
            {
                new Category()
                {
                    Categoryid= 1,
                    Categoryname= "test category",
                    Description = "Test description"
                },
                new Category()
                {
                    Categoryid= 3,
                    Categoryname= "fructe",
                    Description = "Test description"
                }
            };

            mockRepository.GetAll().Returns(categoryList.AsQueryable());
            var categoryToSearch = "fructe";
            //Act
            var actualResult = subjectUnderTest.IsDuplicate(categoryToSearch);

            //Assert
            actualResult.Should().BeTrue();

        }
        [Fact]
        public void IsDuplicate_ShouldReturnFalse_WhenCategoryName_DoesntExist()
        {
            //Arrange

            var categoryList = new List<Category>()
            {
                new Category()
                {
                    Categoryid= 1,
                    Categoryname= "test category",
                    Description = "Test description"
                },
                new Category()
                {
                    Categoryid= 3,
                    Categoryname= "test category",
                    Description = "Test description"
                }
            };

            mockRepository.GetAll().Returns(categoryList.AsQueryable());
            var categoryToSearch = "fructe";
            //Act
            var actualResult = subjectUnderTest.IsDuplicate(categoryToSearch);

            //Assert
            actualResult.Should().BeFalse();

        }

        [Fact]
        public void GetCategoriesShould_Return2CategoriesPerPage()
        {
            //Arrange
            var categoryList = new List<Category>()
            {
                new Category()
                {
                    Categoryid= 1,
                    Categoryname= "test category",
                    Description = "Test description"
                },
                new Category()
                {
                    Categoryid= 3,
                    Categoryname= "test category",
                    Description = "Test description"
                }
               
            };
            mockRepository.GetAll(1).Returns(categoryList.AsEnumerable());
           

            //Act
            var actualResult = subjectUnderTest.GetCategories(1).ToList();

            //Assert
            actualResult.Should().NotBeEmpty();
            actualResult.Count.Should().Be(2);
            
        }

        [Fact]
        public void Update_ExistingCategory_ShouldUpdateExistingCategory()
        {
            //Arrange
            /*var existingCategory = new Category()
            {
                Categoryid = 1,
                Categoryname = "test category",
                Description = "Test description"
            };*/

            var newCategory = new Category()
            {
                Categoryid = 1,
                Categoryname = "test new category",
                Description = "Test description"
            };
            mockRepository.Update(newCategory).Returns(newCategory);
            
            //Act
            var actualResult = subjectUnderTest.Update(newCategory);

            //Assert
            //actualResult.Should().BeSameAs(newCategory);
            actualResult.Categoryname.Should().Be(newCategory.Categoryname);

        }

        [Fact]
        public void DeleteCategory_ShouldDeleteCategory()
        {
            //Arrange
            var newCategory = new Category()
            {
                Categoryid = 1,
                Categoryname = "test new category",
                Description = "Test description"
            };
            mockRepository.Delete(newCategory).Returns(newCategory.Categoryid);
            //Act
            var actualResult = subjectUnderTest.Remove(newCategory);
            //Assert
            actualResult.Should().Be(1);

        }
    }
}
