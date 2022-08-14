namespace BookStore.Domain
{
    public interface IBookRepository
    {
        Book[] GetAllByTitle(string titlePart);
    }
}
