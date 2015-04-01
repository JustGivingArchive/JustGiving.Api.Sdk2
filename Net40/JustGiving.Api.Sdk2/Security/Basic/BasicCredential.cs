using System;

namespace JustGiving.Api.Sdk2.Security.Basic
{
    public class BasicCredential
    {
        private readonly string _username;
        private readonly string _password;

        public BasicCredential(string username, string password)
        {
            if(string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be empty");
            }

            _username = username;
            _password = password;
        }

        public string Username
        {
            get { return _username; }
        }

        public string Password
        {
            get { return _password; }
        }
    }
}