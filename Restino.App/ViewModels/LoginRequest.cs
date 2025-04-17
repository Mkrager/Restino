﻿namespace Restino.App.ViewModels
{
    public class LoginRequest
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public bool TwoFactorRequired { get; set; } = false;
    }
}
