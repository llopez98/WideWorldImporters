﻿namespace WideWorldImporters.AuthSvr.Application.Dto
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpTime { get; set; }
    }
}
