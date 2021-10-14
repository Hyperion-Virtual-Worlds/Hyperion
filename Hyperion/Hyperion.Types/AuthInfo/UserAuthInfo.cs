

using System;
using System.Runtime.Serialization;

namespace Hyperion.Types.AuthInfo
{
    [Serializable]
    public class PasswordAuthenticationFailedException : Exception
    {
        public PasswordAuthenticationFailedException()
        {
        }

        public PasswordAuthenticationFailedException(string message)
            : base(message)
        {
        }

        protected PasswordAuthenticationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public PasswordAuthenticationFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public struct UserAuthInfo
    {
        public UUID ID;
        public string PasswordHash;
        public string PasswordSalt;

        public string Password
        {
            get
            {
                throw new NotSupportedException("Password");
            }
            set
            {
                PasswordSalt = UUID.Random.ToString().ComputeMD5();
                PasswordHash = (value.ComputeMD5() + ":" + PasswordSalt).ComputeMD5();
            }
        }

        public void CheckPassword(string password)
        {
            var actpassword = password.StartsWith("$1$") ?
                password.Substring(3) :
                password.ComputeMD5();

            var salted = (actpassword + ":" + PasswordSalt).ComputeMD5();

            if (salted != PasswordHash)
            {
                throw new PasswordAuthenticationFailedException("Could not authenticate your avatar. Please check your username and password, and check the grid if problems persist.");
            }
        }
    }
}