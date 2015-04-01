using System;

namespace JustGiving.Api.Sdk2.Security.OAuth
{
    public class OAuthAccessToken
    {
        private readonly string _value;


        public OAuthAccessToken(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Access token cannot be empty");
            }

            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }
}