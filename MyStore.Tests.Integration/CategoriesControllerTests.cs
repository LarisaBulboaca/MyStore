using FluentAssertions;
using System.Net;

namespace MyStore.Tests.Integration
{
    public class CategoriesControllerTests : IClassFixture<StoreApiFactory<Program>>
    {
        private readonly HttpClient httpClient;
        public CategoriesControllerTests(StoreApiFactory<Program> apiFactory)
        {
            apiFactory.ClientOptions.BaseAddress = new Uri("https://localhost:7110/api/");
            httpClient = apiFactory.CreateClient();
        }
        [Fact]
        public async void Get_ReturnsNotFound_WhenCategoryDoesntExist()
        {
            //Arrange
            //Act
            //https://localhost:7110/api/ + /categories/3
            var response = await httpClient.GetAsync($"categories/3");
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}