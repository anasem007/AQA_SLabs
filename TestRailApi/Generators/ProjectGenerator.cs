using System;
using System.Linq;
using TestRailApi.Models.Project;

namespace TestRailApi.Generators
{
    public static class ProjectGenerator
    {
        public static ProjectRequestModel GetProject(string name)
        {
            foreach (var project in TestData.Projects.Where(project => project.Name == name))
            {
                return project;
            }

            throw new Exception();
        }

        public static ProjectRequestModel GetProjectWithoutName(string name)
        {
            foreach (var project in TestData.Projects.Where(project => project.Name == name))
            {
                return new ProjectRequestModel
                {
                    Announcement = project.Announcement,
                    ShowAnnouncement = project.ShowAnnouncement,
                    SuiteMode = project.SuiteMode
                };
            }

            throw new Exception();
        }
        
        public static ProjectRequestModel GetProjectWithoutAnnouncement(string name)
        {
            foreach (var project in TestData.Projects.Where(project => project.Name == name))
            {
                return new ProjectRequestModel
                {
                    Name = project.Name,
                    ShowAnnouncement = project.ShowAnnouncement,
                    SuiteMode = project.SuiteMode
                };
            }

            throw new Exception();
        }
        
        public static ProjectRequestModel GetProjectWithoutSuiteMode(string name)
        {
            foreach (var project in TestData.Projects.Where(project => project.Name == name))
            {
                return new ProjectRequestModel
                {
                    Name = project.Name,
                    Announcement = project.Announcement,
                    ShowAnnouncement = project.ShowAnnouncement
                };
            }

            throw new Exception();
        }
    }
}