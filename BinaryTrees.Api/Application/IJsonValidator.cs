using BinaryTrees.Core.Domain;
namespace BinaryTrees.Api.Application;

public interface IJsonValidator<T>
{
    bool IsValid(BinaryNode<T> node);
}
