using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using TestRailApi.BaseEntities;
using TestRailApi.Generators;
using TestRailApi.Services;

namespace TestRailApi.Tests.SuiteTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("AddSuiteTests")]
    public class AddSuiteTest : BaseTest
    {
        private SuiteService _suiteService;

        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            _suiteService = new SuiteService(UserGenerator.GetUser("Admin"));

            var projectService = new ProjectService(UserGenerator.GetUser("Admin"));
            var response = projectService.AddProject(ProjectGenerator.GetProject("Valid Test Project")).Result;

            ProjectId = response.Data.Id.ToString();
        }
        
        [Test(Description = "Add valid suite and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_ValidSuite_ShouldReturnOk()
        {
            var expectedSuite = SuiteGenerator.GetSuite("Suite");
            
            var response = _suiteService.AddSuite(ProjectId, expectedSuite).Result;

            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Data.Id.Should().NotBe(null);
                response.Data.ProjectId.Should().Be(int.Parse(ProjectId));
            }
        }
        
        [Test(Description = "Add suite in non existent project and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_NonExistentProject_ShouldReturnBadRequest()
        {
            var expectedSuite = SuiteGenerator.GetSuite("Suite");
            
            var response = _suiteService.AddSuite(FakeProjectId.ToString(), expectedSuite).Result;

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Test(Description = "Add suite when user no access and returns HttpStatus Forbidden")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_UserNoAccess_ShouldReturnForbidden()
        {
            var expectedSuite = SuiteGenerator.GetSuite("Suite");
            
            var suiteService = new SuiteService(UserGenerator.GetUser("UserNoAccess"));
            var response = suiteService.AddSuite(ProjectId, expectedSuite).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
        
        [Test(Description = "Add suite when user is unauthorized and returns HttpStatus Unauthorized")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var expectedSuite = SuiteGenerator.GetSuite("Suite"); 
            
            var suiteService = new SuiteService(UserGenerator.GetUser("FakeUser"));
            var response = suiteService.AddSuite(ProjectId, expectedSuite).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Test(Description = "Add suite when project id is invalid and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_InvalidProjectId_ShouldReturnBadRequest()
        {
            var expectedSuite = SuiteGenerator.GetSuite("Suite"); 

            var response = _suiteService.AddSuite(InvalidId, expectedSuite).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Test(Description = "Add suite without name (invalid data) and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_SuiteWithoutName_ShouldReturnBadRequest()
        {
            var expectedSuite = SuiteGenerator.GetSuiteWithoutName("Suite");
            
            var response = _suiteService.AddSuite(ProjectId, expectedSuite).Result;

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Test(Description = "Add suite without description (invalid data) and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddSuite_SuiteWithoutDescription_ShouldReturnOk()
        {
            var expectedSuite = SuiteGenerator.GetSuiteWithoutDescription("Suite");
            
            var response = _suiteService.AddSuite(ProjectId, expectedSuite).Result;

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}