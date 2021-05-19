using System.Net;
using FluentAssertions;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using TestRailApi.BaseEntities;
using TestRailApi.Generators;
using TestRailApi.Services;

namespace TestRailApi.Tests.ProjectsTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("DeleteProjectTests")]
    public class DeleteProjectTest : BaseTest
    {
        private ProjectService _projectService;
        
        [SetUp]
        public void SetUp()
        {
            _projectService = new ProjectService(UserGenerator.GetUser("Admin"));
            
            var response = _projectService.AddProject(ProjectGenerator.GetProject("Valid Test Project")).Result;
            ProjectId = response.Data.Id.ToString();
        }

        [Test(Description = "Delete existent project and returns HttpStatus OK")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        //[AllureSubSuite("Delete Project")]
        public void DeleteProject_ExistentProject_ShouldReturnOk()
        {
            var response = _projectService.DeleteProject(ProjectId).Result;
            
            Assert.Multiple(() =>
            { 
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                response.Data.Should().BeNull();
            });
        }

        [Test(Description = "Delete non existent project and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void DeleteProject_NonExistentProject_ShouldReturnBadRequest()
        {
            var response = _projectService.DeleteProject(FakeProjectId.ToString()).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        
        
        [Test(Description = "Delete project when user is unauthorized and returns HttpStatus Unauthorized")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void DeleteProject_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var projectService = new ProjectService(UserGenerator.GetUser("FakeUser"));
            
            var response = projectService.DeleteProject(ProjectId.ToString()).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Test(Description = "Delete project with invalid id and returns HttpStatus BadRequest")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void DeleteProject_InvalidProjectId_ShouldReturnBadRequest()
        {
            var response = _projectService.DeleteProject(InvalidId).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Test(Description = "Delete project when user no access and returns HttpStatus Forbidden")]
        [AllureTag("CI")]
        [AllureOwner("Anastasiya")]
        public void DeleteProject_UserNoAccess_ShouldReturnForbidden()
        {
            var projectService = new ProjectService(UserGenerator.GetUser("UserNoAccess"));
            
            var response = projectService.DeleteProject(ProjectId).Result;
            
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }
    }
}