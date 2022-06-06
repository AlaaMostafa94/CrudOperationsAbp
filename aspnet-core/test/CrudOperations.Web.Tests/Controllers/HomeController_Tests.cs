using System.Threading.Tasks;
using CrudOperations.Models.TokenAuth;
using CrudOperations.Web.Controllers;
using Shouldly;
using Xunit;

namespace CrudOperations.Web.Tests.Controllers
{
    public class HomeController_Tests: CrudOperationsWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}