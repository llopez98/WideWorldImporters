namespace WideWorldImporters.AuthSvr.Application.Dto
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpTime { get; set; }
        public string Id { get; set; }
        public IList<string> Roles { get; set; }
    }
}
