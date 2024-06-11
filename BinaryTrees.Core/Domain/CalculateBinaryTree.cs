namespace BinaryTrees.Core.Domain;

public interface ICalculateBinaryTree
{
    public int Id { get; set; }
    public long Calculation { get; set; }

    //public override bool Equals(object? obj)
    //{
    //    return obj is ICalculateBinaryTree input && Equals(input);
    //}
    
    //protected bool Equals(ICalculateBinaryTree other)
    //{
    //    return Id == other.Id && Calculation == other.Calculation;
    //}

    // GetHashCode()
}
public class CalculateBinaryTree : ICalculateBinaryTree
{
    public int Id { get; set; }
    public long Calculation { get; set; }

    public CalculateBinaryTree()
    {        
    }

    // public override bool Equals(object? obj)
    // {
    //     return obj is CalculateBinaryTree input && Equals(input);
    // }
    // 
    // protected bool Equals(CalculateBinaryTree other)
    // {
    //     return Id == other.Id && Calculation == other.Calculation;
    // }

    // GetHashCode()
}
