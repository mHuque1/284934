public interface IRepository<T>
{
    void Add(T item);
    void Update(T updatedItem);
    void Delete(T item);
    T Find(Func<T, bool> filter);
    IList<T> GetAll();
}
