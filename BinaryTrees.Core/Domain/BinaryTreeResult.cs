using System.Text.Json.Serialization;
namespace BinaryTrees.Core.Domain;

public interface IBinaryTreeResult
{
    [JsonInclude]
    public Guid Id  { get; }
    [JsonInclude]
    public string Name { get; set; }
    [JsonInclude]
    public DateTime Date { get; set; }
    [JsonInclude]
    public string Result { get; set; }
    [JsonInclude]
    public string? Negative { get; set; }
}
public class BinaryTreeResult : IBinaryTreeResult
{  
    [JsonInclude]  
    public Guid Id { get; }
    [JsonInclude]
    public string? Name { get; set; }
    [JsonInclude]
    public DateTime Date { get; set; }
    [JsonInclude]
    public string? Result { get; set; }
    [JsonInclude]
    public string? Negative { get; set; }

    public BinaryTreeResult(Guid id, string name, DateTime date,
        string result, string negative)
    {
        Id = id;
        Name = name;
        Date = date;
        Result = result;
        Negative = negative;
    }
}

public interface ICalculationResults
{
    [JsonInclude]
    public string Result { get; set; }
    [JsonInclude]
    public string? Negative { get; set; }
}
public class CalculationResults : ICalculationResults
{
    public string Result { get; set; }
    public string? Negative { get; set; }

    public CalculationResults(string result,
        string? negative = null)
        {
            Result = result;
            Negative = negative;
        }
}
