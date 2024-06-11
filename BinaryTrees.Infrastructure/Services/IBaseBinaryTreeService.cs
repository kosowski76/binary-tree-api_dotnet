using BinaryTrees.Core.Domain;
namespace BinaryTrees.Infrastructure.Services;

public interface IBaseBinaryTreeService<T>
{
    public Task<BinaryNode<T>> GetRootNodeAsync();
    public Task<IEnumerable<BinaryTreeResult>> BrowseAsync();

    public Task<BinaryNode<T>> CreateNodeAsync(T value);
}
