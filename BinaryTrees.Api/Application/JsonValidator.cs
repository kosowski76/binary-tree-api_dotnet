using BinaryTrees.Core.Domain;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace BinaryTrees.Api.Application;

public class JsonValidator<T> : IJsonValidator<T>
{
    public JsonValidator()
    {
    }

    public bool IsValid(BinaryNode<T> command)
    {
        try
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(command, options);
            JsonDocument.Parse(jsonString);

            return true;
        }
        catch (JsonException e)
        {
            var result = e.Message ;
                throw new JsonException(result);  
        }
    }
}
