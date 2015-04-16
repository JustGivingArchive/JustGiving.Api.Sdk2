using RestSharp;
using RestSharp.Serializers;

namespace JustGiving.Api.Sdk2.Serialization
{
    public class JustGivingJsonSerializer : ISerializer
    {
        private readonly IJsonSerializerStrategy _strategy;
        public JustGivingJsonSerializer()
        {
            ContentType = "application/json";
            _strategy = new CaseChangingSerializationStrategy();
        }
        /// <summary>
        /// Serialize the object as JSON
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>JSON as String</returns>
        public string Serialize(object obj)
        {
            return SimpleJson.SerializeObject(obj, _strategy);
        }

        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string RootElement { get; set; }

        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Content type for serialized content
        /// </summary>
        public string ContentType { get; set; }
    }
}