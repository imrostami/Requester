namespace ServiceHost.ApiTests.Models
{
	public class LoginRequestModel
	{
		public LoginRequestModel(string email, string password)
		{
			Email = email;
			Password = password;
		}

		public string Email { get; set; }
        public string Password { get; set; }
        public string TwoFactorCode { get; set; } = string.Empty;
        public string TwoFactorRecoveryCode { get; set; } = string.Empty;


	}
}
