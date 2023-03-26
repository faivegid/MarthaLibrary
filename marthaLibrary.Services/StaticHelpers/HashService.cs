namespace marthaLibrary.Services.StaticHelpers
{
    public static class HashService
    {
        public static bool VerifyHash(string text, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(text, hash);
        }

        public static string HashText(string text)
        {
            return BCrypt.Net.BCrypt.HashPassword(text);
        }
    }
}
