using System.Text;
using System;

namespace marthaLibrary.Services.StaticHelpers
{
    public static class CodeGenerator
    {
        private static readonly Random random = new Random();

        public static string GenerateRandomNumericString(int length = 6)
        {
            const string chars = "0123456789";
            StringBuilder stringBuilder = new();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                stringBuilder.Append(chars[index]);
            }

            return stringBuilder.ToString();
        }
    }
}
