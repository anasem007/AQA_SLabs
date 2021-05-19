using System.Threading.Tasks;
using RestSharp;
using TestRailApi.ClientExtensions;
using TestRailApi.Constants;
using TestRailApi.Models.Project;
using TestRailApi.Models.User;

namespace TestRailApi.Services
{
    public class ProjectService
    {
        private readonly RestClient _client;

        public ProjectService(User user)
        {
            _client = user.CreateClient();
        }
        
        public async Task<IRestResponse<ProjectResponseModel>> AddProject(ProjectRequestModel project)
        {
            var request = RestRequestBuilder.Build(EndPoints.AddProjectEndPoint, Method.POST, project);
            
            return await _client.ExecuteAsync<ProjectResponseModel>(request);
        }
        
        public async Task<IRestResponse<ProjectResponseModel>> DeleteProject(string projectId)
        {
            var request = RestRequestBuilder.Build(EndPoints.DeleteProjectEndPoint + projectId, Method.POST);
            
            return await _client.ExecuteAsync<ProjectResponseModel>(request);
        }    
        
        public async Task<IRestResponse<ProjectResponseModel>> GetProject(string projectId)
        {
            var request = RestRequestBuilder.Build(EndPoints.GetProjectEndPoint + projectId, Method.GET);
            
            return await _client.ExecuteAsync<ProjectResponseModel>(request);
        }   
    }
}