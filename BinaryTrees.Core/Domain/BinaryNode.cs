using BinaryTrees.Core.Domain;
using System.Text.Json.Serialization;
namespace BinaryTrees.Core.Domain;

public interface IBinaryNode<T>
{
    [JsonInclude]
    T Value { get; set; }
    [JsonInclude]
    BinaryNode<T>? Left { get; set; }
    [JsonInclude]
    BinaryNode<T>? Right { get; set; }
    [JsonInclude]
    BinaryNode<T>? Parent { get; set; }
}

public interface IBinaryNode2<T>
{
    // [JsonInclude]
    // public int Position { get; set; }
    [JsonInclude]
    public T Value { get; set; }
    [JsonInclude]
    public IBinaryNode<T>? Left { get; set; }
    [JsonInclude]
    public IBinaryNode<T>? Right { get; set; }
    [JsonInclude]
    public IBinaryNode<T>? Parent { get; set; }
}

public class BinaryNode<T> : IBinaryNode<T>
{
    // [JsonInclude]
    // public int Position { get; set; }
    [JsonInclude]
    public T? Value { get; set; }
    [JsonInclude]
    public BinaryNode<T>? Left { get; set; }
    [JsonInclude]
    public BinaryNode<T>? Right { get; set; }
    [JsonInclude]
    public BinaryNode<T>? Parent { get; set; }

    [JsonConstructor]    
    public BinaryNode(T value, BinaryNode<T> left = null, BinaryNode<T> right = null)
    {
        Value = value;
        Left = (left != null ? Left = left : null);
        Right = (right != null ? Right = right : null);
        if(Left != null)
            { Left.Parent = this; }
        if(Right != null)
            { Right.Parent = this; }
    }

    public BinaryNode()
    {}
    // Implementacja metody Equals
    //public override bool Equals(object obj)
    //{
    //    return Equals(obj as IBinaryNode<T>);
    //}

    // Implementacja metody Equals z IEquatable<Node<T>>
    //public bool Equals(IBinaryNode<T> other)
    //{
    //    if (other == null)
    //        return false;
//
    //    return EqualityComparer<T>.Default.Equals(Value, other.Value);
    //}

    //public override int GetHashCode()
    //{
    //    return EqualityComparer<T>.Default.GetHashCode(Value);
    //}
}
