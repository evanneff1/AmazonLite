namespace AmazonLite.Models;

public interface IBookInterface
{
    public IQueryable<Book> Books { get; }
}