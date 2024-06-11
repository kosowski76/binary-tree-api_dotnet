using System.Text.Json.Serialization;
namespace BinaryTrees.Core.Domain;

public interface IPositionBinaryNode<T>
{
    [JsonInclude]
    public Guid Id { get; set; }
    [JsonInclude]
    public BinaryNode<T> BinaryNode { get; set; }
}

public class PositionBinaryNode<T> : IPositionBinaryNode<T>
{
    [JsonInclude]
    public Guid Id { get; set; }
    [JsonInclude]
    public BinaryNode<T> BinaryNode { get; set; }

    [JsonConstructor]
    public PositionBinaryNode(Guid id, BinaryNode<T> node)
    {
        Id = id;
        BinaryNode = node;
    }
}
