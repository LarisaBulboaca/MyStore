using FluentAssertions;
using MyStore.Data;
using MyStore.Domain;
using MyStore.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests.Unit
{
    public class SupplierServiceTests
    {
        public readonly ISupplierService subjectUnderTest;
        public readonly ISupplierRepository mockRepository;
        public SupplierServiceTests()
        {
            mockRepository = Substitute.For<ISupplierRepository>();
            subjectUnderTest = new SupplierService(mockRepository);
        }

        [Fact]
        public void GetSupplierShouldReturn_Supplier_WhenExists()
        {
            //Arrange
            var existingSupplier = new Supplier()
            {
                Supplierid = 1,
                Companyname = "Test",
                Contactname = "Test",
                Contacttitle = "Test",
                Address = "Test",
                City = "Test",
                Region = "Test",
                Postalcode = "Test",
                Country = "Test",
                Phone = "Test",
                Fax = "Test",
                email = "Test",

            };

            mockRepository.GetSupplierByID(existingSupplier.Supplierid)
                .Returns(existingSupplier);
            //Act
            var actualResult = subjectUnderTest.GetSupplier(existingSupplier.Supplierid);

            //Assert
            actualResult.Should().Be(existingSupplier);
        }

        [Fact]
        public void GetSuppliers_ReturnSuppliers()
        {
            //Arrange
            var supplierList = new List<Supplier>()
            {
                new Supplier()
                {
                    Supplierid=1,
                    Companyname = "Test",
                    Contactname = "Test",
                    Contacttitle = "Test",
                    Address = "Test", City = "Test",
                    Region = "Test",
                    Postalcode = "Test",
                    Country = "Test",
                    Phone = "Test",
                    Fax = "Test",
                    email = "Test",
                },
                new Supplier()
                {
                    Supplierid = 2,
                    Companyname = "Test",
                    Contactname = "Test",
                    Contacttitle = "Test",
                    Address = "Test", City = "Test",
                    Region = "Test",
                    Postalcode = "Test",
                    Country = "Test",
                    Phone = "Test",
                    Fax = "Test",
                    email = "Test",

                }

            };
            mockRepository.GetAll().Returns(supplierList.AsEnumerable());

            //Act
            var actualResult = subjectUnderTest.GetSuppliers().ToList();

            //Assert
            actualResult.Should().BeEquivalentTo(supplierList);

        }
    }
}
