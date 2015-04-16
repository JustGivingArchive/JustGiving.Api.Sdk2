using RestSharp;

namespace JustGiving.Api.Sdk2.Serialization
{
    /// <summary>
    /// Converts TitleCase .NET member/type names to camelCase JSON member names. Conversion in the other direction is already provided by RestSharp.
    /// </summary>
    public class CaseChangingSerializationStrategy : PocoJsonSerializerStrategy
    {
        protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName)
        {
            if (clrPropertyName.Length == 1) return clrPropertyName.ToLower();

            return clrPropertyName[0].ToString().ToLower() + clrPropertyName.Substring(1);
        }
    }
}
