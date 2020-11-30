using System;
using System.Linq;

namespace MobileTestApp.Common.Utils
{
    public static class RandomStringUtils
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random _random = new Random();

        public static string GenerateRandomString(int stringLength)
        {
            var chars = Enumerable.Repeat(Chars, stringLength)
                                  .Select(s => s[_random.Next(s.Length)])
                                  .ToArray();
                        
            return new string(chars);
        }
    }
}