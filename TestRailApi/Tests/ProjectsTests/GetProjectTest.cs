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
    [AllureSuite("GetProjectsTests")]
    public class GetProjectTest : BaseTest
    {
        private ProjectService _projectService;
        
        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            _projectService = new ProjectService(UserGenerator.GetUser("Admin"));
            
            var response = _projectService.AddProject(ProjectGenerator.GetProject("Valid Test Project")).Result;
            ProjectId = response.Data.Id.ToString();
        }
        
        [Test(Description = "Get valid project and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void GetProject_ExistentProject_ShouldReturnOk()
        {
            var response = _projectService.GetProject(ProjectId).Result; 
            
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK); 
                response.Data.ShouldBeValid(ProjectGenerator.GetProject("Valid Test Project"));
                response.Data.Id.Should().Be(int.Parse(ProjectId));
            }
        }

        [Test(Description = "Get project fake id and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void GetProject_ProjectWithFakeId_ShouldReturnBadRequest()
        {
            var response = _projectService
                .GetProject(FakeProjectId.ToString()).Result;

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test(Description = "Get project when user no access and returns HttpStatus Forbidden")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void GetProject_UserNoAccess_ShouldReturnForbidden()
        {
            var projectService = new ProjectService(UserGenerator.GetUser("UserNoAccess"));
            
            var response = projectService.GetProject(ProjectId).Result;

            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
        
        [Test(Description = "Get project when user is unauthorized and returns HttpStatus Unauthorized")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void GetProject_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var projectService = new ProjectService(UserGenerator.GetUser("FakeUser"));
            
            var response = projectService.GetProject(ProjectId).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}