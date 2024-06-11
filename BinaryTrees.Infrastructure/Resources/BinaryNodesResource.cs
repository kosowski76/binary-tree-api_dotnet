using BinaryTrees.Core.Domain;
namespace BinaryTrees.Infrastructure.Resources;

public interface IBinaryNodeResources<T>
{
    public static List<BinaryNode<T>>? _BinaryNodeSources;
}

public class BinaryNodeResources<T> : IBinaryNodeResources<T>
{
   public static List<BinaryNode<T>>? _BinaryNodeSources;

   private static readonly ISet<PositionBinaryNode<int>> _IntBinaryNodeSources = new HashSet<PositionBinaryNode<int>>()
    {
        new PositionBinaryNode<int>(Guid.Parse("d3e1f86c-d2c8-4d92-9b7d-30c9409b9e5d"),
            new BinaryNode<int>(4, new BinaryNode<int>(3), new BinaryNode<int>(5))),
    };
    private static readonly ISet<PositionBinaryNode<string>> _StrBinaryNodeSources = new HashSet<PositionBinaryNode<string>>()
    {
        new PositionBinaryNode<string>(Guid.Parse("f7e148a2-821b-25c1-62b7-409b9c9de530"),
            new BinaryNode<string>("E", new BinaryNode<string>("D"), new BinaryNode<string>("F"))),
    };
    private static readonly ISet<BinaryTreeResult> _ResultsBinaryNodeSources = new HashSet<BinaryTreeResult>()
    {
        new BinaryTreeResult(Guid.Parse("d3e1f86c-d2c8-4d92-9b7d-30c9409b9e5d"),
            "test1", DateTime.UtcNow, "3,4,5", "5,4,3"),
        new BinaryTreeResult(Guid.Parse("79f7e123-821b-a5c1-62b7-b27c9de53482"),
            "BinaryNode1", DateTime.UtcNow, "C,E,G", "G,E,C"),
        new BinaryTreeResult(Guid.Parse("f7e148a2-b318-25c1-62b3-409b9c9de530"),
            "BinaryNode1", DateTime.UtcNow, "2,1,3", "3,1,2"),
    };

    protected readonly List<BinaryNode<int>> _IntBinaryNodes;
    protected readonly List<BinaryNode<int>> _StrBinaryNodes;

    public static IEnumerable<object[]> IntObjectsSource => new List<object[]>
    {
        new object[] { new BinaryNode<int>(0, new BinaryNode<int>(-1), new BinaryNode<int>(1)), "-1,0,1" },

        new object[] { new BinaryNode<int>(-1, new BinaryNode<int>(-2),
            new BinaryNode<int>(4, new BinaryNode<int>(2,
            new BinaryNode<int>(1), new BinaryNode<int>(3)), new BinaryNode<int>(5))), "-2,-1,1,2,3,4,5" },

        new object[] { new BinaryNode<int>(0, new BinaryNode<int>(-1),
            new BinaryNode<int>(4, new BinaryNode<int>(2,
            new BinaryNode<int>(1), new BinaryNode<int>(3)), new BinaryNode<int>(5))), "-1,0,1,2,3,4,5" },

        new object[] { new BinaryNode<int>(0, new BinaryNode<int>(-2,
            new BinaryNode<int>(-3), new BinaryNode<int>(-1)), new BinaryNode<int>(4,
            new BinaryNode<int>(2, new BinaryNode<int>(1), new BinaryNode<int>(3)),
            new BinaryNode<int>(6, new BinaryNode<int>(5), new BinaryNode<int>(7)))), "-3,-2,-1,0,1,2,3,4,5,6,7" }
    };


}
