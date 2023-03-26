namespace marthaLibrary.Models.Config
{
    public class JwtSetting
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
        public int Duration { get; set; }
    }
}
