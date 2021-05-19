﻿using RestSharp;
using RestSharp.Authenticators;
using TestRailApi.Models.User;
using TestRailApi.Services;

namespace TestRailApi.ClientExtensions
{
    public static class ClientExtensions
    {
        public static RestClient CreateClient(this User user)
        {
            return new RestClient(Configurator.BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(user.Username, user.Password)
            };
        }
    }
}