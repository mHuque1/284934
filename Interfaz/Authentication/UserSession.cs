﻿namespace BlazorServerAuthenticationAndAuthorization.Authentication
{
    public class UserSession
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}