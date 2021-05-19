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

namespace TestRailApi.Tests.ProjectsTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("AddProjectTests")]
    public class AddProjectTest : BaseTest
    {
        private ProjectService _projectService;
        [SetUp]
        public void SetUp()
        {
            _projectService = new ProjectService(UserGenerator.GetUser("Admin"));
        }

        [Test(Description = "Add valid project and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_ExistentProject_ShouldReturnOk()
        {
            var expectedProject = ProjectGenerator.GetProject("Valid Test Project");
            
            var response = _projectService.AddProject(expectedProject).Result;
           
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);  
                response.Data.ShouldBeValid(expectedProject);
            }
        }

        [Test(Description = "Add project without name and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_ProjectWithoutName_ShouldReturnBadRequest()
        {
            var expectedProject = ProjectGenerator.GetProjectWithoutName("Valid Test Project");
            
            var response = _projectService.AddProject(expectedProject).Result;

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test(Description = "Add project without announcement and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_ProjectWithoutAnnouncement_ShouldReturnOk()
        {
            var expectedProject = ProjectGenerator.GetProjectWithoutAnnouncement("Valid Test Project");
           
            var response = _projectService.AddProject(expectedProject).Result;

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Test(Description = "Add project without suite mode and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_ProjectWithoutSuiteMode_ShouldReturnBadRequest()
        {
            var expectedProject = ProjectGenerator.GetProjectWithoutSuiteMode("Valid Test Project");
           
            var response = _projectService.AddProject(expectedProject).Result;
            
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                response.Data.SuiteMode.Should().Be(1);
            }
        }

        [Test(Description = "Add project with invalid suite mode and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_ProjectWithInvalidSuiteMode_ShouldReturnBadRequest()
        {
            var expectedProject = ProjectGenerator.GetProjectWithoutAnnouncement("Invalid Test Project");
            
            var response = _projectService.AddProject(expectedProject).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Test(Description = "Add project when user no access and returns HttpStatus Forbidden")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_UserNoAccess_ShouldReturnForbidden()
        {
            var projectService = new ProjectService(UserGenerator.GetUser("UserNoAccess"));
                
            var response = projectService.AddProject(ProjectGenerator.GetProject("Valid Test Project")).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
        
        [Test(Description = "Add project when user unauthorized and returns HttpStatus Unauthorized")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void AddProject_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var projectService = new ProjectService(UserGenerator.GetUser("FakeUser"));
            
            var response = projectService.AddProject(ProjectGenerator.GetProject("Valid Test Project")).Result;
                    
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}