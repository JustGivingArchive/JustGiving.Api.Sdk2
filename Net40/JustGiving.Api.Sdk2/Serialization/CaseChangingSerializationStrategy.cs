using RestSharp;

namespace JustGiving.Api.Sdk2.Serialization
{
    public class CaseChangingSerializationStrategy : PocoJsonSerializerStrategy
    {
        protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName)
        {
            if (clrPropertyName.Length == 1) return clrPropertyName.ToLower();

            return clrPropertyName[0].ToString().ToLower() + clrPropertyName.Substring(1);
        }
    }
}
