using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Common
{
    public class PasswordHasher
    {
        #region Singleton

        private PasswordHasher() { }
        static PasswordHasher() { }

        public static PasswordHasher obj { get; } = new PasswordHasher();

        #endregion

        public string Hash(string password)
        {
            var bytes = UnicodeEncoding.Unicode.GetBytes(password);
            var algorithm = SHA1.Create();
            var hash = algorithm.ComputeHash(bytes);
            var final = Convert.ToBase64String(hash);

            return final;
        }

    }
}
