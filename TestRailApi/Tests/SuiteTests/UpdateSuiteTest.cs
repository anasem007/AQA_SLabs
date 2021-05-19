using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using TestRailApi.Asserts;
using TestRailApi.BaseEntities;
using TestRailApi.Generators;
using TestRailApi.Services;

namespace TestRailApi.Tests.SuiteTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("UpdateSuiteTests")]
    public class UpdateSuiteTest : BaseTest
    {
        private SuiteService _suiteService;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            _suiteService = new SuiteService(UserGenerator.GetUser("Admin"));

            var projectService = new ProjectService(UserGenerator.GetUser("Admin"));
            
            var projectResponse = projectService.AddProject(ProjectGenerator.GetProject("Valid Test Project")).Result;
            ProjectId = projectResponse.Data.Id.ToString(); 
            
            var response = _suiteService.AddSuite(ProjectId, SuiteGenerator.GetSuite("Suite")).Result;
            SuiteId = response.Data.Id.ToString();
        }
        
        [Test(Description = "Add valid suite and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void UpdateSuite_ValidSuite_ShouldReturnOk()
        {
            var expectedSuite = SuiteGenerator.GetSuite("Update Suite");
            
            var response = _suiteService.UpdateSuite(SuiteId, expectedSuite).Result;
            
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);  
                response.Data.ShouldBeValid(expectedSuite);
                response.Data.ProjectId.Should().Be(int.Parse(ProjectId));
                response.Data.Id.Should().Be(int.Parse(SuiteId));
            }
        }
        
        [Test(Description = "Try update suite with invalid id and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void UpdateSuite_InvalidSuiteId_ShouldReturnBadRequest()
        {
            var expectedSuite = SuiteGenerator.GetSuite("Update Suite");

            var response = _suiteService.UpdateSuite(InvalidId, expectedSuite).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Test(Description = "Try update suite when user doesn't have access and returns HttpStatus Forbidden")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void UpdateSuite_UserNoAccess_ShouldReturnForbidden()
        {            
            var expectedSuite = SuiteGenerator.GetSuite("Update Suite");

            var suiteService = new SuiteService(UserGenerator.GetUser("UserNoAccess"));
            var response = suiteService.UpdateSuite(SuiteId, expectedSuite).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
        
        [Test(Description = "Try update suite when user is unauthorized and returns HttpStatus Unauthorized")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void UpdateSuite_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var expectedSuite = SuiteGenerator.GetSuite("Update Suite");
            
            var suiteService = new SuiteService(UserGenerator.GetUser("FakeUser"));
            var response = suiteService.UpdateSuite(SuiteId, expectedSuite).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Test(Description = "Update suite excluding name and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void UpdateSuite_RequestWithoutName_ShouldReturnOk()
        {
            var expectedSuite = SuiteGenerator.GetSuiteWithoutName("Update Suite");
           
            var response = _suiteService.UpdateSuite(SuiteId, expectedSuite).Result;
            
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
                response.Data.Name.Should().Be(expectedSuite.Name);
                response.Data.Description.Should().Be(expectedSuite.Description);
            }
        }
        
        [Test(Description = "Update suite excluding description and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void UpdateSuite_RequestWithoutDescription_ShouldReturnOk()
        {
            var expectedSuite = SuiteGenerator.GetSuiteWithoutDescription("Update Suite"); 
            
            var response = _suiteService.UpdateSuite(SuiteId, expectedSuite).Result;
            
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Data.Description.Should().Be(expectedSuite.Description);
                response.Data.Name.Should().Be(expectedSuite.Name);
            }
        }
    }
}