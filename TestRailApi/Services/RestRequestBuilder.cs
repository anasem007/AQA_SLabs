﻿using RestSharp;
using TestRailApi.Utils;

namespace TestRailApi.Services
{
    public static class RestRequestBuilder
    {
        public static RestRequest Build(string endPoint, Method method, object model = null)
        {
            var request = new RestRequest
            {
                Resource = endPoint,
                Method = method
            };
            request.AddJsonBody(Serializer.Serialize(model));
            
            return request;
        }
    }
}