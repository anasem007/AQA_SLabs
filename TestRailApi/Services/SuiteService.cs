using System.Threading.Tasks;
using RestSharp;
using TestRailApi.ClientExtensions;
using TestRailApi.Constants;
using TestRailApi.Models.Suite;
using TestRailApi.Models.User;

namespace TestRailApi.Services
{
    public class SuiteService
    {
        private readonly RestClient _client;
        
        public SuiteService(User user)
        {
            _client = user.CreateClient();
        }
        
        public async Task<IRestResponse<SuiteResponseModel>> AddSuite(string projectId, SuiteRequestModel suite)
        {
            var request = RestRequestBuilder.Build(EndPoints.AddSuiteEndPoint + projectId, Method.POST, suite);

            return await _client.ExecuteAsync<SuiteResponseModel>(request);
        }
        
        public async Task<IRestResponse<SuiteResponseModel>> UpdateSuite(string suiteId, SuiteRequestModel suite)
        {
            var request = RestRequestBuilder.Build(EndPoints.UpdateSuiteEndPoint + suiteId, Method.POST, suite);
            
            return await _client.ExecuteAsync<SuiteResponseModel>(request);
        }
    }
}